using UnityEngine;
using System.Collections;

public class Attack : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int dmg = s.Strength + Random.Range(0, 11);
        return new SpellResults(dmg, 0, 0, 0, 0, 0);
    }
}
