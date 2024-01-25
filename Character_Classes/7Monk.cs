// Класс Монаха
class Monk : Character
{
    public Monk(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position, int initiative)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("The monk attacks with martial arts techniques!");
    }

    public override int Heal()
    {
        int health = 10;
        System.Console.WriteLine($"The monk has {health} HP");
        return health;
    }

    public override void LevelUp()
    {
        level++;
        health += 15;
        strength += 3;
        agility += 2;
        intelligence += 2;
        armor += 2;
        Console.WriteLine("The monk has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The monk received " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }
    public override void Step()
    {

    }
}