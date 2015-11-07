using UnityEngine;
using System.Collections;

public class Absorb : BaseAbility 
{
	public void DoAbility(Summon p1, out int damage, out int block, out int heal, out int poison, out int burn, out int paralyze)
    {
        damage = p1.Strength;
        heal = p1.Strength;
        block = 0;
        poison = 0;
        burn = 0;
        paralyze = 0;
	}
}
