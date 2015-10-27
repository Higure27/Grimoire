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
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Heal());
        Icon_Heal = true;
	}
}
