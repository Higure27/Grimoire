using UnityEngine;
using System.Collections;

public class FireAffliction : BaseSpell
{
    public FireAffliction()
    {
        name = "Fire Affliction";
        description = "A burning curse that can cause great affliction";
        cost = 0;
        element_types.Add(Summon.Type.FIRE);
        type = Spell_Types.ATTACK;
        Add_Ability(new Burn());
        strategy = Spell_Class.MAGE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

    public override void Cast_Spell(Summon s)
    {
        base.Cast_Spell(s);
        if (Random.Range(0, 101) > 90)
        {
            results += new Attack().Do_Ability(s);
        }
    }
}
