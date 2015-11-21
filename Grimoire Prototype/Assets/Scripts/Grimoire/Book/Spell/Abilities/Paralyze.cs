using UnityEngine;
using System.Collections;

public class Paralyze : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int plz = Random.Range(1, 4);
        return new SpellResults(0, 0, 0, 0, 0, plz);
    }
}
