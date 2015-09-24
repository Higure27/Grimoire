using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameInformation : MonoBehaviour 
{
	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}

	//public static List<BaseSpell> player_spells;

//	public static string Player_Name {get; set;}
//	public static string Summon_Name {get; set;}
//	public static int Summon_Level {get; set;}
//	public static BaseSummon Summon_Class {get; set;}
//	public static int Strength {get; set;}
//	public static int Defense {get; set;}
//	public static int Health {get; set;}
//	public static int Current_EXP {get; set;}
//	public static int Required_EXP {get; set;}
	public static BasePlayer player {get;set;}
	public static BasePlayerSummon player_summon {get;set;}

	public static BasePlayerSummon enemy_summon {get;set;}
	
}
