using UnityEngine;
using System.Collections;

/*
 * A Combo Attack with a chance to burn
 */
public class FireStrike : BaseSpell
{
    public FireStrike()
    {
        name = "Fire Strike";
        description = "A fast fiery attack that can be used in a combo";
        cost = 0;
        element_types.Add(Summon.Type.FIRE);
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
        // 10% chance to burn
        if(Random.Range(0, 101) > 90)
        {
            results += new Burn().Do_Ability(s);
        }
    }
}
