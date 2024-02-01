public class Sniper : Character
{
    private List<Character> enemies;
    private List<Peasant> peasants;

    public Sniper(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience,
                        Coordinates position, int initiative, List<Character> enemies, List<Peasant> peasants)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
        this.peasants = peasants;
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
        Console.WriteLine("The sniper is attacking with a crossbow!");
    }

    public void CheckAndAddPatron(int patron)
    {
        foreach (var peasant in peasants)
        {
            if (peasant.IsReady && !peasant.IsDead())
            {
                peasant.IsReady = false;
                Console.WriteLine("The sniper received an patron from a peasant.");
                break;
            }
        }
    }

    public override int Heal()
    {
        int health = 10;
        return health;
    }

    public void HealString()
    {
        System.Console.WriteLine($"The sniper has {Heal()} HP");
    }
    public override bool IsDead()
    {
        return Heal() <= 0;
    }

    public override void ReactToStep(Character enemy)
    { }

    public override void LevelUp()
    {
        level++;
        health += 18;
        strength += 4;
        agility += 3;
        intelligence += 1;
        armor += 2;
        Console.WriteLine("The sniper has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The sniper took " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }

    public override void Step()
    {
        Character nearestEnemySniper = FindNearestEnemySniper(enemies);
        int patron = 10;

        if (IsDead())
        {
            Console.WriteLine("The sniper is dead and cannot perform the action: Shooting.");
        }
        else
        {
            if (peasants.Any(p => p.IsReady && !p.IsDead()))
            {
                System.Console.WriteLine("The peasant is ready!");
                CheckAndAddPatron(patron++);
            }

            if (patron <= 0)
            {
                System.Console.WriteLine("The sniper doesn't have any patron to shoot!!!");
            }
            else if (nearestEnemySniper != null && enemies.Contains(nearestEnemySniper)) // Добавляем проверку на вражеского персонажа
            {
                Console.WriteLine($"The nearest enemy to the sniper is {nearestEnemySniper.GetName()} at position {nearestEnemySniper.GetPosition().X}, {nearestEnemySniper.GetPosition().Y}.");
                System.Console.WriteLine("The sniper is shooting...");
                patron--;
                System.Console.WriteLine($"The sniper's number of patron decreased, there were {patron + 1} and now there are {patron}");
            }
            else
            {
                Console.WriteLine("No enemies found or they are not in the enemy list");
            }
        }
    }
}