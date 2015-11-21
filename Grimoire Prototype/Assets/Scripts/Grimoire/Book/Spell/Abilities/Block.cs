using UnityEngine;
using System.Collections;

public class Block : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int blk = s.Defense + Random.Range(0, 11);
        return new SpellResults(0, blk, 0, 0, 0, 0);
    }
}
