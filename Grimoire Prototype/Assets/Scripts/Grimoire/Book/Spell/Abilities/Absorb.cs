using UnityEngine;
using System.Collections;

public class Absorb : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{ 
		int hp = p1.Health + p1.Strength;
		if(hp > p1.Summon_Class.Health)
		{
			p1.Health = p1.Summon_Class.Health;
		}
		p1.Health += p1.Strength;
		p2.Health -= p1.Strength;
	}
}
