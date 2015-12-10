using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Tournament : MonoBehaviour
{
    public static Tournament instance;

    private List<BasePlayer> tournament_players;
    private List<string> tournament_players_names;

    private List<BasePlayer> tier_2_tournament_players;
    private int[] tier_1_losers;
    private int[] tier_2_loser;

    // GUI Elements
    public GameObject tier_1_player_1;
    public GameObject tier_1_player_2;
    public GameObject tier_1_player_3;
    public GameObject tier_1_player_4;

    public GameObject tier_2_player_1;
    public GameObject tier_2_player_2;

    public GameObject tier_3_player;

    public GameObject game_end_text;
    public GameObject next_battle_button;
    public GameObject return_button;

    public GameObject top_bracket;
    public GameObject bottom_bracket;
    public GameObject middle_bracket;


    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        if (instance == this)
        {
            Init();
        }
	}

    private void Init()
    {
		Set_Fonts ();
        tournament_players = new List<BasePlayer>();
        tournament_players_names = new List<string>();
        tier_2_tournament_players = new List<BasePlayer>();
        tier_2_player_1.SetActive(false);
        tier_2_player_2.SetActive(false);
        tier_3_player.SetActive(false);
        game_end_text.SetActive(false);
        Get_Players();
        Load_Players();
        GameManager.instance.tournament_mode = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Player_Won()
    {
        if(tier_1_losers == null)
        {
            tier_1_losers = new int[2];
            tier_1_losers[0] = 1;
            tier_1_losers[1] = UnityEngine.Random.Range(2, 4);
        }
        else if(tier_2_loser == null)
        {
            tier_2_loser = new int[1];
            tier_2_loser[0] = 1;
        }
    }

	private void Set_Fonts()
	{
		return_button.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.018f);
		next_battle_button.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.018f);
		game_end_text.GetComponent<Text>().fontSize = (int)(Screen.width * 0.018f);
		tier_1_player_1.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
		tier_1_player_2.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
		tier_1_player_3.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
		tier_1_player_4.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
		tier_2_player_1.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
		tier_2_player_2.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
		tier_3_player.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.012f);
	}

    public void Player_Lost()
    {
        if(tier_1_losers == null)
        {
            tier_1_losers = new int[2];
            tier_1_losers[0] = 0;
            tier_1_losers[1] = UnityEngine.Random.Range(2, 4);
        }
        else if(tier_2_loser == null)
        {
            tier_2_loser = new int[1];
            tier_2_loser[0] = 0;
        }
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log(level);
        if (level == 7 && instance == this)
        {
            Load_GameObjects();
            Load_Players();
        }
    }

    private void Load_GameObjects()
    {
        tier_1_player_1 = GameObject.Find("Tier_1_Player_1");
        tier_1_player_2 = GameObject.Find("Tier_1_Player_2");
        tier_1_player_3 = GameObject.Find("Tier_1_Player_3");
        tier_1_player_4 = GameObject.Find("Tier_1_Player_4");
        tier_2_player_1 = GameObject.Find("Tier_2_Player_1");
        tier_2_player_2 = GameObject.Find("Tier_2_Player_2");
        tier_3_player = GameObject.Find("Tier_3_Player");

        top_bracket = GameObject.Find("Top_Bracket");
        bottom_bracket = GameObject.Find("Bottom_Bracket");
        middle_bracket = GameObject.Find("Center_Bracket");

        game_end_text = GameObject.Find("Game_End");
        next_battle_button = GameObject.Find("Battle");
        return_button = GameObject.Find("Quit");

        if(game_end_text.activeSelf)
            game_end_text.SetActive(false);
        return_button.GetComponent<Button>().onClick.AddListener(() => { Quit(); });
        next_battle_button.GetComponent<Button>().onClick.AddListener(() => { Battle(); });
    }

    public void Battle()
    {
        if (tier_1_losers == null)
        {
            GameManager.instance.enemy = GameManager.instance.database.Load_Player(tournament_players[0].Player_Name);
        }
        else
        {
            GameManager.instance.enemy = tier_2_tournament_players[0];
        }
        GameManager.instance.current_state = GameManager.GameStates.BATTLE;
        GameManager.instance.scene_loaded = false;
    }

    public void Quit()
    {
        GameManager.instance.tournament_mode = false;
        GameManager.instance.current_state = GameManager.GameStates.MAIN;
        GameManager.instance.scene_loaded = false;
        Destroy(gameObject);
    }

    private void Get_Players()
    {
        while(tournament_players.Count < 4)
        {
            string p = GameManager.instance.database.Get_Random_User();
            if(!tournament_players_names.Contains(p) && p != GameManager.instance.player.Player_Name)
            {
                tournament_players_names.Add(p);
                tournament_players.Add(GameManager.instance.database.Load_Player(p));
            }
        }
    }

    private void Load_Players()
    {
        tier_1_player_1.GetComponentsInChildren<Text>()[0].text = GameManager.instance.player.Player_Name;
        tier_1_player_1.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(GameManager.instance.player);

        tier_1_player_2.GetComponentsInChildren<Text>()[0].text = tournament_players_names[0];
        tier_1_player_2.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tournament_players[0]);

        tier_1_player_3.GetComponentsInChildren<Text>()[0].text = tournament_players_names[1];
        tier_1_player_3.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tournament_players[1]);

        tier_1_player_4.GetComponentsInChildren<Text>()[0].text = tournament_players_names[2];
        tier_1_player_4.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tournament_players[2]);
        
        if(tier_1_losers != null)
        {
            List<GameObject> players = new List<GameObject> { tier_1_player_1, tier_1_player_2, tier_1_player_3, tier_1_player_4};
            players[tier_1_losers[0]].GetComponentsInChildren<Image>()[2].enabled = true;
            players[tier_1_losers[1]].GetComponentsInChildren<Image>()[2].enabled = true;

            if(tier_1_losers[0] == 0)
            {
                tier_2_player_1.GetComponentsInChildren<Text>()[0].text = tournament_players[0].Player_Name;
                tier_2_player_1.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tournament_players[0]);
                top_bracket.GetComponentsInChildren<Image>()[2].enabled = true;
                tier_2_tournament_players.Add(tournament_players[0]);
                game_end_text.SetActive(true);
                game_end_text.GetComponentsInChildren<Text>()[0].text = "YOU LOSE...";
                game_end_text.GetComponentsInChildren<Text>()[0].color = new UnityEngine.Color(255, 0, 0);
                next_battle_button.GetComponent<Button>().interactable = false;
            }
            else
            {
                tier_2_player_1.GetComponentsInChildren<Text>()[0].text = GameManager.instance.player.Player_Name;
                tier_2_player_1.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(GameManager.instance.player);
                top_bracket.GetComponentsInChildren<Image>()[1].enabled = true;
            }
            if(tier_1_losers[1] == 2)
            {
                tier_2_player_2.GetComponentsInChildren<Text>()[0].text = tournament_players[2].Player_Name;
                tier_2_player_2.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tournament_players[2]);
                bottom_bracket.GetComponentsInChildren<Image>()[2].enabled = true;
                tier_2_tournament_players.Add(tournament_players[2]);
            }
            else
            {
                tier_2_player_2.GetComponentsInChildren<Text>()[0].text = tournament_players[1].Player_Name;
                tier_2_player_2.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tournament_players[1]);
                bottom_bracket.GetComponentsInChildren<Image>()[1].enabled = true;
                tier_2_tournament_players.Add(tournament_players[1]);
            }
        }

        if(tier_2_loser != null)
        {
            List<GameObject> players = new List<GameObject> { tier_2_player_1, tier_2_player_2 };
            players[tier_2_loser[0]].GetComponentsInChildren<Image>()[2].enabled = true;
            
            if(tier_2_loser[0] == 1)
            {
                tier_3_player.GetComponentsInChildren<Text>()[0].text = GameManager.instance.player.Player_Name;
                tier_3_player.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(GameManager.instance.player);
                middle_bracket.GetComponentsInChildren<Image>()[1].enabled = true;
                game_end_text.SetActive(true);
                next_battle_button.GetComponent<Button>().interactable = false;
                return_button.GetComponentInChildren<Text>().text = "Return";
            }
            else
            {
                tier_3_player.GetComponentsInChildren<Text>()[0].text = tier_2_tournament_players[0].Player_Name;
                tier_3_player.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(tier_2_tournament_players[0]);
                middle_bracket.GetComponentsInChildren<Image>()[2].enabled = true;
                game_end_text.SetActive(true);
                game_end_text.GetComponentsInChildren<Text>()[0].text = "YOU LOSE...";
                game_end_text.GetComponentsInChildren<Text>()[0].color = new UnityEngine.Color(255, 0, 0);
                next_battle_button.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            tier_3_player.SetActive(false);
        }
    }

    private Sprite Get_Summon_Image(BasePlayer p)
    {
        if (p.Players_Summon.Summon_Type == Summon.Type.DARK)
        {
            if (p.Players_Summon.Stage == 1)
            {
                return Resources.Load<Sprite>("Sprites/static_vampire_1");
            }
            else
            {
                return Resources.Load<Sprite>("Sprites/Summon_Dark_Evo2");
            }
        }
        else if (p.Players_Summon.Summon_Type == Summon.Type.EARTH)
        {
            if (p.Players_Summon.Stage == 1)
            {
                return Resources.Load<Sprite>("Sprites/static_golem_1");
            }
            else
            {
                return Resources.Load<Sprite>("Sprites/Summon_Earth_Evo2");
            }
        }
        else if (p.Players_Summon.Summon_Type == Summon.Type.FIRE)
        {
            if (p.Players_Summon.Stage == 1)
            {
                return Resources.Load<Sprite>("Sprites/static_phoenix_1");
            }
            else
            {
                return Resources.Load<Sprite>("Sprites/Summon_Fire_Evo2");
            }
        }
        else if (p.Players_Summon.Summon_Type == Summon.Type.LIGHT)
        {
            if (p.Players_Summon.Stage == 1)
            {
                return Resources.Load<Sprite>("Sprites/static_paladin_1");
            }
            else
            {
                return Resources.Load<Sprite>("Sprites/Summon_Light_Evo2");
            }
        }
        return null;
    }
}
