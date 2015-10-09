using UnityEngine;
using System.Collections;

public class DragonBite : Card 
{
	public DragonBite()
	{
		Card_Name = "Dragon Bite";
		Card_Description = "A burning vampiric bite";
		Card_Cost = 6;
		Card_Type = CardTypes.ATTACK;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Absorb());
		AddAbility(new Burn());
		AddAbility(new BasicAttack());
	}
}
