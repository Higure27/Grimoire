using UnityEngine;
using System.Collections;

public class Lightning : BaseSpell {

	public Lightning()
	{
		name = "Lightning";
		description = "A paralyzing spell that will also burn your opponent";
		cost = 5;
		element_types.Add(Summon.Type.FIRE);
		element_types.Add(Summon.Type.LIGHT);
		type = Spell_Types.ATTACK;
		Add_Ability(new Paralyze());
		Add_Ability(new Burn());
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
