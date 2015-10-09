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
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Poison());
		AddAbility(new Burn());
		AddAbility(new Paralyze());
	}
}
