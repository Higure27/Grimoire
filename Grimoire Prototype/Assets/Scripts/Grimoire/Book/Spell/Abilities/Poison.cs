using UnityEngine;
using System.Collections;

public class Poison : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int psn = Random.Range(1, 6);
        return new SpellResults(0, 0, 0, psn, 0, 0);
    }
}
