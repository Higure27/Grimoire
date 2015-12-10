using UnityEngine;
using System.Collections;

public class Summon
{
    public enum Type
    {
        NONE,
        LIGHT,
        DARK,
        FIRE,
        EARTH
    }

    private string name;
    private string description;
    private int level;
    private int curr_exp;
    private int req_exp;
    private int health;
    private int strength;
    private int defense;
    private int base_health;
    private Type type;
    private int stage;
    private int stat_points;

    //Battle Variables
    private int burn;
    private int poison;
    private int poison_count;
    private int paralyze;
    private bool attack_boost;
    private bool defense_boost;
    private int combo;
    private int curse;
    private int reflect;

    /* Getters and Setters */
    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int Level { get { return level; } }
    public int Curr_Exp { get { return curr_exp; } }
    public int Req_Exp { get { return req_exp; } }
    public int Health { get { return health; } set { health = value; } }
    public int Strength { get { return strength; } set { strength = value; } }
    public int Defense { get { return defense; } set { defense = value; } }
    public int Base_Health { get { return base_health; } set { base_health = value; } }
    public int Stage { get { return stage; } }
    public Type Summon_Type { get { return type; } }
    public int Burn { get; set; }
    public int Poison { get { return poison; } set { poison = value; } }
    public int Poison_Count { get { return poison_count; } set { poison_count = value; } }
    public int Paralyze { get; set; }
    public bool Attack_Boost { get; set; }
    public bool Defense_Boost { get; set; }
    public int Combo { get; set; }
    public int Curse { get; set; }
    public int Reflect { get; set; }
    public int Stat_Points { get; set; }

    /*
     * Constructor, Takes parameters to facilitate building summons on the fly
     */
    public Summon(string name, int level, int exp, int health, int strength, int defense, Type type)
    {
        this.name = name;
        this.level = level;
        this.curr_exp = exp;
        this.health = health;
        this.base_health = health;
        this.strength = strength;
        this.defense = defense;
        this.type = type;
        description = Summon_Description();
        this.req_exp = Calculate_Required_Exp();
        Evolve();
        Burn = 0;
        Poison = 0;
        Poison_Count = 0;
        Paralyze = 0;
        Attack_Boost = false;
        Defense_Boost = false;
        combo = 0;
        Stat_Points = 0;
    }

    /*
     * Calculates the required experience to level up
     */
    public int Calculate_Required_Exp()
    {
        int required_exp = 100 * (int) Mathf.Pow((level + 1), 2);
        return required_exp;
    }

    /*
     * Adds experience points. 
     * Returns true if leveled up else returns false
     */
    public bool Add_Experience(int exp)
    {
        curr_exp += exp;
        if(curr_exp >= req_exp)
        {
            Level_Up();
            return true;
        }
        return false;
    }

    /*
     * Levels up the summon by increasing attributes
     */
    public void Level_Up()
    {
        // Increment Level
        level++;

        // Increase Attributes
        //int hp_mod = Random.Range(1, 11);
        //health += hp_mod;
        //base_health += hp_mod;
        //strength += Random.Range(1, 7);
        //defense += Random.Range(1, 7);

        Stat_Points += 3;

        // Set experience;
        req_exp = Calculate_Required_Exp();

        // Check if evolves
        if(level == 10 || level == 20)
        {
            Evolve();
        }
    }

    /*
     * Evolves the Summon
     */
    public void Evolve()
    {
        if (level > 10 && level < 20)
        {
            stage = 2;
        }
        else if(level > 19)
        {
            stage = 3;
        }
        else
        {
            stage = 1;
        }
        // Possibly change summon animation
    }

    /*
     * Sets up Summon Description
     */
    private string Summon_Description()
    {
        switch (Summon_Type)
        {
            case Type.DARK:
                return "A Deadly Vampire";
            case Type.EARTH:
                return "A Stalwart Golem";
            case Type.FIRE:
                return "A Blazing Phoenix";
            case Type.LIGHT:
                return "A Guardian of Light";
        }
        return "";
    }
}
