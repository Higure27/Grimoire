using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;
using System.IO;

public class StartScreen : MonoBehaviour
{
    public GameObject user_name;

    private XmlDocument spell_book_db = new XmlDocument();
    private XmlNode spell_book_root;
    //private XmlNamespaceManager spell_book_nsmgr;
    //private XmlTextReader spell_book_reader;


    void Awake()
    {
        //spell_book_db.Load("SpellBookDatabase.xml");
        //spell_book_root = spell_book_db.DocumentElement;
        //spell_book_nsmgr = new XmlNamespaceManager(spell_book_db.NameTable);
        //spell_book_nsmgr.AddNamespace("sbk", "urn:spellbooks-schema");
        //spell_book_reader = new XmlTextReader("SpellBookDatabase.xml");
    }

    public void Game_Start()
    {
        GameManager.instance.current_state = GameManager.GameStates.BATTLE;
        GameManager.instance.scene_loaded = false;
    }

    public void Login()
    {
        string user = user_name.GetComponentsInChildren<Text>()[1].text;
        if(user == null || user == "")
        {
            return;
        }
        spell_book_db.Load("Assets/Scripts/Grimoire/Database/SpellBookDatabase.xml");
        spell_book_root = spell_book_db.DocumentElement;
        string path = "/Book[@id='" + user + "']";
        Debug.Log(path);
        XmlNode book = spell_book_root.SelectSingleNode(path);
        Debug.Log("GOT HERE");
        if (book == null)
        {
            return;
        }
        // Setup Player
        GameManager.instance.player = new BasePlayer();
        GameManager.instance.player.Player_Name = user;
        GameManager.instance.player.Player_Spell_Book = new SpellBook();
        GameManager.instance.player.Players_Summon = new BasePlayerSummon();
        // Setup Players Summon
        GameManager.instance.player.Players_Summon.Summon_Name = "Paladin";
        GameManager.instance.player.Players_Summon.Summon_Level = 1;
        GameManager.instance.player.Players_Summon.Summon_Class = new BaseLightSummon();
        GameManager.instance.player.Players_Summon.Strength = GameManager.instance.player.Players_Summon.Summon_Class.Strength;
        GameManager.instance.player.Players_Summon.Defense = GameManager.instance.player.Players_Summon.Summon_Class.Defense;
        GameManager.instance.player.Players_Summon.Health = GameManager.instance.player.Players_Summon.Summon_Class.Health;
        GameManager.instance.player.Players_Summon.Burn = 0;
        GameManager.instance.player.Players_Summon.Poison = 0;
        GameManager.instance.player.Players_Summon.Paralyze = 0;
        GameManager.instance.player.Players_Summon.Attack_Boost = false;
        GameManager.instance.player.Players_Summon.Defense_Boost = false;

        foreach(XmlNode spell in book.ChildNodes)
        {
            Add_Spell(spell.InnerText);
        }

        Game_Start();
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
}
