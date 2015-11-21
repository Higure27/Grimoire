using UnityEngine;
using System.Collections;

public class FireShield : BaseSpell
{
    public FireShield()
    {
        name = "Fire Shield";
        description = "A burning shield that can store damage";
        cost = 0;
        element_types.Add(Summon.Type.FIRE);
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
        if(Random.Range(0, 101) > 90)
        {
            results += new Burn().Do_Ability(s);
        }
    }
}
