using UnityEngine;
using System.Collections;

public class VampireSlash : Card 
{
	public VampireSlash()
	{
		Card_Name = "Vampire Slash";
		Card_Description = "Damages and steals life from enemy";
		Card_Cost = 4;
		Card_Type = CardTypes.ATTACK;
		AddAbility(new Absorb());
		AddAbility(new BasicAttack());
	}
}
