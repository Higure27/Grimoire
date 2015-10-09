using UnityEngine;
using System.Collections;

public class BurnAttack : Card 
{
	public BurnAttack()
	{
		Card_Name = "Burn Attack";
		Card_Description = "An attack that will burn the enemy";
		Card_Cost = 4;
		Card_Type = CardTypes.ATTACK;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Burn());
		AddAbility(new BasicAttack());
	}
}
