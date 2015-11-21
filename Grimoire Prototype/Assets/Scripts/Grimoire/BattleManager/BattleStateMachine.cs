//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using System.Threading;

//public class BattleStateMachine : MonoBehaviour 
//{
//	// Contains player and enemy data
//	private BattleStateStart player_info = new BattleStateStart();

//	// Make Draw_Spells function is only called once
//	private bool drew_for_turn = false;

//	// Enemy AI variables
//	private bool attack_boost = false;
//	private bool defense_boost = false;

//    // Status Effect Variables
//    private int poison_damage = 5;
//    private int burn_damage = 8;

//	// Variable that prevents player or enemy from defending twice in a row
//	private bool player_defend = false;
//	private bool enemy_defend = false;

//	// Two Spells that will be displayed to user
//	private Card spell_1;
//	private Card spell_2;
//	private Card slash = new Slash();
//	private Card shield = new Shield();

//    // Player and Enemy chosen Spells
//    private Card player_spell;
//    private Card enemy_spell;

//	// Battle Log
//	private string player_log;
//	private string enemy_log;

//	// UI logs
//	public GameObject player_UI_log;
//	public GameObject enemy_UI_log;

//	// Actor Health 
//	public GameObject player_hp;
//	public GameObject enemy_hp;

//	// Win/Lose Text
//	public GameObject win;
//	public GameObject lose;

//	// Spell buttons which are displayed
//	public GameObject spell_button_1;
//	public GameObject spell_button_2;
//	public GameObject basic_attack;
//	public GameObject basic_defense;

//	// Health bars which are displayed
//	public GameObject player_hp_bar;
//	public GameObject enemy_hp_bar;

//    // Status Icons for Spells
//    //private GameObject left_effect_panel;
//    //private GameObject right_effect_panel;
//    public GameObject poison_1;
//    public GameObject poison_2;
//    public GameObject burn_1;
//    public GameObject burn_2;
//    public GameObject paralyze_1;
//    public GameObject paralyze_2;
//    public GameObject vampire_1;
//    public GameObject vampire_2;
//    public GameObject heal_1;
//    public GameObject heal_2;
//    public GameObject cure_1;
//    public GameObject cure_2;

//    // status icons for players
//    public GameObject player_poison;
//    public GameObject enemy_poison;
//    public GameObject player_burn;
//    public GameObject enemy_burn;
//    public GameObject player_paralyze;
//    public GameObject enemy_paralyze;

//    public enum BattleStates 
//	{
//		START,
//		PLAYERCHOICE,
//		ENEMYCHOICE,
//		RESULTS,
//		LOSE,
//		WIN,
//	}

//	public static BattleStates current_state;

//	// For initialization
//	void Start () 
//	{
//		win.SetActive(false);
//		lose.SetActive(false);
//        //left_effect_panel = GameObject.Find("left_effect_panel");
//        //right_effect_panel = GameObject.Find("right_effect_panel");
//        Deactivate_Spell_Icons();
//		current_state = BattleStates.START;
//	}
	
//	// Update is called once per frame
//	void Update () 
//	{
//		switch (current_state) 
//		{
//		case (BattleStates.START) :
//            player_hp.GetComponent<Text>().text = player_info.player.Players_Summon.Health.ToString();
//            enemy_hp.GetComponent<Text>().text = player_info.enemy.Players_Summon.Health.ToString();
//			current_state = BattleStates.PLAYERCHOICE;
//			break;
//		case (BattleStates.PLAYERCHOICE) :
//			// Draw a new page and display options
//			if(!drew_for_turn)
//			{
//				drew_for_turn = true;
//				Draw_Spells();
//				Display_Spells();
//			}
//			break;
//		case (BattleStates.ENEMYCHOICE) :
//			Enemy_Cast();
//			break;
//		case (BattleStates.RESULTS) :
//            Status_Effects();
//            Calculate_Results();      
//			Display_Results();
//			drew_for_turn = false;
//			break;
//		case (BattleStates.LOSE) :
//			lose.SetActive(true);
//            Thread.Sleep(1000);
//            GameManager.instance.player.Players_Summon.Health = GameManager.instance.player.Players_Summon.Base_Health;
//            GameManager.instance.current_state = GameManager.GameStates.MAIN;
//            GameManager.instance.scene_loaded = false;
//			// display lose message, maybe play again
//			break;
//		case (BattleStates.WIN) :
//			win.SetActive(true);
//            Thread.Sleep(1000);
//            GameManager.instance.player.Players_Summon.Health = GameManager.instance.player.Players_Summon.Base_Health;
//            GameManager.instance.current_state = GameManager.GameStates.MAIN;
//            GameManager.instance.scene_loaded = false;
//			// display win message, maybe play again
//			break;
//		}
//	}

