using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{

    private GameObject summon_container;
    private GameObject point_distributer;
    private BasePlayer player;

    // Use this for initialization
    void Start ()
    {
        player = GameManager.instance.player;
        summon_container = GameObject.Find("Player_Summon_Container");
        point_distributer = GameObject.Find("Point_Distributer");
        Set_Font_Size();
        Load_Player_Summon();
        Disable_Decrement();
        if(player.Players_Summon.Stat_Points == 0)
        {
            Disable_Increment();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
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

        point_distributer.GetComponentsInChildren<Text>()[0].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[1].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[2].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[3].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[4].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[5].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[6].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[7].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[8].fontSize = (int)(Screen.width * 0.018f);
        point_distributer.GetComponentsInChildren<Text>()[9].fontSize = (int)(Screen.width * 0.018f);
    }

    private void Load_Player_Summon()
    {
        summon_container.GetComponentsInChildren<Text>()[0].text = player.Players_Summon.Name;
        summon_container.GetComponentsInChildren<Text>()[2].text = player.Players_Summon.Level.ToString();
        summon_container.GetComponentsInChildren<Text>()[4].text = player.Players_Summon.Base_Health.ToString();
        summon_container.GetComponentsInChildren<Text>()[6].text = player.Players_Summon.Strength.ToString();
        summon_container.GetComponentsInChildren<Text>()[8].text = player.Players_Summon.Defense.ToString();
        summon_container.GetComponentsInChildren<Text>()[10].text = player.Players_Summon.Curr_Exp + " / " + player.Players_Summon.Req_Exp;

        summon_container.GetComponentsInChildren<Image>()[1].sprite = Get_Summon_Image(player);

        point_distributer.GetComponentsInChildren<Text>()[1].text = player.Players_Summon.Stat_Points.ToString();
    }

    private Sprite Get_Summon_Image(BasePlayer p)
    {
        if (p.Players_Summon.Summon_Type == Summon.Type.DARK)
        {
            if (p.Players_Summon.Stage == 1)
            {
                return Resources.Load<Sprite>("Sprites/menu_vampire");
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
                return Resources.Load<Sprite>("Sprites/menu_golem");
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
                return Resources.Load<Sprite>("Sprites/menu_phoenix");
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
                return Resources.Load<Sprite>("Sprites/menu_paladin");
            }
            else
            {
                return Resources.Load<Sprite>("Sprites/Summon_Light_Evo2");
            }
        }
        return null;
    }

    public void Back()
    {
        GameManager.instance.current_state = GameManager.GameStates.MAIN;
        GameManager.instance.scene_loaded = false;
    }

    private void Disable_Increment()
    {
        point_distributer.GetComponentsInChildren<Button>()[1].interactable = false;
        point_distributer.GetComponentsInChildren<Button>()[3].interactable = false;
        point_distributer.GetComponentsInChildren<Button>()[5].interactable = false;
    }

    private void Enable_Increment()
    {
        point_distributer.GetComponentsInChildren<Button>()[1].interactable = true;
        point_distributer.GetComponentsInChildren<Button>()[3].interactable = true;
        point_distributer.GetComponentsInChildren<Button>()[5].interactable = true;
    }

    private void Disable_Decrement()
    {
        point_distributer.GetComponentsInChildren<Button>()[0].interactable = false;
        point_distributer.GetComponentsInChildren<Button>()[2].interactable = false;
        point_distributer.GetComponentsInChildren<Button>()[4].interactable = false;
    }

    private void Enable_Decrement()
    {
        point_distributer.GetComponentsInChildren<Button>()[0].interactable = true;
        point_distributer.GetComponentsInChildren<Button>()[2].interactable = true;
        point_distributer.GetComponentsInChildren<Button>()[4].interactable = true;
    }

    public void Increment_Health()
    {
        point_distributer.GetComponentsInChildren<Text>()[1].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[1].text) - 1).ToString();
        point_distributer.GetComponentsInChildren<Text>()[3].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[3].text) + 1).ToString();
        point_distributer.GetComponentsInChildren<Button>()[0].interactable = true;

        player.Players_Summon.Stat_Points--;
        player.Players_Summon.Health += 5;
        player.Players_Summon.Base_Health += 5;

        summon_container.GetComponentsInChildren<Text>()[4].text = (int.Parse(summon_container.GetComponentsInChildren<Text>()[4].text) + 5).ToString();

        if(player.Players_Summon.Stat_Points == 0)
        {
            Disable_Increment();
        }
    }

    public void Decrement_Health()
    {
        point_distributer.GetComponentsInChildren<Text>()[1].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[1].text) + 1).ToString();
        point_distributer.GetComponentsInChildren<Text>()[3].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[3].text) - 1).ToString();
        Enable_Increment();

        player.Players_Summon.Stat_Points++;
        player.Players_Summon.Health -= 5;
        player.Players_Summon.Base_Health -= 5;

        summon_container.GetComponentsInChildren<Text>()[4].text = (int.Parse(summon_container.GetComponentsInChildren<Text>()[4].text) - 5).ToString();

        if(point_distributer.GetComponentsInChildren<Text>()[3].text == "0")
        {
            point_distributer.GetComponentsInChildren<Button>()[0].interactable = false;
        }
    }

    public void Increment_Strength()
    {
        point_distributer.GetComponentsInChildren<Text>()[1].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[1].text) - 1).ToString();
        point_distributer.GetComponentsInChildren<Text>()[5].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[5].text) + 1).ToString();
        point_distributer.GetComponentsInChildren<Button>()[2].interactable = true;

        player.Players_Summon.Stat_Points--;
        player.Players_Summon.Strength++;

        summon_container.GetComponentsInChildren<Text>()[6].text = (int.Parse(summon_container.GetComponentsInChildren<Text>()[6].text) + 1).ToString();

        if (player.Players_Summon.Stat_Points == 0)
        {
            Disable_Increment();
        }
    }

    public void Decrement_Strength()
    {
        point_distributer.GetComponentsInChildren<Text>()[1].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[1].text) + 1).ToString();
        point_distributer.GetComponentsInChildren<Text>()[5].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[5].text) - 1).ToString();
        Enable_Increment();

        player.Players_Summon.Stat_Points++;
        player.Players_Summon.Strength--;

        summon_container.GetComponentsInChildren<Text>()[6].text = (int.Parse(summon_container.GetComponentsInChildren<Text>()[6].text) - 1).ToString();

        if (point_distributer.GetComponentsInChildren<Text>()[5].text == "0")
        {
            point_distributer.GetComponentsInChildren<Button>()[2].interactable = false;
        }

    }

    public void Increment_Defense()
    {
        point_distributer.GetComponentsInChildren<Text>()[1].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[1].text) - 1).ToString();
        point_distributer.GetComponentsInChildren<Text>()[7].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[7].text) + 1).ToString();
        point_distributer.GetComponentsInChildren<Button>()[4].interactable = true;

        player.Players_Summon.Stat_Points--;
        player.Players_Summon.Defense++;

        summon_container.GetComponentsInChildren<Text>()[8].text = (int.Parse(summon_container.GetComponentsInChildren<Text>()[8].text) + 1).ToString();

        if (player.Players_Summon.Stat_Points == 0)
        {
            Disable_Increment();
        }
    }

    public void Decrement_Defense()
    {
        point_distributer.GetComponentsInChildren<Text>()[1].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[1].text) + 1).ToString();
        point_distributer.GetComponentsInChildren<Text>()[7].text = (int.Parse(point_distributer.GetComponentsInChildren<Text>()[7].text) - 1).ToString();
        Enable_Increment();

        player.Players_Summon.Stat_Points++;
        player.Players_Summon.Defense--;

        summon_container.GetComponentsInChildren<Text>()[8].text = (int.Parse(summon_container.GetComponentsInChildren<Text>()[8].text) - 1).ToString();

        if (point_distributer.GetComponentsInChildren<Text>()[7].text == "0")
        {
            point_distributer.GetComponentsInChildren<Button>()[4].interactable = false;
        }

    }

}
