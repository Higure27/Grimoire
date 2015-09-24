using UnityEngine;
using System.Collections;

public class BattleGUI : MonoBehaviour 
{
//	private string summon_name;
//	private int summon_level;
//	private int summon_health;

	// Use this for initialization
	void Start () 
	{
//		summon_name = GameInformation.player_summon.Summon_Name;
//		summon_level = GameInformation.player_summon.Summon_Level;
//		summon_health = GameInformation.player_summon.Health;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnGUI()
	{
		// buttons for player spells
		if(BattleStateMachine.current_state == BattleStateMachine.BattleStates.PLAYERCHOICE)
		{
			DisplayPlayersChoice();
		}
		// show enemy health
		// show player information

	}

	private void DisplayPlayersChoice()
	{
//		if(GUI.Button(new Rect(Screen.width - 200,Screen.height - 50, 100, 30), GameInformation.player_spell_one.Spell_Name))
//		{
//			// calculate damage to enemy
//			BattleStateMachine.current_state = BattleStateMachine.BattleStates.ENEMYCHOICE;
//		}
//		if(GUI.Button(new Rect(Screen.width - 100, Screen.height - 50, 100, 30), GameInformation.player_spell_two.Spell_Name))
//		{
//			// calculate block
//			BattleStateMachine.current_state = BattleStateMachine.BattleStates.ENEMYCHOICE;
//		}
	}
}
