using UnityEngine;
using System.Collections;

public class BurningShield : Card 
{
	public BurningShield()
	{
		Card_Name = "Burning Shield";
		Card_Description = "Block with a fiery shield";
		Card_Cost = 2;
		Card_Type = CardTypes.DEFENSE;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Burn());
		AddAbility(new BasicDefense());
	}
}