//	/* Game State Functions */

//	/* Player Functions Start */
//	/*
//	 * Draw two new spells from book to display to user
//	 * set private spell_1 and spell_2 to these new spells
//	 * for easy access later.
//	 */
//	private void Draw_Spells()
//	{
//		player_info.player.Player_Spell_Book.DrawHand();
//		spell_1 = player_info.player.Player_Spell_Book.Hand[0];
//		spell_2 = player_info.player.Player_Spell_Book.Hand[1];
//	}

//	/*
//	 * Display the spell options to the player
//	 */
//	private void Display_Spells()
//	{
//        Deactivate_Spell_Icons();
//		// TODO: fix defend
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
//		// TODO: Set the text and information on spell buttons
//		spell_button_1.GetComponentsInChildren<Text>()[0].text = spell_1.Card_Name;
//		spell_button_1.GetComponentsInChildren<Text>()[1].text = spell_1.Card_Cost.ToString();
//		spell_button_2.GetComponentsInChildren<Text>()[0].text = spell_2.Card_Name;
//		spell_button_2.GetComponentsInChildren<Text>()[1].text = spell_2.Card_Cost.ToString();
//        Display_Spell_Icons();
//	}

//    private void Display_Spell_Icons()
//    {
//        if(spell_1.Icon_Poison)
//            poison_1.SetActive(true);
//        if (spell_1.Icon_Burn)
//            burn_1.SetActive(true);
//        if (spell_1.Icon_Paralyze)
//            paralyze_1.SetActive(true);
//        if (spell_1.Icon_Vampire)
//            vampire_1.SetActive(true);
//        if (spell_1.Icon_Heal)
//            heal_1.SetActive(true);
//        if (spell_1.Icon_Cure)
//            cure_1.SetActive(true);

//        if (spell_2.Icon_Poison)
//            poison_2.SetActive(true);
//        if (spell_2.Icon_Burn)
//            burn_2.SetActive(true);
//        if (spell_2.Icon_Paralyze)
//            paralyze_2.SetActive(true);
//        if (spell_2.Icon_Vampire)
//            vampire_2.SetActive(true);
//        if (spell_2.Icon_Heal)
//            heal_2.SetActive(true);
//        if (spell_2.Icon_Cure)
//            cure_2.SetActive(true);
//    }

//	/*
//	 * Casts the spell that the user chooses
//	 * @param spell = the button which is pressed
//	 */
//	public void Cast_Spell(string spell)
//	{
//		switch (spell)
//		{
//		case("spell_1") :
//			player_spell = spell_1;
//			player_log = "Player used " + spell_1.Card_Name;
//            player_defend = (spell_1.Card_Type == Card.CardTypes.DEFENSE) ? true : false;
//			spell_1.CastSpell(player_info.player.Players_Summon);
//			player_info.player.Players_Summon.Attack_Boost = false;
//			player_info.player.Players_Summon.Defense_Boost = false;
//			break;
//		case("spell_2") :
//			player_spell = spell_2;
//			player_log = "Player used " + spell_2.Card_Name;
//            player_defend = (spell_1.Card_Type == Card.CardTypes.DEFENSE) ? true : false;
//			spell_2.CastSpell(player_info.player.Players_Summon);
//			player_info.player.Players_Summon.Attack_Boost = false;
//			player_info.player.Players_Summon.Defense_Boost = false;
//			break;
//		case("basic_attack") :
//			player_spell = slash;
//			player_log = "Player used basic attack";
//            player_defend = false;
//			player_info.player.Players_Summon.Attack_Boost = false;
//			player_info.player.Players_Summon.Defense_Boost = false;
//			slash.CastSpell(player_info.player.Players_Summon);
//			player_info.player.Players_Summon.Attack_Boost = true;
//			break;
//		case("basic_defense") :
//			player_spell = shield;
//			player_log = "Player used basic defense";
//            player_defend = false;
//			player_info.player.Players_Summon.Attack_Boost = false;
//			player_info.player.Players_Summon.Defense_Boost = false;;
//			shield.CastSpell(player_info.player.Players_Summon);
//			player_info.player.Players_Summon.Defense_Boost = true;
//			break;
//		}

//		spell_button_1.GetComponent<Button>().interactable = true;
//		spell_button_2.GetComponent<Button>().interactable = true;
//		current_state = BattleStates.ENEMYCHOICE;
//	}

//	/* Player Functions End */

//	/* Enemy Functions Start */

