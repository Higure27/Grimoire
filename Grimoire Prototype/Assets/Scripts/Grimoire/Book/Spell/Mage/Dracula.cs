using UnityEngine;
using System.Collections;

public class Dracula : BaseSpell {

	public Dracula()
	{
		name = "Dracula";
		description = "An attack that will also paralyze and steal health from your opponent";
		cost = 7;
		element_types.Add(Summon.Type.DARK);
		element_types.Add(Summon.Type.LIGHT);
		type = Spell_Types.ATTACK;
		Add_Ability(new Attack());
		Add_Ability(new Absorb());
		Add_Ability(new Paralyze());
		strategy = Spell_Class.MAGE;
		strength_req = 0;
		defense_req = 0;
		health_req = 0;
	}
	
	public override void Cast_Spell(Summon s)
	{
		base.Cast_Spell(s);
	}
}