using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook 
{
	private List<Card> spell_list = new List<Card>();

	public List<Card> DrawHand()
	{
		List<Card> hand = new List<Card>();
		hand.Add(spell_list[Random.Range (0, spell_list.Count)]);
		hand.Add(spell_list[Random.Range (0, spell_list.Count)]);
		return hand;
	}

	public void AddSpell(Card c)
	{
		spell_list.Add(c);
	}
}
