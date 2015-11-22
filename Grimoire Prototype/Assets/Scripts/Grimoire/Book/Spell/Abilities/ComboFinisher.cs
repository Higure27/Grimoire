using UnityEngine;
using System.Collections;

public class ComboFinisher : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int dmg = (s.Strength + Random.Range(0, 6))* s.Combo;
        return new SpellResults(dmg, 0, 0, 0, 0, 0);
    }
}
