using UnityEngine;
using System.Collections;

public class Paralyze : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		p2.Paralyze = Random.Range(2, 4);
	}
}