//	/*
//	 * Bulk of enemy AI in enemy choice
//	 */
//	public void Enemy_Cast()
//	{
//		Enemy e = (Enemy)player_info.enemy;
//		if(attack_boost && Random.Range(1, 101) <= 80)
//		{
//            // Cast attack spell
//			enemy_spell = e.Attack_Spells[Random.Range(0, 6)];
//			enemy_spell.CastSpell(player_info.enemy.Players_Summon);
//			attack_boost = false;
//            defense_boost = false;
//            enemy_defend = false;
//            player_info.enemy.Players_Summon.Attack_Boost = false;
//			player_info.enemy.Players_Summon.Defense_Boost = false;
//			current_state = BattleStates.RESULTS;
//			enemy_log = "Enemy used " + enemy_spell.Card_Name;
//			return;
//		}

//		if(defense_boost && Random.Range(1, 101) <= 80)
//		{
//            // Cast defense spell  
//			enemy_spell = e.Defense_Spells[Random.Range(0, 4)];
//			enemy_spell.CastSpell(player_info.enemy.Players_Summon);
//			defense_boost = false;
//            attack_boost = false;
//            enemy_defend = true;
//            player_info.enemy.Players_Summon.Attack_Boost = false;
//			player_info.enemy.Players_Summon.Defense_Boost = false;
//			current_state = BattleStates.RESULTS;
//			enemy_log = "Enemy used " + enemy_spell.Card_Name;
//			return; 
//		}

//		int random_number = Random.Range(1, 101);
//		// 30% chance to do a basic attack
//		if (random_number <= 30)
//		{ 
//			enemy_spell = slash;
//			player_info.enemy.Players_Summon.Attack_Boost = false;
//			player_info.enemy.Players_Summon.Defense_Boost = false;
//			slash.CastSpell(player_info.enemy.Players_Summon);
//			player_info.enemy.Players_Summon.Attack_Boost = true;
//			attack_boost = true;
//            defense_boost = false;
//            enemy_defend = false;
//            enemy_log = "Enemy used basic attack";
//		}
//		// 30% chance to do a basic defense
//		else if (random_number > 30 && random_number <= 60)
//		{        
//			enemy_spell = shield;
//			player_info.enemy.Players_Summon.Attack_Boost = false;
//			player_info.enemy.Players_Summon.Defense_Boost = false;
//			shield.CastSpell(player_info.enemy.Players_Summon);
//			player_info.enemy.Players_Summon.Defense_Boost = true;
//			defense_boost = true;
//            attack_boost = false;
//            enemy_defend = false;
//            enemy_log = "Enemy used basic defense";
//		}
//		// 20% chance to do a attack spell
//		else if (random_number > 60 && random_number <= 80)
//		{
//			// grab a random attack spell from enemies list and cast it.
//			enemy_spell = e.Attack_Spells[Random.Range(0, 6)];
//			enemy_spell.CastSpell(player_info.enemy.Players_Summon);
//			attack_boost = false;
//			defense_boost = false;
//            enemy_defend = false;
//			player_info.enemy.Players_Summon.Attack_Boost = false;
//			player_info.enemy.Players_Summon.Defense_Boost = false;
//			enemy_log = "Enemy used " + enemy_spell.Card_Name;
//		}
//		// 20% chance to do a defense spell
//		else
//		{
//			// grab a random defense spell from enemies list and cast it.
//			enemy_spell = e.Defense_Spells[Random.Range(0, 4)];
//			enemy_spell.CastSpell(player_info.enemy.Players_Summon);
//			attack_boost = false;
//			defense_boost = false;
//            enemy_defend = true;
//			player_info.enemy.Players_Summon.Attack_Boost = false;
//			player_info.enemy.Players_Summon.Defense_Boost = false;
//			enemy_log = "Enemy used " + enemy_spell.Card_Name;
//		}

//		current_state = BattleStates.RESULTS;
//	}
//	/* Enemy Functions End */

//	/* Results Functions Start */

//	/*
//	 * Changes the UI to reflect the results of the
//	 * Player and enemy choices
//	 */
//	private void Display_Results()
//	{
//		// health bar decreases/increases for both players depending
//		// Text log updated with enemy attack and player attack
//		player_UI_log.GetComponent<Text>().text = player_log;
//		enemy_UI_log.GetComponent<Text>().text = enemy_log;
//		player_hp.GetComponent<Text>().text = player_info.player.Players_Summon.Health.ToString();
//		enemy_hp.GetComponent<Text>().text = player_info.enemy.Players_Summon.Health.ToString();

//		double php = (155.0)*((double)player_info.player.Players_Summon.Health/(double)player_info.player.Players_Summon.Base_Health);
//		double ehp = (155.0)*((double)player_info.enemy.Players_Summon.Health/(double)player_info.enemy.Players_Summon.Base_Health);
//        Debug.Log("Player HP: " + php);
//        Debug.Log("Enemy HP: " + ehp);
//		player_hp_bar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(28, (float)php); 
//		enemy_hp_bar.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(28, (float)ehp); 

