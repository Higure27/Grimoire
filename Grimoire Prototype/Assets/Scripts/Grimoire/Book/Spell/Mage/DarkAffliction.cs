using UnityEngine;
using System.Collections;

public class DarkAffliction : BaseSpell
{
    public DarkAffliction()
    {
        name = "Dark Affliction";
        description = "A demonic curse that can cause great affliction";
        cost = 0;
        element_types.Add(Summon.Type.DARK);
        type = Spell_Types.ATTACK;
        Add_Ability(new Absorb());
        strategy = Spell_Class.MAGE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

    public override void Cast_Spell(Summon s)
    {
        base.Cast_Spell(s);
        if (Random.Range(0, 101) > 50)
        {
            results += new Burn().Do_Ability(s);
        }
        if (Random.Range(0, 101) > 50)
        {
            results += new Poison().Do_Ability(s);
        }
    }
}
