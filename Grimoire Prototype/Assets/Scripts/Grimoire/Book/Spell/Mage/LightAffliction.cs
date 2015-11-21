using UnityEngine;
using System.Collections;

public class LightAffliction : BaseSpell
{
    public LightAffliction()
    {
        name = "Light Affliction";
        description = "A holy curse that can cause great affliction";
        cost = 0;
        element_types.Add(Summon.Type.LIGHT);
        type = Spell_Types.ATTACK;
        Add_Ability(new Paralyze());
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
            results += new Heal().Do_Ability(s);
        }
    }
}
