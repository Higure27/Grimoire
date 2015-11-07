using UnityEngine;
using System.Collections;

public class BasicAttack : BaseAbility 
{
	public void DoAbility(Summon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		damage = Random.Range(0, 7);
		damage += p1.Strength;
		if(p1.Attack_Boost)
		{
			damage += p1.Strength/2;
		}
        block = 0;
        heal = 0;
        poison = 0;
        burn = 0;
        paralyze = 0;
	}
}
