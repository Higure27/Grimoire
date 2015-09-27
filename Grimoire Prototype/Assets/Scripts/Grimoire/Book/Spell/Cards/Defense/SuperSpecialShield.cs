using UnityEngine;
using System.Collections;

public class SuperSpecialShield : Card 
{
	public SuperSpecialShield()
	{
		Card_Name = "Super Special Shield";
		Card_Description = "This is really special";
		Card_Cost = 2;
		Card_Type = CardTypes.DEFENSE;
		AddAbility(new Paralyze());
		AddAbility(new BasicDefense());
		AddAbility(new Heal());
		AddAbility(new Cure());
	}
}
