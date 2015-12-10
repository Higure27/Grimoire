using UnityEngine;
using System.Collections;

public class GreatAffliction : BaseSpell
{
    public GreatAffliction()
    {
        name = "Great Affliction";
        description = "A crushing curse that Heals you and curses your opponent";
        cost = 0;
        element_types.Add(Summon.Type.NONE);
        type = Spell_Types.ATTACK;
        Add_Ability(new CurseFinisher());
        strategy = Spell_Class.NONE;
        strength_req = 0;
        defense_req = 0;
        health_req = 0;
    }

    public override void Cast_Spell(Summon s)
    {
        base.Cast_Spell(s);
        s.Curse = 0;
    }
}
