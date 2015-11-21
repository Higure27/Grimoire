using UnityEngine;
using System.Collections;

public class ComboFinisher : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int dmg = s.Strength * s.Combo;
        return new SpellResults(dmg, 0, 0, 0, 0, 0);
    }
}
