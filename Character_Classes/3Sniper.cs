public class Sniper : Character
{
    public Sniper(string name, int health, int strength, int agility,
                  int intelligence, int armor, int level, int experience,
                  Coordinates position)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position)
    {
    }

    public Character FindNearestEnemy(List<Character> enemies)
    {
        Character nearestEnemy = null;
        double nearestDistance = double.MaxValue;

        foreach (var enemy in enemies)
        {
            double distance = this.position.DistanceTo(enemy.GetPosition());
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public override void Attack()
    {
        Console.WriteLine("The sniper is attacking with a sniper rifle!");
    }

    public override void Heal()
    {
        Console.WriteLine("A sniper can't heal.");
    }

    public override void LevelUp()
    {
        level++;
        health += 12;
        strength += 2;
        agility += 3;
        intelligence += 1;
        armor += 1;
        Console.WriteLine("The sniper has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The sniper got " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }
}