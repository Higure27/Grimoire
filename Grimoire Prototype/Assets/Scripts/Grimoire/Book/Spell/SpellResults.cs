using UnityEngine;
using System.Collections;

/*
 * Class used to pass around the results of casting a spell
 */
public class SpellResults
{
    private int damage;
    private int block;
    private int heal;
    private int poison;
    private int burn;
    private int paralyze;

    public int Damage { get { return damage; } }
    public int Block { get { return block; } }
    public int Heal { get { return heal; } }
    public int Poison { get { return poison; } }
    public int Burn { get { return burn; } }
    public int Paralyze { get { return paralyze; } }

    public SpellResults(int damage, int block, int heal, int poison, int burn, int paralyze)
    {
        this.damage = damage;
        this.block = block;
        this.heal = heal;
        this.poison = poison;
        this.burn = burn;
        this.paralyze = paralyze;
    }

    public static SpellResults operator+(SpellResults a, SpellResults b)
    {
        int dmg = a.Damage + b.Damage;
        int blk = a.Block + b.Block;
        int heal = a.Heal + b.Heal;
        int psn = a.Poison + b.Poison;
        int brn = a.Burn + b.Burn;
        int plz = a.Paralyze + b.Paralyze;
        return new SpellResults(dmg, blk, heal, psn, brn, plz);
    }
}
