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
		AddAbility(new Cure());
	}
}
