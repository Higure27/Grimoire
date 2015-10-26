using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellInventory
{
    private List<Card> spell_inventory = new List<Card>();

    public void AddSpell(Card c)
    {
        spell_inventory.Add(c);
    }

    public List<Card> Spell_Inventory
    {
        get { return spell_inventory; }
    }
}
