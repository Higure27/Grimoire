using UnityEngine;
using System.Collections;

public class CurseFinisher : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int heal = s.Base_Health / 10 + s.Curse * 5;
        SpellResults r = new SpellResults(0, 0, heal, 0, 0, 0);
        //if (Random.Range(0, 101) > 80)
            r += new Burn().Do_Ability(s);
        //if (Random.Range(0, 101) > 80)
            r += new Poison().Do_Ability(s);
        return r;
    }
}
