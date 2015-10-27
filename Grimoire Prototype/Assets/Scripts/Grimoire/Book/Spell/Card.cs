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
    private bool icon_poison = false;
    private bool icon_paralyze = false;
    private bool icon_burn = false;
    private bool icon_vampire = false;
    private bool icon_heal = false;
    private bool icon_cure = false;

    // Battle Attributes
    private int damage;
    private int heal;
    private int block;
    private int poison;
    private int burn;
    private int paralyze;
	
    public bool Icon_Poison { get; set; }
    public bool Icon_Paralyze { get; set; }
    public bool Icon_Burn { get; set; }
    public bool Icon_Vampire { get; set; }
    public bool Icon_Heal { get; set; }
    public bool Icon_Cure { get; set; }

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
            Damage += d;
            Block += b;
            Heal += h;
            Poison += p;
            Burn += br;
            Paralyze += pr;
		}
	}

    public void ResetBattleAttributes()
    {
        Damage = 0;
        Heal = 0;
        Block = 0;
        Burn = 0;
        Poison = 0;
        Paralyze = 0;
    }

    public void SpellResult(BasePlayerSummon p1, BasePlayerSummon p2)
    {
        p1.Health -= card_cost;
        if(p1.Summon_Class.Health < (p1.Health + Heal))
        {
            p1.Health = p1.Summon_Class.Health;
        }
        else
        {
            p1.Health += Heal;
        }
        if((p2.Health - Damage) < 0)
        {
            p2.Health = 0;
        }
        else
        {
            p2.Health -= Damage;
        }
        if(Poison > 0)
        {
            p2.Poison = Poison;
        }
        if(Burn > 0)
        {
            p2.Burn = Burn;
        }
        if(Paralyze > 0)
        {
            p2.Paralyze = Paralyze;
        }
    }
}
