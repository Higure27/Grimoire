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

    private SpellBook starter_book;
    private SpellInventory starter_inventory;
    private Summon starter_summon;

	// Use this for initialization
	void Start ()
    {
        starter_book = new SpellBook();
        Setup_Starter_Books();
        starter_inventory = new SpellInventory();
        Setup_Starter_Inventory();
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
        starter_inventory.Add_Spell(new DarkStrike());
        starter_inventory.Add_Spell(new DarkStrike());
        starter_inventory.Add_Spell(new FireStrike());
        starter_inventory.Add_Spell(new FireStrike());
    }

    private void Setup_Starter_Books()
    {
        starter_book.Add_Spell(new FireStrike());
        starter_book.Add_Spell(new FireStrike());
        starter_book.Add_Spell(new LightStrike());
        starter_book.Add_Spell(new LightStrike());
        starter_book.Add_Spell(new PoisonStrike());
        starter_book.Add_Spell(new PoisonStrike ());
        starter_book.Add_Spell(new QuickStrike());
        starter_book.Add_Spell(new QuickStrike());
        starter_book.Add_Spell(new DarkShield());
        starter_book.Add_Spell(new DarkShield());
        starter_book.Add_Spell(new FireShield());
        starter_book.Add_Spell(new FireShield());
        starter_book.Add_Spell(new HardShield());
        starter_book.Add_Spell(new HardShield());
        starter_book.Add_Spell(new StunShield());
        starter_book.Add_Spell(new StunShield());
        starter_book.Add_Spell(new DarkAffliction());
        starter_book.Add_Spell(new DarkAffliction());
        starter_book.Add_Spell(new FireAffliction());
        starter_book.Add_Spell(new FireAffliction());
    }


    private void Setup_Summon()
    {
        if(vampire_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon = new Summon("Vampire", 1, 0, 60, 3, 3, Summon.Type.DARK);
        }
        else if (paladin_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon = new Summon("Paladin", 1, 0, 50, 4, 4, Summon.Type.LIGHT);
        }
        else if (phoenix_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon = new Summon("Phoenix", 1, 0, 40, 6, 3, Summon.Type.FIRE);
        }
        else if (golem_toggle.GetComponent<Toggle>().isOn)
        {
            starter_summon = new Summon("Golem", 1, 0, 40, 3, 6, Summon.Type.EARTH);
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
