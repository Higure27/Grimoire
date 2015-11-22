using UnityEngine;
using System.Collections;
using System.Xml;
using System;
using System.Runtime.Remoting;

public class GrimoireDatabase
{
    /* Load Player Functions */
    private XmlDocument spell_book_db = new XmlDocument();
    private XmlNode spell_book_root;

    private XmlDocument spell_inventory_db = new XmlDocument();
    private XmlNode spell_inventory_root;

    private XmlDocument summon_db = new XmlDocument();
    private XmlNode summon_root;

    public void Load_Player(string user)
    {
        user = user.ToLower().Replace(" ", string.Empty);
        GameManager.instance.player = new BasePlayer();
        GameManager.instance.player.Player_Spell_Book = new SpellBook();
        GameManager.instance.player.Player_Spell_Inventory = new SpellInventory();
        GameManager.instance.player.Player_Name = user;

        Load_Player_Summon(user);
        Load_Player_Spell_Inventory(user);

        spell_book_db.Load("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");
        spell_book_root = spell_book_db.DocumentElement;
        string path = "descendant::Book[@id='" + user + "']";
        XmlNode book = spell_book_root.SelectSingleNode(path);
        if (book == null)
        {
            return;
        }
        Debug.Log("Spell Book Elements: " + book.ChildNodes.Count);
        foreach (XmlNode spell in book.ChildNodes)
        {
            Add_Spell(spell.InnerText, "spell_book");
        }
    }

    private void Load_Player_Spell_Inventory(string user)
    {
        spell_inventory_db.Load("Assets/Scripts/Grimoire/Database/SpellInventoryDatabase.xml");
        spell_inventory_root = spell_inventory_db.DocumentElement;
        string path = "descendant::Inventory[@id='" + user + "']";
        XmlNode inventory = spell_inventory_root.SelectSingleNode(path);
        if(inventory == null)
        {
            return;
        }
        Debug.Log("Inventory Elements: " + inventory.ChildNodes.Count);
        foreach (XmlNode spell in inventory.ChildNodes)
        {
            Add_Spell(spell.InnerText, "inventory");
        }
    }

