using System;
using System.Collections.Generic;

public abstract class Character
{
    protected string name;
    protected int health;
    protected int strength;
    protected int agility;
    protected int intelligence;
    protected int armor;
    protected int level;
    protected int experience;
    protected int initiative;
    public Coordinates position { get; set; }


    public Character(string name, int health, int strength, int agility, int intelligence,
                     int armor, int level, int experience, Coordinates position, int initiative)
    {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.armor = armor;
        this.level = level;
        this.experience = experience;
        this.position = position;
        this.initiative = initiative;
    }

    public abstract void Attack();

    public abstract int Heal();

    public abstract void LevelUp();

    public abstract void GainExperience(int amount);
    public abstract void Step();

    public string GetName()
    {
        return name;
    }

    public Coordinates GetPosition()
    {
        return position;
    }

    
    public int GetInitiative()
    {
        return initiative;
    }

    public override string ToString()
    {
        return $"{name} at ({position.X}, {position.Y})";
    }


}