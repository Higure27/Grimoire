using UnityEngine;
using System.Collections;

public class Cure : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		p1.Burn = 0;
		p1.Poison = 0;
		p1.Paralyze = 0;
        damage = 0;
        block = 0;
        heal = 0;
        poison = 0;
        burn = 0;
        paralyze = 0;
	}
}
