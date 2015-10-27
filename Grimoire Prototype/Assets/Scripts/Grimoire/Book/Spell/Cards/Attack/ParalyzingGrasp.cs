using UnityEngine;
using System.Collections;

public class ParalyzingGrasp : Card 
{
	public ParalyzingGrasp()
	{
		Card_Name = "Paralyzing Grasp";
		Card_Description = "An attack that will paralyze the enemy";
		Card_Cost = 4;
		Card_Type = CardTypes.ATTACK;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Paralyze());
		AddAbility(new BasicAttack());
        Icon_Paralyze = true;
	}
}
