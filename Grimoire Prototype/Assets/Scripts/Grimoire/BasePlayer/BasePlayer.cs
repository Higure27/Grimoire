using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class BasePlayer 
{
	private string player_name;
	private BasePlayerSummon players_summon;
	private SpellBook player_spell_book;
    private SpellInventory player_spell_inventory;

	public string Player_Name {get; set;}
	public BasePlayerSummon Players_Summon {get; set;}
	public SpellBook Player_Spell_Book {get; set;}
    public SpellInventory Player_Spell_Inventory { get; set; }
}
