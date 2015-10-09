using UnityEngine;
using System.Collections;

public class VampiricShield : Card 
{
	public VampiricShield()
	{
		Card_Name = "Vampire Shield";
		Card_Description = "Absorb life while defending";
		Card_Cost = 2;
		Card_Type = CardTypes.DEFENSE;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new BasicDefense());
		AddAbility(new Absorb());
	}
}
