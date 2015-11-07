using UnityEngine;
using System.Collections;

public class Summon
{
    public enum Type
    {
        LIGHT,
        DARK,
        FIRE,
        EARTH
    }

    string name;
    string description;
    int level;
    int curr_exp;
    int req_exp;
    int health;
    int strength;
    int defense;
    int base_health;
    Type type;
    int stage;

    //Battle Variables
    int burn;
    int poison;
    int paralyze;
    bool attack_boost;
    bool defense_boost;

    /* Getters and Setters */
    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int Level { get { return level; } }
    public int Curr_Exp { get { return curr_exp; } }
    public int Req_Exp { get { return req_exp; } }
    public int Health { get { return health; } set { health = value; } }
    public int Strength { get { return strength; } }
    public int Defense { get { return defense; } }
    public int Base_Health { get { return base_health; } }
    public int Stage { get { return stage; } }
    public Type Summon_Type { get { return type; } }
    public int Burn { get; set; }
    public int Poison { get; set; }
    public int Paralyze { get; set; }
    public bool Attack_Boost { get; set; }
    public bool Defense_Boost { get; set; }

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
        Paralyze = 0;
        Attack_Boost = false;
        Defense_Boost = false;
    }

    /*
     * Calculates the required experience to level up
     */
    public int Calculate_Required_Exp()
    {
        int required_exp = 100 * ((level + 1) ^ 2);
        return required_exp;
    }

    /*
     * Adds experience points. 
     * Returns true if leveled up else returns false
     */
    public bool Add_Experience(int exp)
    {
        curr_exp += exp;
        if(curr_exp > req_exp)
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
        int hp_mod = Random.Range(0, 4) * 100;
        health += hp_mod;
        base_health += hp_mod;
        strength += Random.Range(0, 4);
        defense += Random.Range(0, 4);

        // Set experience;
        req_exp = Calculate_Required_Exp();

        // Check if evolves
        if(level == 16 || level == 32)
        {
            Evolve();
        }
    }

    /*
     * Evolves the Summon
     */
    public void Evolve()
    {
        if (level > 15 && level < 32)
        {
            stage = 2;
        }
        else if(level > 31)
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
