using UnityEngine;
using System.Collections;
using System.Xml;

public class GrimoireDatabase
{
    /* Load Player Functions */
    private XmlDocument spell_book_db = new XmlDocument();
    private XmlNode spell_book_root;

    private XmlDocument summon_db = new XmlDocument();
    private XmlNode summon_root;

    public void Load_Player(string user)
    {
        GameManager.instance.player = new BasePlayer();
        GameManager.instance.player.Player_Spell_Book = new SpellBook();
        GameManager.instance.player.Players_Summon = new BasePlayerSummon();

        Load_Player_Summon(user);

        spell_book_db.Load("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");
        spell_book_root = spell_book_db.DocumentElement;
        string path = "/Book[@id='" + user + "']";
        XmlNode book = spell_book_root.SelectSingleNode(path);
        if (book == null)
        {
            return;
        }
        foreach (XmlNode spell in book.ChildNodes)
        {
            Add_Spell(spell.InnerText);
        }
    }

    private void Load_Player_Summon(string user)
    {
        summon_db.Load("Assets/Scripts/Grimoire/Database/SummonDatabase.xml");
        summon_root = summon_db.DocumentElement;
        string path = "/Summon[@id='" + user + "']";
        XmlNode summon = summon_root.SelectSingleNode(path);
        if(summon == null)
        {
            return;
        }
        GameManager.instance.player.Players_Summon.Summon_Name = summon["name"].InnerText;
        GameManager.instance.player.Players_Summon.Summon_Level = int.Parse(summon["level"].InnerText);
        switch (summon["class"].InnerText)
        {
            case "LightSummon":
                GameManager.instance.player.Players_Summon.Summon_Class = new BaseLightSummon();
                break;
            case "DarkSummon":
                GameManager.instance.player.Players_Summon.Summon_Class = new BaseDarkSummon();
                break;
            case "FireSummon":
                break;
            case "EarthSummon":
                break;
        }
        GameManager.instance.player.Players_Summon.Strength = int.Parse(summon["strength"].InnerText);
        GameManager.instance.player.Players_Summon.Defense = int.Parse(summon["defense"].InnerText);
        GameManager.instance.player.Players_Summon.Health = int.Parse(summon["health"].InnerText);
        GameManager.instance.player.Players_Summon.Current_EXP = int.Parse(summon["current_exp"].InnerText);
        GameManager.instance.player.Players_Summon.Burn = 0;
        GameManager.instance.player.Players_Summon.Poison = 0;
        GameManager.instance.player.Players_Summon.Paralyze = 0;
        GameManager.instance.player.Players_Summon.Attack_Boost = false;
        GameManager.instance.player.Players_Summon.Defense_Boost = false;
    }

    private void Add_Spell(string spell)
    {
        switch (spell)
        {
            // Attack Spells
            case "BurnAttack":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new BurnAttack());
                break;
            case "DragonBite":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new DragonBite());
                break;
            case "ParalyzingGrasp":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new ParalyzingGrasp());
                break;
            case "PoisonAttack":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new PoisonAttack());
                break;
            case "Shriek":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new Shriek());
                break;
            case "VampireSlash":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new VampireSlash());
                break;
            // Defense Spells
            case "BurningShield":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new BurningShield());
                break;
            case "Cure":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new CureSelf());
                break;
            case "GlaringShield":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new GlaringShield());
                break;
            case "Heal":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new HealSelf());
                break;
            case "PoisonNeedle":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new PoisonNeedle());
                break;
            case "VampiricShield":
                GameManager.instance.player.Player_Spell_Book.AddSpell(new VampiricShield());
                break;
        }
    }

    // Save Player Function

}
