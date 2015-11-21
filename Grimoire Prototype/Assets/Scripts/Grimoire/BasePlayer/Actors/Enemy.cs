using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : BasePlayer 
{
	private List<BaseSpell> attack_spells;
	private List<BaseSpell> defense_spells;

	public Enemy()
	{
		Player_Name = "Warlock";
        Players_Summon = new Summon("Golem", 1, 0, 120, 10, 20, Summon.Type.EARTH);
		Player_Spell_Book = new SpellBook();

		// instead of having a spell book I want the enemy
		// to have 2 different lists of spells 
		// Attack spells and defense spells
		attack_spells = new List<BaseSpell>();
		attack_spells.Add (new FireStrike());
		attack_spells.Add (new FireStrike());
		attack_spells.Add (new PoisonStrike());
		attack_spells.Add (new PoisonStrike());
		attack_spells.Add (new DarkStrike());
		attack_spells.Add (new DarkStrike());

		defense_spells = new List<BaseSpell>();
		defense_spells.Add (new PoisonShield());
		defense_spells.Add (new PoisonShield());
		defense_spells.Add (new FireShield());
		defense_spells.Add (new FireShield());
	}

	public List<BaseSpell> Attack_Spells 
	{
		get { return attack_spells; }
	}
	public List<BaseSpell> Defense_Spells 
	{
		get { return defense_spells; }
	}
}



















