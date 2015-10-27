using UnityEngine;
using System.Collections;

public class VampireSlash : Card 
{
	public VampireSlash()
	{
		Card_Name = "Vampire Slash";
		Card_Description = "Damages and steals life from enemy";
		Card_Cost = 4;
		Card_Type = CardTypes.ATTACK;
		Card_Tier = Tier.TIER1;
		ResetBattleAttributes();
		AddAbility(new Absorb());
		AddAbility(new BasicAttack());
        Icon_Vampire = true;
	}
}
