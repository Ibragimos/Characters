// Класс Колдуна
class Warlock : Character
{
    private List<Character> enemies;

    public Warlock(string name, int health, int strength, int agility,
                      int intelligence, int armor, int level, int experience,
                      Coordinates position, int initiative, List<Character> enemies)
            : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
    }

    public override void Attack()
    {
        Console.WriteLine("The warlock attacks with a spell!");
    }

    public void CastSpell(string spellName, Character target)
    {
        Console.WriteLine($"The warlock casts {spellName} at {target.GetName()}!");
        // Implement spell effects here
    }

    public override int Heal()
    {
        int health = 10;
        return health;
    }

    public override void ReactToStep(Character enemy)
    { }

    public override bool IsDead()
    {
        return Heal() <= 0;
    }

    public override void HealString()
    {
        System.Console.WriteLine($"The sorcerer has {Heal()} HP");
    }

    public Character FindNearestEnemyWarlock(List<Character> enemies)
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

        Console.WriteLine($"Warlock moved to position: {newX}, {newY}");
    }


    public Tuple<double, double> StrikeAtTheClosestEnemy()
    {
        double weApproachedTheEnemyX = 0;
        double weApproachedTheEnemyY = 0;

        Character nearestEnemy = FindNearestEnemyWarlock(enemies);
        if (nearestEnemy != null)
        {
            weApproachedTheEnemyX = this.GetPosition().X - nearestEnemy.GetPosition().X;
            weApproachedTheEnemyY = this.GetPosition().Y - nearestEnemy.GetPosition().Y;
        }

        return new Tuple<double, double>(weApproachedTheEnemyX, weApproachedTheEnemyY);
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
        if (IsDead())
        {
            Console.WriteLine("The warlock is dead and cannot perform any actions");
        }
        else
        {
            Character nearestEnemy = FindNearestEnemyWarlock(enemies);
            if (nearestEnemy != null && enemies.Contains(nearestEnemy)) // Проверка на принадлежность вражеской команде
            {
                double distance = this.GetPosition().DistanceTo(nearestEnemy.GetPosition());
                if (distance >= 2)
                {
                    Console.WriteLine($"An available enemy - {nearestEnemy}");
                    CastSpell("Fireball", nearestEnemy);
                }
                else
                {
                    Console.WriteLine("No enemies in range to cast a spell");
                }
            }
            else
            {
                Console.WriteLine("No enemies found or they are not in the enemy list");
            }
        }
    }
}
