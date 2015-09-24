using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class BasePlayer 
{
	private string player_name;
	private BasePlayerSummon players_summon;

	public List<BaseSpell> player_spells = new List<BaseSpell>();

	public string Player_Name {get; set;}
	public BasePlayerSummon Players_Summon {get; set;}

}
