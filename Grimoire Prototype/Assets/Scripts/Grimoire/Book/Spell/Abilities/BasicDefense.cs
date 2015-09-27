using UnityEngine;
using System.Collections;

public class BasicDefense : BaseAbility 
{
	public void DoAbility (BasePlayerSummon p1, BasePlayerSummon p2)
	{
		int base_block = Random.Range(0, 7);
		base_block += p1.Defense;
		if(p1.Defense_Boost)
		{
			base_block += p1.Defense/2;
		}
		p1.Health += base_block;
	}
}
