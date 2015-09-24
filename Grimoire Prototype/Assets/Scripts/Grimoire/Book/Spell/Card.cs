using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card 
{
	private string card_name;
	private string card_description;
	private List<BaseAbility> abilities = new List<BaseAbility>();
	private int card_cost;
	
	public string Card_Name {get;set;}
	public string Card_Description {get;set;}
	public int Card_Cost {get;set;}

	public void AddAbility(BaseAbility a)
	{
		abilities.Add(a);
	}

	public void CastSpell(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		p1.Health -= card_cost;
		foreach(BaseAbility a in abilities)
		{
			a.DoAbility(p1, p2);
		}
	}
}
