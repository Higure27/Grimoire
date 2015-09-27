using UnityEngine;
using System.Collections;

public class Cure : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		p1.Burn = 0;
		p1.Poison = 0;
		p1.Paralyze = 0;
	}
}
