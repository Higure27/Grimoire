using UnityEngine;
using System.Collections;

public class Paralyze : BaseAbility 
{
	public void DoAbility(BasePlayerSummon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
		paralyze = Random.Range(2, 4);
        damage = 0;
        block = 0;
        heal = 0;
        poison = 0;
        burn = 0;
        paralyze = 0;
	}
}
