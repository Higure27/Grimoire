using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBook 
{
	private List<BaseSpell> spell_list = new List<BaseSpell>();
	private List<BaseSpell> hand = new List<BaseSpell>();

    /*
     * Used once at beginning of battle to set up players hand
     */
	public void Draw_Hand()
	{
        hand.Add(spell_list[Random.Range(0, spell_list.Count)]);
        hand.Add(spell_list[Random.Range(0, spell_list.Count)]);
        hand.Add(spell_list[Random.Range(0, spell_list.Count)]);
        hand.Add(spell_list[Random.Range(0, spell_list.Count)]);
	}

    public void Draw_For_Turn()
    {
        hand.Add(spell_list[Random.Range(0, spell_list.Count)]);
        hand.Add(spell_list[Random.Range(0, spell_list.Count)]);
    }

    public void Discard(BaseSpell s)
    {
        hand.Remove(s);
    }

    public void Discard(int index)
    {
        hand.RemoveAt(index);
    }

	public void Add_Spell(BaseSpell s)
	{
		spell_list.Add(s);
	}

	public List<BaseSpell> Hand 
	{
		get { return hand; } 
	}

    public List<BaseSpell> Spell_List
    {
        get { return spell_list; }
    }
}
