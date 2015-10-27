using UnityEngine;
using System.Collections;

public class CureSelf : Card 
{
	public CureSelf()
	{
		Card_Name = "Cure";
		Card_Description = "Cure status ailments";
		Card_Cost = 0;
		Card_Type = CardTypes.DEFENSE;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Cure());
        Icon_Cure = true;
	}
}
