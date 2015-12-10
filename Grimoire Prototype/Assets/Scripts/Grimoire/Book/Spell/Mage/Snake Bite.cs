using UnityEngine;
using System.Collections;

public class SnakeBite : BaseSpell {

	public SnakeBite()
	{
		name = "Snake Bite";
		description = "Poison your opponet as well as steal their health";
		cost = 5;
		element_types.Add(Summon.Type.EARTH);
		element_types.Add(Summon.Type.DARK);
		type = Spell_Types.ATTACK;
		Add_Ability(new Poison());
		Add_Ability(new Absorb());
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