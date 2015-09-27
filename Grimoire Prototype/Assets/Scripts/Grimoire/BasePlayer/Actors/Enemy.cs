using UnityEngine;
using System.Collections;

public class Enemy : BasePlayer 
{
	public Enemy()
	{
		Player_Name = "Warlock";
		Players_Summon = new BasePlayerSummon();
		Player_Spell_Book = new SpellBook();

		// Set up enemy summon
		Players_Summon.Summon_Name = "Dark Kight";
		Players_Summon.Summon_Level = 1;
		Players_Summon.Summon_Class = new BaseDarkSummon();
		Players_Summon.Strength = Players_Summon.Summon_Class.Strength;
		Players_Summon.Defense = Players_Summon.Summon_Class.Defense;
		Players_Summon.Health = Players_Summon.Summon_Class.Health;
		Players_Summon.Burn = 0;
		Players_Summon.Poison = 0;
		Players_Summon.Paralyze = 0;
		Players_Summon.Attack_Boost = false;
		Players_Summon.Defense_Boost = false;
		GameInformation.enemy_summon = Players_Summon;

		// Add 10 - 20 spells to spell book

		// instead of having a spell book I want the enemy
		// to have 2 different lists of spells 
		// Attack spells and defense spells
	}
}
