using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseSpell
{
    public enum Spell_Types
    {
        ATTACK,
        DEFENSE
    }

    public enum Spell_Class
    {
        NONE,
        ROGUE,
        WARRIOR,
        MAGE
    }

    public enum Elements
    {
        NONE,
        FIRE,
        EARTH,
        LIGHT,
        DARK
    }

    protected string name;
    protected string description;
    protected int cost;
    protected List<Summon.Type> element_types = new List<Summon.Type>();
    protected Spell_Types type;
    private List<Ability> abilities = new List<Ability>();
    protected Spell_Class strategy; 

    protected int strength_req;
    protected int defense_req;
    protected int health_req;

    protected SpellResults results;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int Cost { get { return cost; } }
    public List<Summon.Type> Element_Types { get { return element_types; } }
    public Spell_Types Type { get { return type; } }
    public SpellResults Results { get { return results; } }
    public Spell_Class Strategy { get { return strategy; } }

    /*
     * True if summon can use this spell
     * otherwise false
     */
    public bool Can_Use(Summon s)
    {
        if (strength_req > s.Strength)
            return false;
        if (defense_req > s.Defense)
            return false;
        if (health_req > s.Health)
            return false;
        return true;
    }

    public virtual void Cast_Spell(Summon s)
    {
        results = new SpellResults(0, 0, 0, 0, 0, 0);
        foreach(Ability a in abilities)
        {
            results += a.Do_Ability(s);
        }
    }

    public void Add_Ability(Ability a)
    {
        abilities.Add(a);
    }
}
