using UnityEngine;
using System.Collections;

public class SaveInformation 
{
	public static void Save_All_Information()
	{
//		PlayerPrefs.SetString("PLAYERNAME", GameInformation.Player_Name);
//		PlayerPrefs.SetString ("SUMMONNAME", GameInformation.Summon_Name);
//		PlayerPrefs.SetInt("SUMMONLEVEL", GameInformation.Summon_Level);
//		PlayerPrefs.SetInt("STRENGTH", GameInformation.Strength);
//		PlayerPrefs.SetInt("DEFENSE", GameInformation.Defense);
//		PlayerPrefs.SetInt("HEALTH", GameInformation.Health);
		PlayerPrefSerialization.Save("PLAYERSUMMON", GameInformation.player_summon);
		Debug.Log("Saved All Information");
	}

}
