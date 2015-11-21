using UnityEngine;
using System.Collections;

public class Absorb : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int dmg = s.Strength / 2 + Random.Range(0, 9);
        return new SpellResults(dmg, 0, dmg, 0, 0, 0);
    }
}
