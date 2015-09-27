using UnityEngine;
using System.Collections;

public class HealSelf : Card 
{
	public HealSelf()
	{
		Card_Name = "Heal";
		Card_Description = "Heals your summon";
		Card_Cost = 0;
		Card_Type = CardTypes.DEFENSE;
		AddAbility(new Heal());
	}
}
