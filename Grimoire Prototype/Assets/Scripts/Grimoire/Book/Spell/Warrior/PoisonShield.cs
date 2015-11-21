using UnityEngine;
using System.Collections;

public class PoisonShield : BaseSpell
{
    public PoisonShield()
    {
        name = "Poison Shield";
        description = "A poisonous shield that can store damage";
        cost = 0;
        element_types.Add(Summon.Type.EARTH);
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
            results += new Poison().Do_Ability(s);
        }
    }
}
