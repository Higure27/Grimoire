using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card 
{
	public enum CardTypes
	{
		ATTACK,
		DEFENSE
	}
	private string card_name;
	private string card_description;
	private List<BaseAbility> abilities = new List<BaseAbility>();
	private int card_cost;
	private CardTypes card_type;
	
	public string Card_Name {get;set;}
	public string Card_Description {get;set;}
	public int Card_Cost {get;set;}
	public CardTypes Card_Type {get;set;}

	public void AddAbility(BaseAbility a)
	{
		abilities.Add(a);
	}

	public void CastSpell(BasePlayerSummon p1, BasePlayerSummon p2)
	{
		Debug.Log ("Before: " + p1.Health);
		p1.Health -= Card_Cost;
		Debug.Log ("After: " + p1.Health);
		foreach(BaseAbility a in abilities)
		{
			a.DoAbility(p1, p2);
		}
	}
}
