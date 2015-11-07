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
        Players_Summon = new Summon("Golem", 1, 0, 120, 10, 20, Summon.Type.EARTH);
		Player_Spell_Book = new SpellBook();

		// instead of having a spell book I want the enemy
		// to have 2 different lists of spells 
		// Attack spells and defense spells
		attack_spells = new List<Card>();
		attack_spells.Add (new BurnAttack());
		attack_spells.Add (new BurnAttack());
		attack_spells.Add (new DragonBite());
		attack_spells.Add (new DragonBite());
		attack_spells.Add (new VampireSlash());
		attack_spells.Add (new ParalyzingGrasp());

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



















