using UnityEngine;
using System.Collections;

public interface BaseAbility 
{
    void DoAbility(BasePlayerSummon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze);
}
