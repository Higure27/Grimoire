using UnityEngine;
using System.Collections;

public class LightStrike : BaseSpell
{
    public LightStrike()
    {
        name = "Light Strike";
        description = "A fast holy attack that can be used in a combo";
        cost = 0;
        element_types.Add(Summon.Type.LIGHT);
        type = Spell_Types.ATTACK;
        Add_Ability(new Attack());
        strategy = Spell_Class.ROGUE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

    public override void Cast_Spell(Summon s)
    {
        base.Cast_Spell(s);
        // 10% chance to Heal
        if (Random.Range(0, 101) > 90)
        {
            results += new Heal().Do_Ability(s);
        }
    }
}
