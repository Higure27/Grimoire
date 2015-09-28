using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook 
{
	private List<Card> spell_list = new List<Card>();
	private List<Card> hand;

	public void DrawHand()
	{
		List<Card> draw_new = new List<Card>();
		draw_new.Add(spell_list[Random.Range (0, spell_list.Count)]);
		draw_new.Add(spell_list[Random.Range (0, spell_list.Count)]);
		hand = draw_new;
	}

	public void AddSpell(Card c)
	{
		spell_list.Add(c);
	}

	public List<Card> Hand 
	{
		get { return hand; } 
		set { hand = value;}
	}
}
