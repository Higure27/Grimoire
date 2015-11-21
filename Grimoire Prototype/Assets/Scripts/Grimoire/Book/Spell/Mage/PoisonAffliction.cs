using UnityEngine;
using System.Collections;

public class PoisonAffliction : BaseSpell
{
    public PoisonAffliction()
    {
        name = "Poison Affliction";
        description = "A poisoning curse that can cause great affliction";
        cost = 0;
        element_types.Add(Summon.Type.EARTH);
        type = Spell_Types.ATTACK;
        Add_Ability(new Poison());
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
            results += new Block().Do_Ability(s);
        }
    }
}
