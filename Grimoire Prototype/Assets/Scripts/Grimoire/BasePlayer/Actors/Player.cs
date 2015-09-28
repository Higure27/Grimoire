using UnityEngine;
using System.Collections;

public class Player : BasePlayer 
{
	public Player()
	{
		Player_Name = "McLovin";
		Players_Summon = new BasePlayerSummon();;
		Player_Spell_Book = new SpellBook();

		// Set up Player Summon
		Players_Summon.Summon_Name = "Paladin";
		Players_Summon.Summon_Level = 1;
		Players_Summon.Summon_Class = new BaseLightSummon();
		Players_Summon.Strength = Players_Summon.Summon_Class.Strength;
		Players_Summon.Defense = Players_Summon.Summon_Class.Defense;
		Players_Summon.Health = Players_Summon.Summon_Class.Health;
		Players_Summon.Burn = 0;
		Players_Summon.Poison = 0;
		Players_Summon.Paralyze = 0;
		Players_Summon.Attack_Boost = false;
		Players_Summon.Defense_Boost = false;
		GameInformation.player_summon = Players_Summon;

		// Add a 10 - 20 spells to the spell book
		Player_Spell_Book.AddSpell(new BurnAttack());
		Player_Spell_Book.AddSpell(new BurnAttack());
		Player_Spell_Book.AddSpell(new VampireSlash());
		Player_Spell_Book.AddSpell(new VampireSlash());
		Player_Spell_Book.AddSpell(new ParalyzingGrasp());
		Player_Spell_Book.AddSpell(new ParalyzingGrasp());
		Player_Spell_Book.AddSpell(new VampiricShield());
		Player_Spell_Book.AddSpell(new CureSelf());
		Player_Spell_Book.AddSpell(new HealSelf());
		Player_Spell_Book.AddSpell(new PoisonNeedle());
	}
}