    private void Load_Player_Summon(string user)
    {
        summon_db.Load("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
        summon_root = summon_db.DocumentElement;
        string path = "descendant::Summon[@id='" + user + "']";
        XmlNode summon = summon_root.SelectSingleNode(path);
        if(summon == null)
        {
            return;
        }
        string name = summon["name"].InnerText;
        int level = int.Parse(summon["level"].InnerText);
        Summon.Type type = Summon.Type.LIGHT;
        switch (summon["class"].InnerText)
        {
            case "LIGHT":
                type = Summon.Type.LIGHT;
                break;
            case "DARK":
                type = Summon.Type.DARK;
                break;
            case "FIRE":
                type = Summon.Type.FIRE;
                break;
            case "EARTH":
                type = Summon.Type.EARTH;
                break;
        }
        int strength = int.Parse(summon["strength"].InnerText);
        int defense = int.Parse(summon["defense"].InnerText);
        int health = int.Parse(summon["health"].InnerText);
        int exp = int.Parse(summon["current_exp"].InnerText);

        GameManager.instance.player.Players_Summon = new Summon(name, level, exp, health, strength, defense, type);
    }

    /*
     * Checks if a user with a given username has already been created
     */
    public bool User_Exists(string user)
    {
        summon_db.Load("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
        summon_root = summon_db.DocumentElement;
        string path = "descendant::Summon[@id='" + user + "']";
        XmlNode exists = summon_root.SelectSingleNode(path);
        if(exists == null)
        {
            return false;
        }
        return true;
    }

    private void Add_Spell(string spell, string location)
    {
        if (location == "spell_book")
        {
            ObjectHandle handle = Activator.CreateInstance(null, spell);
            BaseSpell s = (BaseSpell)handle.Unwrap();
            GameManager.instance.player.Player_Spell_Book.Add_Spell(s);
        }
        else if(location == "inventory")
        {
            ObjectHandle handle = Activator.CreateInstance(null, spell);
            BaseSpell s = (BaseSpell)handle.Unwrap();
            GameManager.instance.player.Player_Spell_Inventory.Add_Spell(s);
        }
    }

    // Save/Create Player Functions

    public void Save_Player(string user, BasePlayer player)
    {
        user = user.ToLower().Replace(" ", string.Empty);
        if (user == "" || player == null)
            return;
        if(User_Exists(user))
        {
            Update_Player(user, player);
        }
        else
        {
            Create_Player(user, player);
        }
    }

    private void Update_Player(string user, BasePlayer player)
    {
        // Saves Spell Book
        spell_book_db.Load("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");
        spell_book_root = spell_book_db.DocumentElement;
        for(int i = 0; i < player.Player_Spell_Book.Spell_List.Count; i++)
        {
            string xpath = "descendant::Book[@id='" + user + "']/spell_" + (i + 1);
            Debug.Log(xpath);
            XmlNode node = spell_book_root.SelectSingleNode(xpath);
            Debug.Log(node.InnerText);
            node.InnerText = player.Player_Spell_Book.Spell_List[i].Name.Replace(" ", string.Empty);
        }
        spell_book_db.Save("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");

        // Saves Spell Inventory
        spell_inventory_db.Load("Assets/Scripts/Grimoire/Database/SpellInventoryDatabase.xml");
        spell_inventory_root = spell_inventory_db.DocumentElement;
        string path = "descendant::Inventory[@id='" + user + "']";
        XmlNode inventory = spell_inventory_root.SelectSingleNode(path);
        int count = 0;
        foreach (XmlNode node in inventory.ChildNodes)
        {
            string spell_name = player.Player_Spell_Inventory.Spell_Inventory[count].Name.Replace(" ", string.Empty);
            node.InnerText = spell_name;
            count++;
        }
        spell_inventory_db.Save("Assets/Scripts/Grimoire/Database/SpellInventoryDatabase.xml");

        // Saves Summon
        summon_db.Load("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
        summon_root = summon_db.DocumentElement;
        XmlNode level = summon_root.SelectSingleNode("descendant::Summon[@id='" + user + "']/level");
        level.InnerText = player.Players_Summon.Level.ToString();
        XmlNode strength = summon_root.SelectSingleNode("descendant::Summon[@id = '" + user + "']/strength");
        strength.InnerText = player.Players_Summon.Strength.ToString();
        XmlNode defense = summon_root.SelectSingleNode("descendant::Summon[@id = '" + user + "']/defense");
        defense.InnerText = player.Players_Summon.Defense.ToString();
        XmlNode health = summon_root.SelectSingleNode("descendant::Summon[@id = '" + user + "']/health");
        health.InnerText = player.Players_Summon.Base_Health.ToString();
        XmlNode current_exp = summon_root.SelectSingleNode("descendant::Summon[@id = '" + user + "']/current_exp");
        current_exp.InnerText = player.Players_Summon.Curr_Exp.ToString();
        summon_db.Save("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
    }

    private void Create_Player(string user, BasePlayer player)
    {
        spell_book_db.Load("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");
        XmlElement book = spell_book_db.CreateElement("Book");
        book.SetAttribute("id", user);
        for(int i = 0; i < player.Player_Spell_Book.Spell_List.Count; i++)
        {
            XmlElement spell = spell_book_db.CreateElement("spell_" + (i+1));
            string spell_name = player.Player_Spell_Book.Spell_List[i].Name.Replace(" ", string.Empty);
            spell.InnerText = spell_name;
            book.AppendChild(spell);
        }
        spell_book_db.DocumentElement.AppendChild(book);
        spell_book_db.Save("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");

        spell_inventory_db.Load("Assets/Scripts/Grimoire/Database/SpellInventoryDatabase.xml");
        XmlElement inventory = spell_inventory_db.CreateElement("Inventory");
        inventory.SetAttribute("id", user);
        for(int i = 0; i < player.Player_Spell_Inventory.Spell_Inventory.Count; i++)
        {
            XmlElement spell = spell_inventory_db.CreateElement("spell");
            string spell_name = player.Player_Spell_Inventory.Spell_Inventory[i].Name.Replace(" ", string.Empty);
            spell.InnerText = spell_name;
            inventory.AppendChild(spell);
        }
        spell_inventory_db.DocumentElement.AppendChild(inventory);
        spell_inventory_db.Save("Assets/Scripts/Grimoire/Database/SpellInventoryDatabase.xml");

        summon_db.Load("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
        XmlElement summon = summon_db.CreateElement("Summon");
        summon.SetAttribute("id", user);
        XmlElement name = summon_db.CreateElement("name");
        name.InnerText = player.Players_Summon.Name;
        summon.AppendChild(name);
        XmlElement level = summon_db.CreateElement("level");
        level.InnerText = player.Players_Summon.Level.ToString();
        summon.AppendChild(level);
        XmlElement summon_class = summon_db.CreateElement("class");
        summon_class.InnerText = player.Players_Summon.Summon_Type.ToString();
        summon.AppendChild(summon_class);
        XmlElement strength = summon_db.CreateElement("strength");
        strength.InnerText = player.Players_Summon.Strength.ToString();
        summon.AppendChild(strength);
        XmlElement defense = summon_db.CreateElement("defense");
        defense.InnerText = player.Players_Summon.Defense.ToString();
        summon.AppendChild(defense);
        XmlElement health = summon_db.CreateElement("health");
        health.InnerText = player.Players_Summon.Health.ToString();
        summon.AppendChild(health);
        XmlElement exp = summon_db.CreateElement("current_exp");
        exp.InnerText = player.Players_Summon.Curr_Exp.ToString();
        summon.AppendChild(exp);
        summon_db.DocumentElement.AppendChild(summon);
        summon_db.Save("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
    }

}
