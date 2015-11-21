using UnityEngine;
using System.Collections;

public class QuickStrike : BaseSpell
{
    public QuickStrike()
    {
        name = "Quick Strike";
        description = "A fast attack that can be used in a combo";
        cost = 0;
        element_types.Add(Summon.Type.NONE);
        type = Spell_Types.ATTACK;
        Add_Ability(new Attack());
        strategy = Spell_Class.ROGUE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

}
