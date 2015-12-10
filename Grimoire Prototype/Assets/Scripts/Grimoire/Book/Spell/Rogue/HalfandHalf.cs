using UnityEngine;
using System.Collections;

public class HalfandHalf : BaseSpell {

	public HalfandHalf()
	{
		name = "Half and Half";
		description = "A strong attack that will also heal your summon";
		cost = 5;
		element_types.Add(Summon.Type.LIGHT);
		type = Spell_Types.ATTACK;
		Add_Ability(new Heal());
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