using UnityEngine;
using System.Collections;

/*
 * Creates The enemy and player for the Battle 
 */
public class BattleStateStart 
{
    public BasePlayer player = Make_Player(); //GameManager.instance.player;
	public BasePlayer enemy = new Enemy();

    // TODO: Create enemy generation code here
    private static BasePlayer Make_Player()
    {
        BasePlayer p = new BasePlayer();
        p.Player_Name = "Fred";
        p.Player_Spell_Book = new SpellBook();
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        p.Player_Spell_Book.Add_Spell(new DarkStrike());
        return p;
    }
}
