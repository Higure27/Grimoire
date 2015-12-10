using UnityEngine;
using System.Collections;

public class VampireShield : BaseSpell {

	public VampireShield()
	{
		name = "Vampire Shield";
		description = "A Shield spell that will also steal health from your Opponent";
		cost = 3;
		element_types.Add(Summon.Type.DARK);
		type = Spell_Types.DEFENSE;
		Add_Ability(new Block());
		Add_Ability(new Absorb());
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