using UnityEngine;
using System.Collections;

public class DarkStrike : BaseSpell
{
    public DarkStrike()
    {
        name = "Dark Strike";
        description = "A fast sinister attack that can be used in a combo";
        cost = 0;
        element_types.Add(Summon.Type.DARK);
        type = Spell_Types.ATTACK;
        Add_Ability(new Absorb());
        strategy = Spell_Class.ROGUE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }
}
