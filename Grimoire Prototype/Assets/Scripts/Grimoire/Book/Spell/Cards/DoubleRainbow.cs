using UnityEngine;
using System.Collections;

public class DoubleRainbow : Card 
{
	public DoubleRainbow()
	{
		Card_Name = "Double Rainbow";
		Card_Description = "All the way across the sky";
		Card_Cost = 10;
		Card_Type = CardTypes.ATTACK;
		AddAbility(new Poison());
		AddAbility(new Burn());
		AddAbility(new Paralyze());
	}
}
