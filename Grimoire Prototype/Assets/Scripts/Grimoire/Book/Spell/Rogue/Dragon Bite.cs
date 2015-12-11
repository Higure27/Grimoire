using UnityEngine;
using System.Collections;

public class DragonBite : BaseSpell {

	public DragonBite()
	{
		name = "Dragon Bite";
		description = "A powerful attack that will also burn and steal health from the opponent ";
		cost = 8;
		element_types.Add(Summon.Type.DARK);
		element_types.Add (Summon.Type.FIRE);
		type = Spell_Types.ATTACK;
		Add_Ability(new Absorb());
		Add_Ability (new Burn ());
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