using UnityEngine;
using System.Collections;

public class PoisonNeedle : BaseSpell {

	public PoisonNeedle()
	{
		name = "Poison Needle";
		description = "A Shield spell that will also poison your Opponent";
		cost = 3;
		element_types.Add(Summon.Type.EARTH);
		type = Spell_Types.DEFENSE;
		Add_Ability(new Block());
		Add_Ability(new Poison());
		strategy = Spell_Class.WARRIOR;
		strength_req = 0;
		defense_req = 0;
		health_req = 0;
	}
	
	public override void Cast_Spell(Summon s)
	{
		base.Cast_Spell (s);
	}
}