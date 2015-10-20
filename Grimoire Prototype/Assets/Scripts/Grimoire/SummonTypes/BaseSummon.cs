using UnityEngine;
using System.Collections;

public class BaseSummon 
{
    public enum Type
    {
        LIGHT,
        DARK,
        FIRE,
        EARTH
    }

	private string summon_class;
	private string summon_description;
    private Type summon_type;

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

    public Type Summon_Type
    {
        get { return summon_type; }
        set { summon_type = value; }
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
