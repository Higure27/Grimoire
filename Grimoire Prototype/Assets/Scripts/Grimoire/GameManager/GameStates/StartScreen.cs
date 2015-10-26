using UnityEngine;
using System.Collections;
using System.Xml;
using UnityEngine.UI;
using System.IO;

public class StartScreen : MonoBehaviour
{
    public GameObject user_name;
    private int font_size;
    private GameObject login;
    private GameObject new_user;

    void Start()
    {
        font_size = (int)(Screen.width * 0.018f);
        login = GameObject.Find("Start");
        new_user = GameObject.Find("NewUser");
        login.GetComponentInChildren<Text>().fontSize = font_size;
        new_user.GetComponentInChildren<Text>().fontSize = font_size;
        user_name.GetComponentsInChildren<Text>()[0].fontSize = font_size;
        user_name.GetComponentsInChildren<Text>()[1].fontSize = font_size;
    }

    public void Game_Start()
    {
        GameManager.instance.current_state = GameManager.GameStates.MAIN;
        GameManager.instance.scene_loaded = false;
    }

    public void Login()
    {
        string user = user_name.GetComponentsInChildren<Text>()[1].text;
        user = user.Trim().ToLower().Replace(" ", string.Empty);
        if (user == null || user == "")
        {
            return;
        }

        if(!GameManager.instance.database.User_Exists(user))
        {
            return;
        }
        GameManager.instance.database.Load_Player(user);

        Game_Start();
    }

    public void New_User()
    {
        GameManager.instance.current_state = GameManager.GameStates.CREATE;
        GameManager.instance.scene_loaded = false;
    }
}
