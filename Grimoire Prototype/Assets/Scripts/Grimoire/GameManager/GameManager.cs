using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum GameStates
    {
        START,
        CREATE,
        MAIN,
        BATTLE,
        BOOK,
        SUMMON,
        TOURNAMENT,
        TUTORIAL
    }

    public static GameManager instance;
    public GameStates current_state;
    public BasePlayer player;
    public GrimoireDatabase database;

    public BasePlayer enemy;

    // Makes sure each scene only loads once
    public bool scene_loaded;

    // Tournament Mode
    public bool tournament_mode;


	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        current_state = GameStates.START;
        database = new GrimoireDatabase();
        DontDestroyOnLoad(gameObject);
        scene_loaded = false;
        tournament_mode = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    switch (current_state)
        {
            case GameStates.START:
                if (!scene_loaded)
                {
                    Application.LoadLevel("start_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.CREATE:
                if(!scene_loaded)
                {
                    Application.LoadLevel("create_user_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.MAIN:
                if(!scene_loaded)
                {
                    Application.LoadLevel("menu_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.BOOK:
                if(!scene_loaded)
                {
                    Application.LoadLevel("edit_book_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.BATTLE:
                if(!scene_loaded)
                {
                    Load_Enemy();
                    Application.LoadLevel("battle_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.SUMMON:
                if(!scene_loaded)
                {
                    Application.LoadLevel("level_up_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.TOURNAMENT:
                if(!scene_loaded)
                {
                    Application.LoadLevel("tournament_scene");
                    scene_loaded = true;
                }
                break;
            case GameStates.TUTORIAL:
                if(!scene_loaded)
                {
                    Application.LoadLevel("tutorial_scene");
                    scene_loaded = true;
                }
                break;
        }
	}

    private void Load_Enemy()
    {
        if (enemy != null)
        {
            return;
        }
        while (enemy == null)
        {
            string enemy_name = database.Get_Random_User();
            if (enemy_name != player.Player_Name)
            {
                enemy = database.Load_Player(enemy_name);
            }
        }
    }
}
