using UnityEngine;
using System.Collections;

/*
 * Creates The enemy and player for the Battle 
 */
public class BattleStateStart 
{
    public BasePlayer player = GameManager.instance.player;
	public BasePlayer enemy = new Enemy();

    // TODO: Create enemy generation code here
}
