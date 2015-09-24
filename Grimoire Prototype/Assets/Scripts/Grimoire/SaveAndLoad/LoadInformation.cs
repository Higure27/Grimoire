using UnityEngine;
using System.Collections;

public class LoadInformation 
{
	public static void Load_All_Information() 
	{
//		GameInformation.Player_Name = PlayerPrefs.GetString("PLAYERNAME");
//		GameInformation.Summon_Name = PlayerPrefs.GetString("SUMMONNAME");
//		GameInformation.Summon_Level = PlayerPrefs.GetInt("SUMMONLEVEL");
//		GameInformation.Strength = PlayerPrefs.GetInt("STRENGTH");
//		GameInformation.Defense = PlayerPrefs.GetInt("DEFENSE");
//		GameInformation.Health = PlayerPrefs.GetInt("HEALTH");
		PlayerPrefSerialization.Load("PLAYERSUMMON");
	}
}
