using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;
using System.IO;

public class StartScreen : MonoBehaviour
{
    public GameObject user_name;

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

        //// Setup Player
        //GameManager.instance.player = new BasePlayer();
        //GameManager.instance.player.Player_Name = user;
        //GameManager.instance.player.Player_Spell_Book = new SpellBook();
        //GameManager.instance.player.Players_Summon = new BasePlayerSummon();
        //// Setup Players Summon
        //GameManager.instance.player.Players_Summon.Summon_Name = "Paladin";
        //GameManager.instance.player.Players_Summon.Summon_Level = 1;
        //GameManager.instance.player.Players_Summon.Summon_Class = new BaseLightSummon();
        //GameManager.instance.player.Players_Summon.Strength = GameManager.instance.player.Players_Summon.Summon_Class.Strength;
        //GameManager.instance.player.Players_Summon.Defense = GameManager.instance.player.Players_Summon.Summon_Class.Defense;
        //GameManager.instance.player.Players_Summon.Health = GameManager.instance.player.Players_Summon.Summon_Class.Health;
        //GameManager.instance.player.Players_Summon.Burn = 0;
        //GameManager.instance.player.Players_Summon.Poison = 0;
        //GameManager.instance.player.Players_Summon.Paralyze = 0;
        //GameManager.instance.player.Players_Summon.Attack_Boost = false;
        //GameManager.instance.player.Players_Summon.Defense_Boost = false;

        GameManager.instance.database.Load_Player(user);

        Game_Start();
    }
}
