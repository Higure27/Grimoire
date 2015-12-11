using UnityEngine;
using System.Collections;

public class Grim : BaseSpell {

	public Grim()
	{
		name = "Grim";
		description = "An Attack that will burn and poison your opponent as well";
		cost = 8;
		element_types.Add(Summon.Type.FIRE);
		element_types.Add(Summon.Type.EARTH);
		type = Spell_Types.ATTACK;
		Add_Ability(new Burn());
		Add_Ability(new Poison());
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