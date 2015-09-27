using UnityEngine;
using System.Collections;

public class Shield : Card 
{
	public Shield()
	{
		Card_Name = "Shield";
		Card_Description = "Basic defense that charges the next defense";
		Card_Cost = 0;
		Card_Type = CardTypes.DEFENSE;
		AddAbility(new BasicDefense());
	}
}
