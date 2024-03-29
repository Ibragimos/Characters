public class Peasant : Character
{
    public bool IsReady { get; set; } = true;
    private List<Character> enemies;

    public Peasant(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience,
    Coordinates position, int initiative, List<Character> enemies)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
    }

    public Character FindNearestEnemyPeasant(List<Character> enemies)
    {
        Character nearestEnemy = null;
        double nearestDistance = double.MaxValue;

        foreach (var enemy in enemies)
        {
            if (enemy is Peasant || enemy == this)
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

        Console.WriteLine($"Peasant moved to position: {newX}, {newY}");
    }



    public Tuple<double, double> StrikeAtTheClosestEnemy()
    {
        double weApproachedTheEnemyX = 0;
        double weApproachedTheEnemyY = 0;

        Character nearestEnemy = FindNearestEnemyPeasant(enemies);
        if (nearestEnemy != null)
        {
            weApproachedTheEnemyX = this.GetPosition().X - nearestEnemy.GetPosition().X;
            weApproachedTheEnemyY = this.GetPosition().Y - nearestEnemy.GetPosition().Y;
        }

        return new Tuple<double, double>(weApproachedTheEnemyX, weApproachedTheEnemyY);
    }


    public override void Attack()
    {
        Console.WriteLine("The peasant is attacking with a torch!");
    }

    public override int Heal()
    {
        int health = 10;
        //System.Console.WriteLine($"The peasant has {health} HP");
        return health;
    }

    public override void HealString()
    {
        System.Console.WriteLine($"The peasant has {Heal()} HP");
    }

    public override void ReactToStep(Character enemy)
    { }


    public override bool IsDead()
    {
        return Heal() <= 0;
    }


    public override void LevelUp()
    {
        level++;
        health += 10;
        strength += 2;
        agility += 1;
        intelligence += 1;
        armor += 1;
        Console.WriteLine("The peasant has leveled up! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The peasant received " + amount + " experience! Current experience: " + experience);
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {name}, Position(X, Y): ({position.X}, {position.Y})";
    }

    public override void Step()
    {

        Character nearestEnemyPeasant = FindNearestEnemyPeasant(enemies);

        if (IsDead())
        {
            Console.WriteLine("The peasant is dead and cannot perform the attack action");
        }
        else
        {
            if (!IsReady)
            {
                if (nearestEnemyPeasant != null && nearestEnemyPeasant != this)
                {

                    Console.WriteLine($"The closest enemy to the peasant - {nearestEnemyPeasant.GetName()} at position {nearestEnemyPeasant.GetPosition().X}, {nearestEnemyPeasant.GetPosition().Y}.");

                    double dX = StrikeAtTheClosestEnemy().Item1;
                    double dY = StrikeAtTheClosestEnemy().Item2;

                    if (Math.Abs(dX) <= 1.0 && Math.Abs(dY) <= 1.0)
                    {
                        
                        Attack();
                    }
                    else
                    {
                        Console.WriteLine($"Peasant takes a step towards {nearestEnemyPeasant.GetName()}");

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
            else System.Console.WriteLine("Not ready");
        }

    }
}