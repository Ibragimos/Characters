abstract class Character
{
    protected string name;
    protected int health;
    protected int strength;
    protected int agility;
    protected int intelligence;
    protected int armor;
    protected int level;
    protected int experience;

    public Character(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience)
    {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.armor = armor;
        this.level = level;
        this.experience = experience;
    }

    public abstract void Attack();

    public abstract void Heal();

    public abstract void LevelUp();

    public abstract void GainExperience(int amount);

    public override string ToString()
    {
        return name;
    }
}