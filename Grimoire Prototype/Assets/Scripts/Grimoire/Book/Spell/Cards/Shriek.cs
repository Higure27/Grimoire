using UnityEngine;
using System.Collections;

public class Shriek : Card 
{
	public Shriek()
	{
		Card_Name = "Shriek";
		Card_Description = "A paralyzing scream";
		Card_Cost = 2;
		Card_Type = CardTypes.ATTACK;
		AddAbility(new Paralyze());
	}
}
