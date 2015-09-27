using UnityEngine;
using System.Collections;

public class BasicAttack : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		int base_damage = Random.Range(0, 7);
		base_damage += p1.Strength;
		if(p1.Attack_Boost)
		{
			base_damage += p1.Strength/2;
		}
		p2.Health -= base_damage;
	}
}
