using UnityEngine;
using System.Collections;

public class BasicDefense : BaseAbility 
{
	public void DoAbility (BasePlayerSummon p1, BasePlayerSummon p2)
	{
		int base_block = Random.Range(0, 7);
		base_block += p1.Defense;
		p1.Health += base_block;
	}
}
