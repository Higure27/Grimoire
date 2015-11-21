using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellInventory
{
    private List<BaseSpell> spell_inventory = new List<BaseSpell>();

    public void Add_Spell(BaseSpell c)
    {
        spell_inventory.Add(c);
    }

    public List<BaseSpell> Spell_Inventory
    {
        get { return spell_inventory; }
    }
}
