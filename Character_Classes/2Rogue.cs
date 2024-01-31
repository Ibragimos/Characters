// Класс Разбойника
using System;
using System.Collections.Generic;

class Rogue : Character
{
    private List<Character> enemies;

    public Rogue(string name, int health, int strength, int agility,
                      int intelligence, int armor, int level, int experience,
                      Coordinates position, int initiative, List<Character> enemies)
            : base(name, health, strength, agility, intelligence, armor, level, experience, position, initiative)
    {
        this.enemies = enemies;
    }

    public override int Heal()
    {
        health = 10;
        return health;
    }

    public void HealString()
    {
        System.Console.WriteLine($"Rogue's health is equal to {Heal()}");
    }


    public Character FindNearestEnemyRogue(List<Character> enemies)
    {
        Character nearestEnemy = null;
        double nearestDistance = double.MaxValue;

        foreach (var enemy in enemies)
        {
            if (enemy is Rogue || enemy == this)
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

    private bool IsDead()
    {
        return Heal() <= 0;
    }


    public Tuple<double, double> StrikeAtTheClosestEnemy()
    {
        double weApproachedTheEnemyX = 0;
        double weApproachedTheEnemyY = 0;

        Character nearestEnemy = FindNearestEnemyRogue(enemies);
        if (nearestEnemy != null)
        {
            weApproachedTheEnemyX = this.GetPosition().X - nearestEnemy.GetPosition().X;
            weApproachedTheEnemyY = this.GetPosition().Y - nearestEnemy.GetPosition().Y;
        }

        return new Tuple<double, double>(weApproachedTheEnemyX, weApproachedTheEnemyY);
    }

    public void Move(int deltaX, int deltaY)
    {
        int newX = this.GetPosition().X + deltaX;
        int newY = this.GetPosition().Y + deltaY;

        this.SetPosition(new Coordinates(newX, newY));

        Console.WriteLine($"Rogue moved to position: {newX}, {newY}");
    }

    public override void Step()
    {
        if (IsDead())
        {
            Console.WriteLine("The rogue is dead and cannot perform the attack action");
        }
        else
        {
            Character nearestEnemyRogue = FindNearestEnemyRogue(enemies);
            if (nearestEnemyRogue != null && nearestEnemyRogue != this)
            {
                Console.WriteLine($"The closest enemy to the rogue - {nearestEnemyRogue.GetName()} at position {nearestEnemyRogue.GetPosition().X}, {nearestEnemyRogue.GetPosition().Y}.");

                double dX = StrikeAtTheClosestEnemy().Item1;
                double dY = StrikeAtTheClosestEnemy().Item2;

                if (Math.Abs(dX) <= 1.0 && Math.Abs(dY) <= 1.0)
                {
                    Attack();
                }
                else
                {
                    Console.WriteLine($"Rogue takes a step towards {nearestEnemyRogue.GetName()}");

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

    public override void Attack()
    {
        Console.WriteLine("The rogue is attacking!!!");
    }


    public override void LevelUp()
    {
        level++;
        health += 12;
        strength += 2;
        agility += 3;
        intelligence += 1;
        armor += 1;
        Console.WriteLine("The rogue has raised the level! Current level: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("The rogue got " + amount + " experience! Current experience: " + experience);
    }
}



