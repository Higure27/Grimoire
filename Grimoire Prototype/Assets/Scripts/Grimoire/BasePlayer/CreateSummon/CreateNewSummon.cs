using UnityEngine;
using System.Collections;

public class CreateNewSummon : MonoBehaviour 
{
	private BasePlayerSummon new_summon;
	private bool is_light;
	private bool is_dark;
	private string summon_name = "Enter Name";

	// Use this for initialization
	void Start () 
	{
		new_summon = new BasePlayerSummon();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		summon_name = GUILayout.TextArea(summon_name);
		is_light = GUILayout.Toggle(is_light, "Warrior of Light");
		is_dark = GUILayout.Toggle(is_dark, "Warrior of darkness");
		if(GUILayout.Button ("Create"))
		{
			if(is_light)
				new_summon.Summon_Class = new BaseLightSummon();
			else if (is_dark)
				new_summon.Summon_Class = new BaseDarkSummon();
			new_summon.Summon_Level = 1;
			new_summon.Strength = new_summon.Summon_Class.Strength;
			new_summon.Defense = new_summon.Summon_Class.Defense;
			new_summon.Health = new_summon.Summon_Class.Health;
			new_summon.Summon_Name = summon_name;
			Store_New_Player_Info();
			SaveInformation.Save_All_Information();

			Debug.Log("Summon Name: " + new_summon.Summon_Name);
			Debug.Log("Player Class: " + new_summon.Summon_Class.Summon_Class);
			Debug.Log("Player Level: " + new_summon.Summon_Level);
			Debug.Log("Player Strength: " + new_summon.Strength);
			Debug.Log("Player Health: " + new_summon.Health);
			Debug.Log("Player Defense: " + new_summon.Defense);

        }
    }

	private void Store_New_Player_Info()
	{
		GameInformation.player_summon = new_summon;
//		GameInformation.player_summon.Summon_Name = new_summon.Summon_Name;
//		GameInformation.player_summon.Summon_Level = new_summon.Summon_Level;
//		GameInformation.player_summon.Strength = new_summon.Strength;
//		GameInformation.player_summon.Defense = new_summon.Defense;
//		GameInformation.player_summon.Health = new_summon.Health;
	}
}
