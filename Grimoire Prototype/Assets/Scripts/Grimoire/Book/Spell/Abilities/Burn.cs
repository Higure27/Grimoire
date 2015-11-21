using UnityEngine;
using System.Collections;

public class Burn : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int brn = Random.Range(1, 5);
        return new SpellResults(0, 0, 0, 0, brn, 0);
    }
}
