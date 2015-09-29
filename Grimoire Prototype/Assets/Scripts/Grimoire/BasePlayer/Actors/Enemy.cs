using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : BasePlayer 
{
	private List<Card> attack_spells;
	private List<Card> defense_spells;

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

		// instead of having a spell book I want the enemy
		// to have 2 different lists of spells 
		// Attack spells and defense spells
		attack_spells = new List<Card>();
		attack_spells.Add (new BurnAttack());
		attack_spells.Add (new BurnAttack());
		attack_spells.Add (new DragonBite());
		attack_spells.Add (new DragonBite());
		attack_spells.Add (new Shriek());
		attack_spells.Add (new Shriek());

		defense_spells = new List<Card>();
		defense_spells.Add (new BurningShield());
		defense_spells.Add (new BurningShield());
		defense_spells.Add (new HealSelf());
		defense_spells.Add (new CureSelf());
	}

	public List<Card> Attack_Spells 
	{
		get { return attack_spells; }
	}
	public List<Card> Defense_Spells 
	{
		get { return defense_spells; }
	}
}



















