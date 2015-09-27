using UnityEngine;
using System.Collections;

public class Heal : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		int hp = p1.Health + Random.Range(10, 21);
		if(hp > p1.Summon_Class.Health)
		{
			p1.Health = p1.Summon_Class.Health;
		}
		p1.Health = hp;
	}
}
