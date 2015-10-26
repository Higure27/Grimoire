using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateNewUser : MonoBehaviour
{
    private int font_size;
    private int warning_font_size;

    public GameObject warning_text;
    public GameObject character_name_field;
    public GameObject choose_summon_title;
    public GameObject vampire_toggle;
    public GameObject paladin_toggle;
    public GameObject phoenix_toggle;
    public GameObject golem_toggle;
    public GameObject create_button;

    //private SpellBook DarkStarter;
    //private SpellBook LightStarter;
    //private SpellBook FireStarter;
    //private SpellBook EarthStarter;
    private SpellBook starter_book;
    private SpellInventory starter_inventory;
    private BasePlayerSummon starter_summon;

	// Use this for initialization
	void Start ()
    {
        starter_book = new SpellBook();
        Setup_Starter_Books();
        starter_inventory = new SpellInventory();
        Setup_Starter_Inventory();
        starter_summon = new BasePlayerSummon();
        //DarkStarter = new SpellBook();
        //LightStarter = new SpellBook();
        //FireStarter = new SpellBook();
        //EarthStarter = new SpellBook();
        warning_font_size = (int)(Screen.width * 0.014f);
        font_size = (int)(Screen.width * 0.02f);
        character_name_field.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        character_name_field.GetComponentsInChildren<Text>()[1].fontSize = font_size;
        choose_summon_title.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        vampire_toggle.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        paladin_toggle.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        phoenix_toggle.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        golem_toggle.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        create_button.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        warning_text.GetComponent<Text>().fontSize = warning_font_size;
        warning_text.SetActive(false);
    }

    private void Setup_Starter_Inventory()
    {
        starter_inventory.AddSpell(new VampireSlash());
        starter_inventory.AddSpell(new VampireSlash());
        starter_inventory.AddSpell(new VampiricShield());
        starter_inventory.AddSpell(new VampiricShield());
    }

    private void Setup_Starter_Books()
    {
        starter_book.AddSpell(new BurnAttack());
        starter_book.AddSpell(new BurnAttack());
        starter_book.AddSpell(new VampireSlash());
        starter_book.AddSpell(new VampireSlash());
        starter_book.AddSpell(new ParalyzingGrasp());
        starter_book.AddSpell(new ParalyzingGrasp());
        starter_book.AddSpell(new PoisonAttack());
        starter_book.AddSpell(new PoisonAttack());
        starter_book.AddSpell(new DragonBite());
        starter_book.AddSpell(new DragonBite());
        starter_book.AddSpell(new BurningShield());
        starter_book.AddSpell(new BurningShield());
        starter_book.AddSpell(new GlaringShield());
        starter_book.AddSpell(new GlaringShield());
        starter_book.AddSpell(new HealSelf());
        starter_book.AddSpell(new HealSelf());
        starter_book.AddSpell(new VampiricShield());
        starter_book.AddSpell(new VampiricShield());
        starter_book.AddSpell(new CureSelf());
        starter_book.AddSpell(new CureSelf());
    }


    private void Setup_Summon()
    {
        if(vampire_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon.Summon_Name = "Vampire";
            starter_summon.Summon_Level = 1;
            starter_summon.Summon_Class = new BaseDarkSummon();
            starter_summon.Strength = starter_summon.Summon_Class.Strength;
            starter_summon.Defense = starter_summon.Summon_Class.Defense;
            starter_summon.Health = starter_summon.Summon_Class.Health;
            starter_summon.Burn = 0;
            starter_summon.Poison = 0;
            starter_summon.Paralyze = 0;
            starter_summon.Attack_Boost = false;
            starter_summon.Defense_Boost = false;
        }
        else if (paladin_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon.Summon_Name = "Paladin";
            starter_summon.Summon_Level = 1;
            starter_summon.Summon_Class = new BaseLightSummon();
            starter_summon.Strength = starter_summon.Summon_Class.Strength;
            starter_summon.Defense = starter_summon.Summon_Class.Defense;
            starter_summon.Health = starter_summon.Summon_Class.Health;
            starter_summon.Burn = 0;
            starter_summon.Poison = 0;
            starter_summon.Paralyze = 0;
            starter_summon.Attack_Boost = false;
            starter_summon.Defense_Boost = false;
        }
        else if (phoenix_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon.Summon_Name = "Phoenix";
            starter_summon.Summon_Level = 1;
            starter_summon.Summon_Class = new BaseFireSummon();
            starter_summon.Strength = starter_summon.Summon_Class.Strength;
            starter_summon.Defense = starter_summon.Summon_Class.Defense;
            starter_summon.Health = starter_summon.Summon_Class.Health;
            starter_summon.Burn = 0;
            starter_summon.Poison = 0;
            starter_summon.Paralyze = 0;
            starter_summon.Attack_Boost = false;
            starter_summon.Defense_Boost = false;
        }
        else if (golem_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon.Summon_Name = "Golem";
            starter_summon.Summon_Level = 1;
            starter_summon.Summon_Class = new BaseEarthSummon();
            starter_summon.Strength = starter_summon.Summon_Class.Strength;
            starter_summon.Defense = starter_summon.Summon_Class.Defense;
            starter_summon.Health = starter_summon.Summon_Class.Health;
            starter_summon.Burn = 0;
            starter_summon.Poison = 0;
            starter_summon.Paralyze = 0;
            starter_summon.Attack_Boost = false;
            starter_summon.Defense_Boost = false;
        }
    }

    public void Create_User()
    {
        BasePlayer player = new BasePlayer();
        
        GrimoireDatabase db = new GrimoireDatabase();
        string user = character_name_field.GetComponentsInChildren<Text>()[1].text;
        player.Player_Name = user;
        user = user.Trim().ToLower().Replace(" ", string.Empty);
        if(user == "")
        {
            warning_text.GetComponent<Text>().text = "Name Cannot Be Empty";
            warning_text.SetActive(true);
            return;
        }
        Debug.Log(user + " , word size: " + user.Length);
        Debug.Log("User Exisist: " + db.User_Exists(user));
        if(db.User_Exists(user))
        {
            warning_text.GetComponent<Text>().text = "User already exists";
            warning_text.SetActive(true);
            return;
        }

        player.Player_Spell_Book = starter_book;
        Setup_Summon();
        player.Players_Summon = starter_summon;
        player.Player_Spell_Inventory = starter_inventory;

        db.Save_Player(user, player);

        GameManager.instance.player = player;
        GameManager.instance.current_state = GameManager.GameStates.MAIN;
        GameManager.instance.scene_loaded = false;
    }
}
