using UnityEngine;
using System.Collections;

/*
 * Creates The enemy and player for the Battle 
 */
public class BattleStateStart 
{
    //public BasePlayer player = new Player();
    public BasePlayer player = GameManager.instance.player;
	public BasePlayer enemy = new Enemy();
//	public BasePlayerSummon new_enemy = new BasePlayerSummon();
//	public BasePlayerSummon player_summon = new BasePlayerSummon();
//
//	public void PrepareBattle()
//	{
//		// Create the Enemy and player
//		CreateNewEnemy();
//		CreateNewPlayer();
//	}
//
//	private void CreateNewEnemy()
//	{
//		new_enemy.Summon_Name = "Dark Kight";
//		new_enemy.Summon_Level = 1;
//		new_enemy.Summon_Class = new BaseDarkSummon();
//		new_enemy.Strength = new_enemy.Summon_Class.Strength;
//		new_enemy.Defense = new_enemy.Summon_Class.Defense;
//		new_enemy.Health = new_enemy.Summon_Class.Health;
//		GameInformation.enemy_summon = new_enemy;
//	}
//
//	private void CreateNewPlayer()
//	{
//		player_summon.Summon_Name = "Paladin";
//		player_summon.Summon_Level = 1;
//		player_summon.Summon_Class = new BaseLightSummon();
//		player_summon.Strength = player_summon.Summon_Class.Strength;
//		player_summon.Defense = player_summon.Summon_Class.Defense;
//		player_summon.Health = player_summon.Summon_Class.Health;
//		GameInformation.player_summon = player_summon;
//	}
}
