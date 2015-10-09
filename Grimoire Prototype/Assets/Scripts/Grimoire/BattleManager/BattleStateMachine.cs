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

    // Player and Enemy chosen Spells
    private Card player_spell;
    private Card Enemy_spell;

	// Battle Log
	private string player_log;
	private string enemy_log;

	// UI logs
	public GameObject player_UI_log;
	public GameObject enemy_UI_log;

	// Actor Health 
	public GameObject player_hp;
	public GameObject enemy_hp;

	// Win/Lose Text
	public GameObject win;
	public GameObject lose;

	// Spell buttons which are displayed
	public GameObject spell_button_1;
	public GameObject spell_button_2;
	public GameObject basic_attack;
	public GameObject basic_defense;

	// Health bars which are displayed
	public GameObject player_hp_bar;
	public GameObject enemy_hp_bar;

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
		win.SetActive(false);
		lose.SetActive(false);
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
				if(player_info.player.Players_Summon.Poison > 0)
				{
					Debug.Log ("HP before poison: " + player_info.player.Players_Summon.Health);
					player_info.player.Players_Summon.Poison--;
					player_info.player.Players_Summon.Health -= 5;
					Debug.Log ("HP After poison: " + player_info.player.Players_Summon.Health);
				}
				if(player_info.player.Players_Summon.Burn > 0)
				{
					Debug.Log ("HP before Burn: " + player_info.player.Players_Summon.Health);
					player_info.player.Players_Summon.Burn--;
					player_info.player.Players_Summon.Health -= 8;
					Debug.Log ("HP After Burn: " + player_info.player.Players_Summon.Health);
				}
				if(player_info.player.Players_Summon.Paralyze > 0)
				{
					player_info.player.Players_Summon.Paralyze--;
					if(Random.Range(1, 101) < 60)
					{
						player_log = "You are paralyzed";
						return;
					}
				}
				Draw_Spells();
				Display_Spells();
			}
			break;
		case (BattleStates.ENEMYCHOICE) :
			if(player_info.enemy.Players_Summon.Poison > 0)
			{
				player_info.enemy.Players_Summon.Poison--;
				player_info.enemy.Players_Summon.Health -= 5;
			}
			if(player_info.enemy.Players_Summon.Burn > 0)
			{
				player_info.enemy.Players_Summon.Burn--;
				player_info.enemy.Players_Summon.Health -= 8;
			}
			if(player_info.enemy.Players_Summon.Paralyze > 0)
			{
				player_info.enemy.Players_Summon.Paralyze--;
				if(Random.Range(1, 101) < 60)
				{
					enemy_log = "Enemy is paralyzed";
					break;
				}
			}
			Enemy_Cast();
			break;
		case (BattleStates.RESULTS) :
			// display result of player and enemy choice to user
			Display_Results();
			drew_for_turn = false;
			break;
		case (BattleStates.LOSE) :
			lose.SetActive(true);
			// display lose message, maybe play again
			break;
		case (BattleStates.WIN) :
			win.SetActive(true);
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
		// TODO: fix defend
//		if(player_defend)
//		{
//			if(spell_1.Card_Type == Card.CardTypes.DEFENSE)
//			{
//				//disable button 1
//				spell_button_1.GetComponent<Button>().interactable = false;
//			}
//			if(spell_2.Card_Type == Card.CardTypes.DEFENSE)
//			{
//				//disable button 2
//				spell_button_2.GetComponent<Button>().interactable = false;
//			}
//			player_defend = false;
//		}
		// TODO: Set the text and information on spell buttons
		spell_button_1.GetComponentsInChildren<Text>()[0].text = spell_1.Card_Name;
		spell_button_1.GetComponentsInChildren<Text>()[1].text = spell_1.Card_Cost.ToString();
		spell_button_2.GetComponentsInChildren<Text>()[0].text = spell_2.Card_Name;
		spell_button_2.GetComponentsInChildren<Text>()[1].text = spell_2.Card_Cost.ToString();
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
			Debug.Log(spell_1.Card_Name);
			player_log = "Player used " + spell_1.Card_Name;
			if(spell_1.Card_Type == Card.CardTypes.DEFENSE)
				player_defend = true;
			spell_1.CastSpell(player_info.player.Players_Summon);
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;
			break;
		case("spell_2") :
			Debug.Log(spell_2.Card_Name);
			player_log = "Player used " + spell_2.Card_Name;
			if(spell_1.Card_Type == Card.CardTypes.DEFENSE)
				player_defend = true;
			spell_2.CastSpell(player_info.player.Players_Summon);
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;
			break;
		case("basic_attack") :
			Debug.Log("Basic Attack!");
			player_log = "Player used basic attack";
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;
			slash.CastSpell(player_info.player.Players_Summon);
			player_info.player.Players_Summon.Attack_Boost = true;
			break;
		case("basic_defense") :
			Debug.Log("basic defense");
			player_log = "Player used basic defense";
			player_info.player.Players_Summon.Attack_Boost = false;
			player_info.player.Players_Summon.Defense_Boost = false;;
			shield.CastSpell(player_info.player.Players_Summon);
			player_info.player.Players_Summon.Defense_Boost = true;
			break;
		}
		// After player makes their choice enemy will make their choice
