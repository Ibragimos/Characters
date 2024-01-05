
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

    protected Coordinates position;


    public Character(string name, int health, int strength, int agility, int intelligence,
                     int armor, int level, int experience, Coordinates position)
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
    }

    public abstract void Attack();

    public abstract void Heal();

    public abstract void LevelUp();

    public abstract void GainExperience(int amount);

    public override string ToString()
    {
        return $"{name} at ({position.X}, {position.Y})";
    }
}