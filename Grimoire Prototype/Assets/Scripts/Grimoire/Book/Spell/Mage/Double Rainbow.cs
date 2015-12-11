using UnityEngine;
using System.Collections;

public class DoubleRainbow : BaseSpell {

	public DoubleRainbow()
	{
		name = "Double Rainbow";
		description = "A spell that will burn, poison and paralyze your opponent";
		cost = 8;
		element_types.Add(Summon.Type.FIRE);
		element_types.Add(Summon.Type.EARTH);
		element_types.Add(Summon.Type.LIGHT);
		type = Spell_Types.ATTACK;
		Add_Ability(new Burn());
		Add_Ability(new Poison());
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