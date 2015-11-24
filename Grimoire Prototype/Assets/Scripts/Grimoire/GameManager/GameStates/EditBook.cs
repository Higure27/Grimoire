using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EditBook : MonoBehaviour
{
    private GameObject spell_book_container;
    private GameObject inventory_container;

    private int title_font_size;
    private int font_size;

    private GameObject spell_book_title;
    private GameObject inventory_title;
    private GameObject switch_spell;
    private GameObject back;

	// Use this for initialization
	void Start ()
    {
        title_font_size = (int)(Screen.width * 0.02f);
        font_size = (int)(Screen.width * 0.014f);
        
        spell_book_container = GameObject.Find("SpellBookContainer");
        inventory_container = GameObject.Find("InventoryContainer");
        spell_book_title = GameObject.Find("SpellBook");
        inventory_title = GameObject.Find("Inventory");
        switch_spell = GameObject.Find("SwitchSpell");
        back = GameObject.Find("Back");
        inventory_title.GetComponent<Text>().fontSize = title_font_size;
        spell_book_title.GetComponent<Text>().fontSize = title_font_size;
        switch_spell.GetComponentInChildren<Text>().fontSize = font_size;
        back.GetComponentInChildren<Text>().fontSize = font_size;
        foreach(Text t in spell_book_container.GetComponentsInChildren<Text>())
        {
            t.fontSize = font_size;
        }
        foreach(Text t in inventory_container.GetComponentsInChildren<Text>())
        {
            t.fontSize = font_size;
        }
        Setup();
	}

    private void Setup()
    {
        Toggle[] spell_book_spells = spell_book_container.GetComponentsInChildren<Toggle>();

        Debug.Log(spell_book_spells.Length);
        for (int i = 0; i < spell_book_spells.Length; i++)
        {
            Debug.Log("GameManager Spell Book: " + GameManager.instance.player.Player_Spell_Book.Spell_List.Count);
            spell_book_spells[i].gameObject.GetComponentInChildren<Text>().text = GameManager.instance.player.Player_Spell_Book.Spell_List[i].Name;
        }
        Toggle[] inventory_spells = inventory_container.GetComponentsInChildren<Toggle>();
        Debug.Log(inventory_spells.Length);
        for (int i = 0; i < inventory_spells.Length; i++)
        {
            if (i < GameManager.instance.player.Player_Spell_Inventory.Spell_Inventory.Count)
            {
                inventory_spells[i].gameObject.GetComponentInChildren<Text>().text = GameManager.instance.player.Player_Spell_Inventory.Spell_Inventory[i].Name;
            }
            else
            {
                inventory_spells[i].gameObject.SetActive(false);
            }
        }
    }

    public void Switch_Spells()
    {
        Toggle[] spell_book_spells = spell_book_container.GetComponentsInChildren<Toggle>();
        Toggle[] inventory_spells = inventory_container.GetComponentsInChildren<Toggle>();
        int spell_book_index = 0;
        int inventory_index = 0;

        for(int i = 0; i < spell_book_spells.Length; i++)
        {
            if(spell_book_spells[i].isOn)
            {
                spell_book_index = i;
            }
        }
        for(int i = 0; i < inventory_spells.Length; i++)
        {
            if(inventory_spells[i].isOn)
            {
                inventory_index = i;
            }
        }

        string temp = inventory_spells[inventory_index].gameObject.GetComponentInChildren<Text>().text;
        inventory_spells[inventory_index].gameObject.GetComponentInChildren<Text>().text = spell_book_spells[spell_book_index].gameObject.GetComponentInChildren<Text>().text;
        spell_book_spells[spell_book_index].gameObject.GetComponentInChildren<Text>().text = temp;

        BaseSpell card = GameManager.instance.player.Player_Spell_Book.Spell_List[spell_book_index];
        GameManager.instance.player.Player_Spell_Book.Spell_List[spell_book_index] = GameManager.instance.player.Player_Spell_Inventory.Spell_Inventory[inventory_index];
        GameManager.instance.player.Player_Spell_Inventory.Spell_Inventory[inventory_index] = card;
    }

    public void Back()
    {
        GameManager.instance.current_state = GameManager.GameStates.MAIN;
        GameManager.instance.scene_loaded = false;
    }
}
