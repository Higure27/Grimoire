using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int font_size;
    private GameObject start_battle;
    private GameObject edit_spell_book;
    private GameObject exit;

    void Start()
    {
        font_size = (int)(Screen.width * 0.018f);
        start_battle = GameObject.Find("StartBattle");
        edit_spell_book = GameObject.Find("EditSpellBook");
        exit = GameObject.Find("Exit");
        start_battle.GetComponentInChildren<Text>().fontSize = font_size;
        edit_spell_book.GetComponentInChildren<Text>().fontSize = font_size;
        exit.GetComponentInChildren<Text>().fontSize = font_size;
    }

    public void Start_Battle()
    {
        GameManager.instance.current_state = GameManager.GameStates.BATTLE;
        GameManager.instance.scene_loaded = false;
    }

    public void Edit_Spell_Book()
    {
        GameManager.instance.current_state = GameManager.GameStates.BOOK;
        GameManager.instance.scene_loaded = false;
    }

    public void Exit()
    {
        GameManager.instance.database.Save_Player(GameManager.instance.player.Player_Name, GameManager.instance.player);
        GameManager.instance.current_state = GameManager.GameStates.START;
        GameManager.instance.scene_loaded = false;
    }
}
