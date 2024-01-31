// Класс Копейщика
class Spearman : Character
{
    private List<Character> enemies;

    public Spearman(string name, int health, int strength, int agility,
                      int intelligence, int armor, int level, int experience,
                      Coordinates position, int initiative, List<Character> enemies)
            : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
    }

    public override void Attack()
    {
        Console.WriteLine("The spearman is attacking with a spear!");
    }

    public override int Heal()
    {
        int health = 0;
        return health;
    }

    public void HealString()
    {
        System.Console.WriteLine($"The spearman has {Heal()} HP");
    }

    private bool IsDead()
    {
        return Heal() <= 0;
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

    public Character FindNearestEnemySpearman(List<Character> enemies)
    {
        Character nearestEnemy = null;
        double nearestDistance = double.MaxValue;

        foreach (var enemy in enemies)
        {
            if (enemy is Spearman || enemy == this)
                continue;

            double distance = this.position.DistanceTo(enemy.GetPosition());
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    public void SetPosition(Coordinates newPosition)
    {
        this.position = newPosition;
    }

    public void Move(int deltaX, int deltaY)
    {
        int newX = this.GetPosition().X + deltaX;
        int newY = this.GetPosition().Y + deltaY;

        this.SetPosition(new Coordinates(newX, newY));

        Console.WriteLine($"Spearman moved to position: {newX}, {newY}");
    }


    public Tuple<double, double> StrikeAtTheClosestEnemy()
    {
        double weApproachedTheEnemyX = 0;
        double weApproachedTheEnemyY = 0;

        Character nearestEnemy = FindNearestEnemySpearman(enemies);
        if (nearestEnemy != null)
        {
            weApproachedTheEnemyX = this.GetPosition().X - nearestEnemy.GetPosition().X;
            weApproachedTheEnemyY = this.GetPosition().Y - nearestEnemy.GetPosition().Y;
        }

        return new Tuple<double, double>(weApproachedTheEnemyX, weApproachedTheEnemyY);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }
    public override void Step()
    {
        if (IsDead())
        {
            Console.WriteLine("The spearman is dead and cannot perform the attack action");
        }
        else
        {
            Character nearestEnemySpearman = FindNearestEnemySpearman(enemies);
            if (nearestEnemySpearman != null && nearestEnemySpearman != this)
            {
                Console.WriteLine($"The closest enemy to the spearman - {nearestEnemySpearman.GetName()} at position {nearestEnemySpearman.GetPosition().X}, {nearestEnemySpearman.GetPosition().Y}.");

                double dX = StrikeAtTheClosestEnemy().Item1;
                double dY = StrikeAtTheClosestEnemy().Item2;

                if (Math.Abs(dX) <= 1.0 && Math.Abs(dY) <= 1.0)
                {
                    Attack();
                }
                else
                {
                    Console.WriteLine($"Spearman takes a step towards {nearestEnemySpearman.GetName()}");

                    if (Math.Abs(dX) > Math.Abs(dY))
                    {
                        this.Move(dX > 0 ? 1 : -1, 0); // движение по оси X
                    }
                    else
                    {
                        this.Move(0, dY > 0 ? 1 : -1); // движение по оси Y
                    }

                    Console.WriteLine($"We approached the enemy at a distance of {StrikeAtTheClosestEnemy()}");
                }
            }
        }
    }
}