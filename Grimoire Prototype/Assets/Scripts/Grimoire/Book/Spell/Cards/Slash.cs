using UnityEngine;
using System.Collections;

public class Slash : Card 
{
	public Slash()
	{
		Card_Name = "Slash";
		Card_Description = "A basic attack that charges the next attack";
		Card_Cost = 0;
		AddAbility(new BasicAttack());
	}
}
