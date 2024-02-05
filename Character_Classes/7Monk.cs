// Класс Монаха
class Monk : Character
{
    private List<Character> enemies;

    public Monk(string name, int health, int strength, int agility,
                      int intelligence, int armor, int level, int experience,
                      Coordinates position, int initiative, List<Character> enemies)
            : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
    }

    public  Character FindNearestEnemyMonk(List<Character> enemies)
    {
        Character nearestEnemy = null;
        double nearestDistance = double.MaxValue;

        foreach (var enemy in enemies)
        {
            if (enemy is Monk || enemy == this)
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

        Console.WriteLine($"Monk moved to position: {newX}, {newY}");
    }



    public Tuple<double, double> StrikeAtTheClosestEnemy()
    {
        double weApproachedTheEnemyX = 0;
        double weApproachedTheEnemyY = 0;

        Character nearestEnemy = FindNearestEnemyMonk(enemies);
        if (nearestEnemy != null)
        {
            weApproachedTheEnemyX = this.GetPosition().X - nearestEnemy.GetPosition().X;
            weApproachedTheEnemyY = this.GetPosition().Y - nearestEnemy.GetPosition().Y;
        }

        return new Tuple<double, double>(weApproachedTheEnemyX, weApproachedTheEnemyY);
    }

    public override void ReactToStep(Character enemy)
    {
        if (IsDead())
        {
            Console.WriteLine($"{this.GetType().Name} is already dead and cannot react to step.");
        }
        else
        {
            double distance = this.GetPosition().DistanceTo(enemy.GetPosition());
            if (distance <= 1.5 && !enemy.IsDead())
            {
                Console.WriteLine($"{this.GetType().Name} is retaliating!");
                Attack();
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} is too far to retaliate against {enemy.GetType().Name}");

            }
        }
    }

    public override void Attack()
    {
        Console.WriteLine("The monk attacks with martial arts techniques!");
    }

    public override int Heal()
    {
        int health = 0;
        return health;
    }

    public override void HealString()
    {
        System.Console.WriteLine($"The monk has {Heal()} HP");
    }

    public override bool IsDead()
    {
        return Heal() <= 0;
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
        if (IsDead())
        {
            Console.WriteLine("The monk is dead and cannot perform the attack action");
        }
        else
        {
            Character nearestEnemyMonk = FindNearestEnemyMonk(enemies);
            if (nearestEnemyMonk != null && nearestEnemyMonk != this)
            {
                Console.WriteLine($"The closest enemy to the monk - {nearestEnemyMonk.GetName()} at position {nearestEnemyMonk.GetPosition().X}, {nearestEnemyMonk.GetPosition().Y}.");

                double dX = StrikeAtTheClosestEnemy().Item1;
                double dY = StrikeAtTheClosestEnemy().Item2;

                if (Math.Abs(dX) <= 1.5 && Math.Abs(dY) <= 1.5)  
                {
                    Attack();
                    nearestEnemyMonk.ReactToStep(this); 
                }
                else
                {
                    Console.WriteLine($"Monk takes a step towards {nearestEnemyMonk.GetName()}");
                    Move((int)dX, (int)dY); 
                }
            }
        }
    }
}