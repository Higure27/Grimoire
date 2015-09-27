using UnityEngine;
using System.Collections;

public class GlaringShield : Card 
{
	public GlaringShield()
	{
		Card_Name = "Glaring Shield";
		Card_Description = "Blind your enemy with your shield";
		Card_Cost = 2;
		Card_Type = CardTypes.DEFENSE;
		AddAbility(new BasicDefense());
		AddAbility(new Paralyze());
	}
}
