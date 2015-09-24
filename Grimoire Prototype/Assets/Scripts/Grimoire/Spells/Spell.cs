using UnityEngine;
using System.Collections;

public class Spell 
{
	private string spell_name;
	private string spell_description;
	private int spell_id;
	public enum SpellTypes 
	{
		ATTACK,
		DEFENSE
	}
	private SpellTypes spell_type;

	public string Spell_Name 
	{
		get { return spell_name; }
		set { spell_name = value; }
	}

	public string Spell_Description 
	{
		get { return spell_description; }
		set { spell_description = value; }
	}

	public int Spell_id
	{
		get { return spell_id; }
		set { spell_id = value; }
	}

	public SpellTypes SpellType
	{
		get { return spell_type; }
		set { spell_type = value; }
	}
}
