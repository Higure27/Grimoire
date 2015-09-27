using UnityEngine;
using System.Collections;

public class PoisonNeedle : Card 
{
	public PoisonNeedle()
	{
		Card_Name = "Poison Needle";
		Card_Description = "Block with a spiny poisonous shield";
		Card_Cost = 2;
		Card_Type = CardTypes.DEFENSE;
		AddAbility(new BasicDefense());
		AddAbility(new Poison());
	}
}
