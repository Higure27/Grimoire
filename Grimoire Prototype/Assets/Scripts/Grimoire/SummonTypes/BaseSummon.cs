using UnityEngine;
using System.Collections;

public class BaseSummon 
{
	private string summon_class;
	private string summon_description;

	private int strength;
	private int defense;
	private int health;

	public string Summon_Class
	{
		get{ return summon_class; }
		set{ summon_class = value; }
	}

	public string Summon_Description 
	{
		get{ return summon_description; }
		set{ summon_description = value; }
	}

	public int Strength 
	{
		get{ return strength; }
		set{ strength = value; }
	}
	public int Defense 
	{
		get{ return defense; }
		set{ defense = value; }
	}
	public int Health 
	{
		get{ return health; }
		set{ health = value; }
	}
}
