using UnityEngine;
using System.Collections;

public class PoisonAttack : Card 
{
	public PoisonAttack()
	{
		Card_Name = "Poison Attack";
		Card_Description = "An attack that will poison the enemy";
		Card_Cost = 4;
		Card_Type = CardTypes.ATTACK;
		AddAbility(new Poison());
		AddAbility(new BasicAttack());
	}
}