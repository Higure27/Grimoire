using UnityEngine;
using System.Collections;

public class DamageReflection : BaseSpell
{
    public DamageReflection()
    {
        name = "DamageReflection";
        description = "Unleashes and reflects stored damage";
        cost = 0;
        element_types.Add(Summon.Type.NONE);
        type = Spell_Types.ATTACK;
        Add_Ability(new ReflectFinisher());
        strategy = Spell_Class.NONE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

    public override void Cast_Spell(Summon s)
    {
        base.Cast_Spell(s);
        s.Reflect = 0;
    }
}
