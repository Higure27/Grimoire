using UnityEngine;
using System.Collections;

public class ToxicFire : BaseSpell {

	public ToxicFire()
	{
		name = "Toxic Fire";
		description = "A poisoning curse with a burning sensation";
		cost = 5;
		element_types.Add(Summon.Type.EARTH);
		element_types.Add(Summon.Type.FIRE);
		type = Spell_Types.ATTACK;
		Add_Ability(new Poison());
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
