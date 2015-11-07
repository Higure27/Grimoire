using UnityEngine;
using System.Collections;

public class BasicDefense : BaseAbility 
{
	public void DoAbility(Summon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		block = Random.Range(0, 7);
		block += p1.Defense;
		if(p1.Defense_Boost)
		{
			block += p1.Defense/2;
		}
        damage = 0;
        heal = 0;
        poison = 0;
        burn = 0;
        paralyze = 0;
	}
}
