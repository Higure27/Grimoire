using UnityEngine;
using System.Collections;

[System.Serializable]
public class BasePlayerSummon 
{
	private string summon_name;
	private int summon_level;
	private BaseSummon summon_class;
	private int strength;
	private int defense;
	private int health;
	private int current_exp;
	private int required_exp;

	// Battle Stats
	private int burn;
	private int poison;
	private int paralyze;
	private bool attack_boost;
	private bool defense_boost;

	public int Burn {get; set;}
	public int Poison {get; set;}
	public int Paralyze {get; set;}
	public bool Attack_Boost {get; set;}
	public bool Defense_Boost {get; set;}

	public int Current_EXP {get; set;}
	public int Required_EXP {get; set;}


	public string Summon_Name 
	{
		get { return summon_name; }
		set { summon_name = value; }
	}

	public int Summon_Level 
	{
		get { return summon_level; }
		set { summon_level = value; }
	}

	public BaseSummon Summon_Class
	{
		get { return summon_class; }
		set { summon_class = value; }
	}

	public int Strength
	{
		get { return strength; }
		set { strength = value; }
	}

	public int Defense
	{
		get { return defense; }
		set { defense = value; }
	}

	public int Health
	{
		get { return health; }
		set { health = value; }
	}


}
