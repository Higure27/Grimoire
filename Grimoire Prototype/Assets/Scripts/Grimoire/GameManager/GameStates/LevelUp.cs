using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{

    private GameObject summon_container;
    private BasePlayer player;

    // Use this for initialization
    void Start ()
    {
        player = GameManager.instance.player;
        summon_container = GameObject.Find("Player_Summon_Container");
        Set_Font_Size();
        Load_Player_Summon();
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
    }

    private void Load_Player_Summon()
    {
        summon_container.GetComponentsInChildren<Text>()[0].text = player.Players_Summon.Name;
        summon_container.GetComponentsInChildren<Text>()[2].text = player.Players_Summon.Level.ToString();
        summon_container.GetComponentsInChildren<Text>()[4].text = player.Players_Summon.Base_Health.ToString();
        summon_container.GetComponentsInChildren<Text>()[6].text = player.Players_Summon.Strength.ToString();
        summon_container.GetComponentsInChildren<Text>()[8].text = player.Players_Summon.Defense.ToString();
        summon_container.GetComponentsInChildren<Text>()[10].text = player.Players_Summon.Curr_Exp + " / " + player.Players_Summon.Req_Exp;
        if (player.Players_Summon.Summon_Type == Summon.Type.DARK)
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Dark_Evo1");
        }
        else if (player.Players_Summon.Summon_Type == Summon.Type.EARTH)
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Earth_Evo1");
        }
        else if (player.Players_Summon.Summon_Type == Summon.Type.FIRE)
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Fire_Evo1");
        }
        else
        {
            summon_container.GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/Summon_Light_Evo1");
        }
    }
}
