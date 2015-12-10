using UnityEngine;
using System.Collections;

public class PoisonAttack : BaseSpell {

	public PoisonAttack()
	{
		name = "Poison Attack";
		description = "A strong attack that will also poison the opponent";
		cost = 5;
		element_types.Add(Summon.Type.EARTH);
		type = Spell_Types.ATTACK;
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