using UnityEngine;
using System.Collections;

public class Poison : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		p2.Poison = true;
	}
}
