using UnityEngine;
using System.Collections;

public class ScorpionSting : BaseSpell {

	public ScorpionSting()
		{
		name = "Scorpion Sting";
			description = "A poisoning curse with a paralyzing sting";
			cost = 5;
			element_types.Add(Summon.Type.EARTH);
			element_types.Add(Summon.Type.LIGHT);
			type = Spell_Types.ATTACK;
			Add_Ability(new Poison());
			Add_Ability(new Paralyze());
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