//		if(player_info.player.Players_Summon.Health <= 0)
//		{
//			current_state = BattleStates.LOSE;
//			Deactivate_Spells();
//			return;
//		}
//		if(player_info.enemy.Players_Summon.Health <= 0)
//		{
//			current_state = BattleStates.WIN;
//			Deactivate_Spells();
//			return;
//		}

//		current_state = BattleStates.PLAYERCHOICE;
//	}

//    /*
//     * Calculates results of turn
//     */
//    private void Calculate_Results()
//    {
//        Debug.Log("Player Attack: " + player_spell.Damage.ToString());
//        Debug.Log("Player Defend: " + player_spell.Block.ToString());
//        Debug.Log("Enemy Attack: " + enemy_spell.Damage.ToString());
//        Debug.Log("Enemy Defend: " + enemy_spell.Block.ToString());
//        int player_damaged = (player_spell.Block > enemy_spell.Damage) ? 0 : (enemy_spell.Damage - player_spell.Block);
//        int enemy_damaged = (enemy_spell.Block > player_spell.Damage) ? 0 : (player_spell.Damage - enemy_spell.Block);

//        player_spell.Damage = enemy_damaged;
//        enemy_spell.Damage = player_damaged;
//        player_spell.SpellResult(player_info.player.Players_Summon, player_info.enemy.Players_Summon);
//        enemy_spell.SpellResult(player_info.enemy.Players_Summon, player_info.player.Players_Summon);
//        player_spell.ResetBattleAttributes();
//        enemy_spell.ResetBattleAttributes();
//    }

//    /* Results Functions End */

//    /* Helper Functions */

    
//    private void Deactivate_Spell_Icons()
//    {
//        poison_1.SetActive(false);
//        poison_2.SetActive(false);
//        burn_1.SetActive(false);
//        burn_2.SetActive(false);
//        paralyze_1.SetActive(false);
//        paralyze_2.SetActive(false);
//        vampire_1.SetActive(false);
//        vampire_2.SetActive(false);
//        heal_1.SetActive(false);
//        heal_2.SetActive(false);
//        cure_1.SetActive(false);
//        cure_2.SetActive(false);

//        player_poison.SetActive(false);
//        enemy_poison.SetActive(false);
//        player_burn.SetActive(false); ;
//        enemy_burn.SetActive(false);
//        player_paralyze.SetActive(false);
//        enemy_paralyze.SetActive(false);
//}

//    /*
//	 * Deactivates all buttons
//	 */
//    private void Deactivate_Spells()
//	{
//		spell_button_1.GetComponent<Button>().interactable = false;
//		spell_button_2.GetComponent<Button>().interactable = false;
//		basic_attack.GetComponent<Button>().interactable = false;
//		basic_defense.GetComponent<Button>().interactable = false;
//	}

//    private void Status_Effects()
//    {
//        if(player_info.player.Players_Summon.Poison > 0)
//        {
//            player_poison.SetActive(true);
//            player_info.player.Players_Summon.Health =  ((player_info.player.Players_Summon.Health - poison_damage) < 0) ? 0 : (player_info.player.Players_Summon.Health - poison_damage);
//            player_info.player.Players_Summon.Poison--;
//            Debug.Log("Player Poison Damage");
//        }
//        else
//        {
//            player_poison.SetActive(false);
//        }
//        if(player_info.enemy.Players_Summon.Poison > 0)
//        {
//            enemy_poison.SetActive(true);
//            player_info.enemy.Players_Summon.Health = ((player_info.enemy.Players_Summon.Health - poison_damage) < 0) ? 0 : (player_info.enemy.Players_Summon.Health - poison_damage);
//            player_info.enemy.Players_Summon.Poison--;
//            Debug.Log("Enemy Poison Damage");
//        }
//        else
//        {
//            enemy_poison.SetActive(false);
//        }
//        if (player_info.player.Players_Summon.Burn > 0)
//        {
//            player_burn.SetActive(true);
//            player_info.player.Players_Summon.Health = ((player_info.player.Players_Summon.Health - burn_damage) < 0) ? 0 : (player_info.player.Players_Summon.Health - burn_damage);
//            player_info.player.Players_Summon.Burn--;
//            Debug.Log("Player Burn Damage");
//        }
//        else
//        {
//            player_burn.SetActive(false);
//        }
//        if (player_info.enemy.Players_Summon.Burn > 0)
//        {
//            enemy_burn.SetActive(true);
//            player_info.enemy.Players_Summon.Health = ((player_info.enemy.Players_Summon.Health - burn_damage) < 0) ? 0 : (player_info.enemy.Players_Summon.Health - burn_damage);
//            player_info.enemy.Players_Summon.Burn--;
//            Debug.Log("Enemy Burn Damage");
//        }
//        else
//        {
//            enemy_burn.SetActive(false);
//        }
//    }
//}










































