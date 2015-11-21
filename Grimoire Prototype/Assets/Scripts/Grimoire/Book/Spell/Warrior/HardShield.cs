using UnityEngine;
using System.Collections;

public class HardShield : BaseSpell
{
    public HardShield()
    {
        name = "Hard Shield";
        description = "A solid defense that can store damage";
        cost = 0;
        element_types.Add(Summon.Type.NONE);
        type = Spell_Types.DEFENSE;
        Add_Ability(new Block());
        strategy = Spell_Class.WARRIOR;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }
}
