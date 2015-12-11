using UnityEngine;
using System.Collections;

public class Cross : BaseSpell {

	public Cross()
	{
		name = "Cross";
		description = "A Shield spell that will also burn and paralyze your Opponent";
		cost = 5;
		element_types.Add(Summon.Type.LIGHT);
		element_types.Add (Summon.Type.FIRE);
		type = Spell_Types.DEFENSE;
		Add_Ability(new Block());
		Add_Ability(new Paralyze());
		Add_Ability(new Burn());
		strategy = Spell_Class.WARRIOR;
		strength_req = 0;
		defense_req = 0;
		health_req = 0;
	}
	
	public override void Cast_Spell(Summon s)
	{
		base.Cast_Spell (s);
	}
}