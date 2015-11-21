using UnityEngine;
using System.Collections;

public class DarkShield : BaseSpell
{
    public DarkShield()
    {
        name = "Dark Shield";
        description = "A demonic shield that can store damage";
        cost = 0;
        element_types.Add(Summon.Type.DARK);
        type = Spell_Types.DEFENSE;
        Add_Ability(new Block());
        strategy = Spell_Class.WARRIOR;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

    public override void Cast_Spell(Summon s)
    {
        base.Cast_Spell(s);
        if (Random.Range(0, 101) > 90)
        {
            results += new Absorb().Do_Ability(s);
        }
    }
}
