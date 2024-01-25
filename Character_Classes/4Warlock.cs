// Класс Колдуна
class Warlock : Character
{
    public Warlock(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position, int initiative)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("The sorcerer attacks with a spell!");
    }

    public override int Heal()
    {
        int health = 10;
        System.Console.WriteLine($"The sorcerer has {health} HP");
        return health;
    }

    public override void LevelUp()
    {
        level++;
        health += 8;
        strength += 1;
        agility += 1;
        intelligence += 3;
        armor += 1;
        Console.WriteLine("The sorcerer has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The sorcerer received " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }
    public override void Step()
    {

    }
}
