using UnityEngine;
using System.Collections;

public class BattleStateMachine : MonoBehaviour 
{
	//private bool has_added_exp = false;
	private BattleStateStart battle_state_start_script = new BattleStateStart();

	public enum BattleStates 
	{
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		RESULTS,
		LOSE,
		WIN,
	}

	public static BattleStates current_state;

	// For initialization
	void Start () 
	{
		battle_state_start_script.PrepareBattle();
		current_state = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (current_state) 
		{
		case (BattleStates.START) :
			// Setup Battle Functions
			// create enemy
			// might do this on load instead of update()...
//			battle_state_start_script.PrepareBattle();
			current_state = BattleStates.PLAYERCHOICE;
			break;
		case (BattleStates.PLAYERCHOICE) :
			// player choice functions
			break;
		case (BattleStates.ENEMYCHOICE) :
			// coded AI goes here
			break;
		case (BattleStates.RESULTS) :
			// display result of player and enemy choice to user
			break;
		case (BattleStates.LOSE) :
			// display lose message, maybe play again
			break;
		case (BattleStates.WIN) :
			// display win message, maybe play again
			break;
		}
	}

	void OnGUI()
	{
		if (GUILayout.Button ("Next State")) {
			if(current_state == BattleStates.START)
				current_state = BattleStates.PLAYERCHOICE;
		}
	}
}
