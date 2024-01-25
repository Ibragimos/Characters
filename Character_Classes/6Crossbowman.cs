// Класс Арбалетчика
class Crossbowman : Character
{
    private List<Character> enemies;
    public Crossbowman(string name, int health, int strength, int agility,
                      int intelligence, int armor, int level, int experience,
                      Coordinates position, int initiative, List<Character> enemies)
            : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
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

    public override int Heal()
    {
        int health = 0;
        System.Console.WriteLine($"The crossbowman has {health} HP");
        return health;
    }
    private bool IsDead()
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
        if (IsDead())
        {
            Console.WriteLine("The crossbowman is dead and cannot perform the action: Shooting.");
        }
        else
        {
            int arrows = 0;
            Character nearestEnemyCrossbowman = FindNearestEnemyCrossbowman(enemies);

            if (arrows <= 0)
            {
                System.Console.WriteLine("The сrossbowman doesn't have any arrows to shoot!!!");
            }
            else if (nearestEnemyCrossbowman != null)
            {
                Console.WriteLine($"The nearest enemy to the сrossbowman is {nearestEnemyCrossbowman.GetName()} at position {nearestEnemyCrossbowman.GetPosition().X}, {nearestEnemyCrossbowman.GetPosition().Y}.");
                System.Console.WriteLine("The сrossbowman is shooting...");
                arrows--;
                System.Console.WriteLine($"The сrossbowman's number of arrows decreased, there were {arrows + 1} and now there are {arrows}");
            }
        }
    }
}