//		spell_button_1.GetComponent<Button>().interactable = true;
//		spell_button_2.GetComponent<Button>().interactable = true;
		current_state = BattleStates.ENEMYCHOICE;
	}

	/* Player Functions End */

	/* Enemy Functions Start */

	/*
	 * Bulk of enemy AI in enemy choice
	 */
	public void Enemy_Cast()
	{
		Enemy e = (Enemy)player_info.enemy;
		if(attack_boost && Random.Range(1, 101) <= 80)
		{
			// Cast attack spell
			Card attack = e.Attack_Spells[Random.Range(0, 6)];
			attack.CastSpell(player_info.enemy.Players_Summon);
			Debug.Log(attack.Card_Name);
			attack_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			current_state = BattleStates.RESULTS;
			enemy_log = "Enemy used " + attack.Card_Name;
			return;
		}

		if(defense_boost && Random.Range(1, 101) <= 80)
		{
			// Cast defense spell
			Card defense = e.Defense_Spells[Random.Range(0, 4)];
			defense.CastSpell(player_info.enemy.Players_Summon);
			Debug.Log(defense.Card_Name);
			defense_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			current_state = BattleStates.RESULTS;
			enemy_log = "Enemy used " + defense.Card_Name;
			return; 
		}

		int random_number = Random.Range(1, 101);
		// 30% chance to do a basic attack
		if (random_number <= 30)
		{
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			slash.CastSpell(player_info.enemy.Players_Summon);
			Debug.Log(slash.Card_Name);
			player_info.enemy.Players_Summon.Attack_Boost = true;
			attack_boost = true;
			enemy_log = "Enemy used basic attack";
		}
		// 30% chance to do a basic defense
		else if (random_number > 30 && random_number <= 60)
		{
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			shield.CastSpell(player_info.enemy.Players_Summon);
			Debug.Log(shield.Card_Name);
			player_info.enemy.Players_Summon.Defense_Boost = true;
			defense_boost = true;
			enemy_log = "Enemy used basic defense";
		}
		// 20% chance to do a attack spell
		else if (random_number > 60 && random_number <= 80)
		{
			// grab a random attack spell from enemies list and cast it.
			Card attack = e.Attack_Spells[Random.Range(0, 6)];
			attack.CastSpell(player_info.enemy.Players_Summon);
			Debug.Log(attack.Card_Name);
			attack_boost = false;
			defense_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			enemy_log = "Enemy used " + attack.Card_Name;
		}
		// 20% chance to do a defense spell
		else
		{
			// grab a random defense spell from enemies list and cast it.
			Card defense = e.Defense_Spells[Random.Range(0, 4)];
			defense.CastSpell(player_info.enemy.Players_Summon);
			Debug.Log(defense.Card_Name);
			attack_boost = false;
			defense_boost = false;
			player_info.enemy.Players_Summon.Attack_Boost = false;
			player_info.enemy.Players_Summon.Defense_Boost = false;
			enemy_log = "Enemy used " + defense.Card_Name;
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
		player_UI_log.GetComponent<Text>().text = player_log;
		enemy_UI_log.GetComponent<Text>().text = enemy_log;
		player_hp.GetComponent<Text>().text = player_info.player.Players_Summon.Health.ToString();
		enemy_hp.GetComponent<Text>().text = player_info.enemy.Players_Summon.Health.ToString();

		double php = (155.0/100.0)*player_info.player.Players_Summon.Health;
		double ehp = (155.0/100.0)*player_info.enemy.Players_Summon.Health;
		player_hp_bar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(28, (float)php); 
		enemy_hp_bar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(28, (float)ehp); 

		if(player_info.player.Players_Summon.Health <= 0)
		{
			current_state = BattleStates.LOSE;
			Deactivate_Spells();
			return;
		}
		if(player_info.enemy.Players_Summon.Health <= 0)
		{
			current_state = BattleStates.WIN;
			Deactivate_Spells();
			return;
		}

		current_state = BattleStates.PLAYERCHOICE;
	}

	/* Results Functions End */

	/* Helper Functions */

	/*
	 * Deactivates all buttons
	 */
	private void Deactivate_Spells()
	{
		spell_button_1.GetComponent<Button>().interactable = false;
		spell_button_2.GetComponent<Button>().interactable = false;
		basic_attack.GetComponent<Button>().interactable = false;
		basic_defense.GetComponent<Button>().interactable = false;
	}
}










































