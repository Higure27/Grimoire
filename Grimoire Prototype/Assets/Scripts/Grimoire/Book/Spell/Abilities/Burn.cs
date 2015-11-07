using UnityEngine;
using System.Collections;

public class Burn : BaseAbility 
{
	public void DoAbility(Summon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		burn = Random.Range(1, 4);
        damage = 0;
        block = 0;
        heal = 0;
        poison = 0;
        paralyze = 0;
	}
}
