﻿using UnityEngine;
using System.Collections;

public class VampireSlash : BaseSpell {

	public VampireSlash()
	{
		name = "Vampire Slash";
		description = "A strong attack that will also steal health from the opponent";
		cost = 5;
		element_types.Add(Summon.Type.DARK);
		type = Spell_Types.ATTACK;
		Add_Ability(new Absorb());
		Add_Ability(new Attack());
		strategy = Spell_Class.ROGUE;
		strength_req = 0;
		defense_req = 0;
		health_req = 0;
	}
	
	public override void Cast_Spell(Summon s)
	{
		base.Cast_Spell(s);
	}
}