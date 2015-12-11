using UnityEngine;
using System.Collections;

public class Bright : BaseSpell {

	public Bright()
	{
		name = "Bright";
		description = "A Shield spell that will heal your summon and paralyze your Opponent";
		cost = 5;
		element_types.Add(Summon.Type.LIGHT);
		type = Spell_Types.DEFENSE;
		Add_Ability(new Block());
		Add_Ability(new Paralyze());
		Add_Ability(new Heal());
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