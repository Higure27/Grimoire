using UnityEngine;
using System.Collections;

public class Burn : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		p2.Burn = Random.Range(1, 4);
	}
}
