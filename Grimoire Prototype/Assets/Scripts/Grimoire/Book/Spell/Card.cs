using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Card 
{
	public enum CardTypes
	{
		ATTACK,
		DEFENSE
	}

    public enum Tier
    {
        TIER1,
        TIER2,
        TIER3
    }

	private string card_name;
	private string card_description;
	private List<BaseAbility> abilities = new List<BaseAbility>();
	private int card_cost;
	private CardTypes card_type;
    private Tier card_tier;

    // Battle Attributes
    private int damage;
    private int heal;
    private int block;
    private int poison;
    private int burn;
    private int paralyze;
	
	public string Card_Name { get; set; }
	public string Card_Description { get; set; }
	public int Card_Cost { get; set; }
	public CardTypes Card_Type { get; set; }
    public Tier Card_Tier { get; set; }

    public int Damage { get; set; }
    public int Heal { get; set; }
    public int Block { get; set; }
    public int Poison { get; set; }
    public int Burn { get; set; }
    public int Paralyze { get; set; }

	public void AddAbility(BaseAbility a)
	{
		abilities.Add(a);
	}

	public void CastSpell(BasePlayerSummon p1)
	{
		foreach(BaseAbility a in abilities)
		{
            int d, h, b, p, br, pr;
			a.DoAbility(p1, out d, out b, out h, out p, out  br, out pr);
            damage += d;
            block += b;
            heal += h;
            poison += p;
            burn += br;
            paralyze += pr;
		}
	}

    public void ResetBattleAttributes()
    {
        damage = 0;
        heal = 0;
        block = 0;
        burn = 0;
        poison = 0;
        paralyze = 0;
    }

    public void SpellResult(BasePlayerSummon p1, BasePlayerSummon p2)
    {
        p1.Health -= card_cost;
        if(p1.Summon_Class.Health > (p1.Health + heal))
        {
            p1.Health = p1.Summon_Class.Health;
        }
        else
        {
            p1.Health += heal;
        }
        if((p2.Health - damage) < 0)
        {
            p2.Health = 0;
        }
        else
        {
            p2.Health -= damage;
        }
        if(poison > 0)
        {
            p2.Poison = poison;
        }
        if(burn > 0)
        {
            p2.Burn = burn;
        }
        if(paralyze > 0)
        {
            p2.Paralyze = paralyze;
        }
    }
}
