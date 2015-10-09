using UnityEngine;
using System.Collections;

public class Poison : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		poison = Random.Range(2, 6);
        damage = 0;
        heal = 0;
        block = 0;
        burn = 0;
        paralyze = 0;
	}
}
