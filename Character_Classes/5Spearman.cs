// Класс Копейщика
class Spearman : Character
{
    public Spearman(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position, int initiative)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("The spearman is attacking with a spear!");
    }

    public override int Heal()
    {
        int health = 10;
        System.Console.WriteLine($"The spearman has {health} HP");
        return health;
    }

    public override void LevelUp()
    {
        level++;
        health += 20;
        strength += 5;
        agility += 2;
        intelligence += 1;
        armor += 3;
        Console.WriteLine("The Spearman has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The spearman received " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }
    public override void Step()
    {

    }
}