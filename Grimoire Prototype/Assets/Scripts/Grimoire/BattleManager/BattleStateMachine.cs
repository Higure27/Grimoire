using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleStateMachine : MonoBehaviour 
{
	// Contains player and enemy data
	private BattleStateStart player_info = new BattleStateStart();

	// Make Draw_Spells function is only called once
	private bool drew_for_turn = false;

	// Enemy AI variables
	private bool attack_boost = false;
	private bool defense_boost = false;

	// Variable that prevents player or enemy from defending twice in a row
	private bool player_defend = false;
	private bool enemy_defend = false;

	// Two Spells that will be displayed to user
	private Card spell_1;
	private Card spell_2;
	private Card slash = new Slash();
	private Card shield = new Shield();

	// Spell buttons which are displayed
	public GameObject spell_button_1;
	public GameObject spell_button_2;
	public GameObject basic_attack;
	public GameObject basic_defense;

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
		current_state = BattleStates.START;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (current_state) 
		{
		case (BattleStates.START) :
			current_state = BattleStates.PLAYERCHOICE;
			break;
		case (BattleStates.PLAYERCHOICE) :
			// Draw a new page and display options
			if(!drew_for_turn)
			{
				drew_for_turn = true;
				Draw_Spells();
				Display_Spells();
			}
			break;
		case (BattleStates.ENEMYCHOICE) :
			// coded AI goes here
			Enemy_Cast();
			break;
		case (BattleStates.RESULTS) :
			// display result of player and enemy choice to user
			Display_Results();
			break;
		case (BattleStates.LOSE) :
			// display lose message, maybe play again
			break;
		case (BattleStates.WIN) :
			// display win message, maybe play again
			break;
		}
	}

	/* Game State Functions */

	/* Player Functions Start */
	/*
	 * Draw two new spells from book to display to user
	 * set private spell_1 and spell_2 to these new spells
	 * for easy access later.
	 */
	private void Draw_Spells()
	{
		player_info.player.Player_Spell_Book.DrawHand();
		spell_1 = player_info.player.Player_Spell_Book.Hand[0];
		spell_2 = player_info.player.Player_Spell_Book.Hand[1];
	}

	/*
	 * Display the spell options to the player
	 */
	private void Display_Spells()
	{
		if(player_defend)
		{
			if(spell_1.Card_Type == Card.CardTypes.DEFENSE)
			{
				//disable button 1
			}
			if(spell_2.Card_Type == Card.CardTypes.DEFENSE)
			{
				//disable button 2
			}
			player_defend = false;
		}
		// TODO: Set the text and information on spell buttons 
	}

	/*
	 * Casts the spell that the user chooses
	 * @param spell = the button which is pressed
	 */
	public void Cast_Spell(string spell)
	{
		switch (spell)
		{
		case("spell_1") :
			if(spell_1.Card_Type == Card.CardTypes.DEFENSE)
				player_defend = true;
			spell_1.CastSpell(player_info.player.Players_Summon, player_info.enemy.Players_Summon);
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;
			break;
		case("spell_2") :
			if(spell_1.Card_Type == Card.CardTypes.DEFENSE)
				player_defend = true;
			spell_2.CastSpell(player_info.player.Players_Summon, player_info.enemy.Players_Summon);
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;
			break;
		case("basic_attack") :
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;
			slash.CastSpell(player_info.player.Players_Summon, player_info.enemy.Players_Summon);
			player_info.player.Players_Summon.Attack_Boost = true;
			break;
		case("basic_defense") :
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;;
			shield.CastSpell(player_info.player.Players_Summon, player_info.enemy.Players_Summon);
			player_info.player.Players_Summon.Defense_Boost = true;
			break;
		}
		// After player makes their choice enemy will make their choice
		current_state = BattleStates.ENEMYCHOICE;
	}

	/* Player Functions End */

	/* Enemy Functions Start */

	/*
	 * Bulk of enemy AI in enemy choice
	 */
	public void Enemy_Cast()
	{
		if(attack_boost && Random.Range(0, 101) <= 80)
		{
			// Cast attack spell
			attack_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			return;
		}

		if(defense_boost && Random.Range(0, 101) <= 80)
		{
			// Cast defense spell
			defense_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			return; 
		}

		int random_number = Random.Range(0, 101);
		// 30% chance to do a basic attack
		if (random_number <= 30)
		{
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			slash.CastSpell(player_info.enemy.Players_Summon, player_info.player.Players_Summon);
			player_info.enemy.Players_Summon.Attack_Boost = true;
			attack_boost = true;
		}
		// 30% chance to do a basic defense
		else if (random_number > 30 && random_number <= 60)
		{
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			shield.CastSpell(player_info.enemy.Players_Summon, player_info.player.Players_Summon);
			player_info.enemy.Players_Summon.Defense_Boost = true;
			defense_boost = true;
		}
		// 20% chance to do a attack spell
		else if (random_number > 60 && random_number <= 80)
		{
			// grab a random attack spell from enemies list and cast it.
			attack_boost = false;
			defense_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
		}
		// 20% chance to do a defense spell
		else
		{
			// grab a random defense spell from enemies list and cast it.
			attack_boost = false;
			defense_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
		}

		current_state = BattleStates.RESULTS;
	}
	/* Enemy Functions End */

	/* Results Functions Start */

	/*
	 * Changes the UI to reflect the results of the
	 * Player and enemy choices
	 */
	private void Display_Results()
	{
		// health bar decreases/increases for both players depending
		// Text log updated with enemy attack and player attack

		if(player_info.player.Players_Summon.Health <= 0)
		{
			current_state = BattleStates.LOSE;
			return;
		}
		if(player_info.enemy.Players_Summon.Health <= 0)
		{
			current_state = BattleStates.WIN;
			return;
		}

		current_state = BattleStates.PLAYERCHOICE;
	}

	/* Results Functions End */
}










































