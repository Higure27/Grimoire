using UnityEngine;
using System.Collections;

public class FinalStrike : BaseSpell
{
    public FinalStrike()
    {
        name = "Final Strike";
        description = "A devastating finishing strike to a combo";
        cost = 0;
        element_types.Add(Summon.Type.NONE);
        type = Spell_Types.ATTACK;
        Add_Ability(new ComboFinisher());
        strategy = Spell_Class.NONE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }
}
