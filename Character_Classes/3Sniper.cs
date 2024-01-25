public class Sniper : Character
{
    private List<Character> enemies;
    public Sniper(string name, int health, int strength, int agility,
                      int intelligence, int armor, int level, int experience,
                      Coordinates position, int initiative, List<Character> enemies)
            : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
    }

    public Character FindNearestEnemySniper(List<Character> enemies)
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

    public override int Heal()
    {
        int health = 10;
        System.Console.WriteLine($"The sniper has {health} HP");
        return health;
    }
    private bool IsDead()
    {
        return Heal() <= 0;
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

    public override void Step()
    {
        if (IsDead())
        {
            Console.WriteLine("The crossbowman is dead and cannot perform the action: Shooting.");
        }
        else
        {
            int cartridges = 5;
            Character nearestEnemySniper = FindNearestEnemySniper(enemies);

            if (cartridges <= 0)
            {
                System.Console.WriteLine("The sniper doesn't have any arrows to shoot!!!");
            }
            else if (nearestEnemySniper != null)
            {
                Console.WriteLine($"The nearest enemy to the sniper is {nearestEnemySniper.GetName()} at position {nearestEnemySniper.GetPosition().X}, {nearestEnemySniper.GetPosition().Y}.");
                System.Console.WriteLine("The sniper is shooting...");
                cartridges--;
                System.Console.WriteLine($"The sniper's number of cartridges decreased, there were {cartridges + 1} and now there are {cartridges}");
            }
        }
    }
}