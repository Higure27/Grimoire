using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private int font_size;
    private GameObject start_battle;
    private GameObject edit_spell_book;
    private GameObject exit;
    private GameObject summon;
    public GameObject summon_container;
    private BasePlayer player;

    void Start()
    {
        player = GameManager.instance.player;
        font_size = (int)(Screen.width * 0.018f);
        start_battle = GameObject.Find("StartBattle");
        edit_spell_book = GameObject.Find("EditSpellBook");
        exit = GameObject.Find("Exit");
        summon = GameObject.Find("Summon");
        start_battle.GetComponentInChildren<Text>().fontSize = font_size;
        edit_spell_book.GetComponentInChildren<Text>().fontSize = font_size;
        exit.GetComponentInChildren<Text>().fontSize = font_size;
        summon.GetComponentInChildren<Text>().fontSize = font_size;
        Set_Font_Size();
        Load_Player_Summon();
    }

    private void Set_Font_Size()
    {
        summon_container.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[1].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[2].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[3].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[4].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[5].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[6].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[7].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[8].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[9].fontSize = (int)(Screen.width * 0.018f);
        summon_container.GetComponentsInChildren<Text>()[10].fontSize = (int)(Screen.width * 0.018f);
    }

    private void Load_Player_Summon()
    {
        summon_container.GetComponentsInChildren<Text>()[0].text = player.Players_Summon.Name;
        summon_container.GetComponentsInChildren<Text>()[2].text = player.Players_Summon.Level.ToString();
        summon_container.GetComponentsInChildren<Text>()[4].text = player.Players_Summon.Base_Health.ToString();
        summon_container.GetComponentsInChildren<Text>()[6].text = player.Players_Summon.Strength.ToString();
        summon_container.GetComponentsInChildren<Text>()[8].text = player.Players_Summon.Defense.ToString();
        summon_container.GetComponentsInChildren<Text>()[10].text = player.Players_Summon.Curr_Exp + " / " + player.Players_Summon.Req_Exp;
        if(player.Players_Summon.Summon_Type == Summon.Type.DARK)
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Dark_Evo1");
        }
        else if(player.Players_Summon.Summon_Type == Summon.Type.EARTH)
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Earth_Evo1");
        }
        else if(player.Players_Summon.Summon_Type == Summon.Type.FIRE)
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Fire_Evo1");
        }
        else
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Light_Evo1");
        }
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

    public void Edit_Summon()
    {
        GameManager.instance.current_state = GameManager.GameStates.SUMMON;
        GameManager.instance.scene_loaded = false;
    }
}
