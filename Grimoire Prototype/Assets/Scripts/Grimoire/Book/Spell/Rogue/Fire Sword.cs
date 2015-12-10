using UnityEngine;
using System.Collections;

public class FireSword : BaseSpell {

	public FireSword()
	{
		name = "Fire Sword";
		description = "A strong attack that will also burn the opponent";
		cost = 5;
		element_types.Add(Summon.Type.FIRE);
		type = Spell_Types.ATTACK;
		Add_Ability(new Burn());
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
