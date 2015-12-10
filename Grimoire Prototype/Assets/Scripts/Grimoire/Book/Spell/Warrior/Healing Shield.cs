using UnityEngine;
using System.Collections;

public class HealingShield : BaseSpell {

	public HealingShield()
	{
		name = "Healing Shield";
		description = "A Shield spell that will also heal your summon";
		cost = 2;
		element_types.Add(Summon.Type.LIGHT);
		type = Spell_Types.DEFENSE;
		Add_Ability(new Block());
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