using UnityEngine;
using System.Collections;

public class Heal : BaseAbility 
{
	public void DoAbility(Summon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		heal = p1.Base_Health/10 + Random.Range(5, 11);
		if(p1.Defense_Boost)
		{
            heal += Random.Range(10, 21);
		}
        damage = 0;
        block = 0;
        poison = 0;
        burn = 0;
        paralyze = 0;
	}
}
