using UnityEngine;
using System.Collections;

public class Heal : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int heal = s.Base_Health / 10 + Random.Range(0, 11);
        return new SpellResults(0, 0, heal, 0, 0, 0);
    }
}
