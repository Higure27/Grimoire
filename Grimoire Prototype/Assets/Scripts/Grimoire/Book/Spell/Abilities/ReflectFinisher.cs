using UnityEngine;
using System.Collections;

public class ReflectFinisher : Ability
{
    public SpellResults Do_Ability(Summon s)
    {
        int dmg = s.Reflect;
        return new SpellResults(dmg, 0, 0, 0, 0, 0);
    }
}
