// Класс Арбалетчика
class Crossbowman : Character
{
    private List<Character> enemies;
    private List<Character> peasants;

    public Crossbowman(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience,
                        Coordinates position, int initiative, List<Character> enemies, List<Character> peasants)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
        this.peasants = peasants;
    }


    public Character FindNearestEnemyCrossbowman(List<Character> enemies)
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
        Console.WriteLine("The crossbowman is attacking with a crossbow!");
    }

    public void CheckAndAddArrows(int arrows)
    {
        foreach (var peasant in peasants)
        {
            if (peasant.IsReady && !peasant.IsDead())
            {
                peasant.IsReady = false;
                Console.WriteLine("The crossbowman received an arrow from a peasant.");
                break;
            }
        }
    }

    public override void ReactToStep(Character enemy)
    {
    }

    public override int Heal()
    {
        int health = 0;
        return health;
    }

    public override void HealString()
    {
        System.Console.WriteLine($"The crossbowman has {Heal()} HP");
    }
    public override bool IsDead()
    {
        return Heal() <= 0;
    }

    public override void LevelUp()
    {
        level++;
        health += 18;
        strength += 4;
        agility += 3;
        intelligence += 1;
        armor += 2;
        Console.WriteLine("The crossbowman has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The crossbowman took " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }

    public override void Step()
    {
        Character nearestEnemyCrossbowman = FindNearestEnemyCrossbowman(enemies);
        int arrows = 10;
        if (IsDead())
        {
            Console.WriteLine("The crossbowman is dead and cannot perform the action: Shooting.");
        }
        else
        {
            if (peasants.Any(p => p.IsReady && !p.IsDead()))
            {
                System.Console.WriteLine("The peasant is ready!");
                CheckAndAddArrows(arrows++);
            }
            if (arrows <= 0)
            {
                System.Console.WriteLine("The crossbowman doesn't have any arrows to shoot!!!");
            }
            else
            {
                if (nearestEnemyCrossbowman != null && !nearestEnemyCrossbowman.IsDead())
                {
                    Console.WriteLine($"The nearest enemy to the crossbowman is {nearestEnemyCrossbowman.GetName()} at position {nearestEnemyCrossbowman.GetPosition().X}, {nearestEnemyCrossbowman.GetPosition().Y}.");
                    Console.WriteLine("The crossbowman is shooting...");
                    nearestEnemyCrossbowman.Attack();
                    arrows--;
                    System.Console.WriteLine($"The crossbowman's number of arrows decreased, there were {arrows + 1} and now there are {arrows}");
                }
                else
                {
                    Console.WriteLine("No valid enemy in range to attack.");
                }
            }
        }
    }
}