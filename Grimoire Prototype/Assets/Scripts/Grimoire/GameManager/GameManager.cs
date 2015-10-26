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
        BOOK
    }

    public static GameManager instance = null;
    public GameStates current_state = GameStates.START;
    public BasePlayer player;
    public GrimoireDatabase database = new GrimoireDatabase();

    // Makes sure each scene only loads once
    public bool scene_loaded = false;


	// Use this for initialization
	void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
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
                    Application.LoadLevel("battle_scene");
                    scene_loaded = true;
                }
                break;
        }
	}
}
