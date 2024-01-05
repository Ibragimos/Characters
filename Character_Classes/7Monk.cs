// Класс Монаха
class Monk : Character
{
    public Monk(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position)
        {
    }

    public override void Attack()
    {
        Console.WriteLine("Монах атакует приемами боевого искусства!");
    }

    public override void Heal()
    {
        Console.WriteLine("Монах лечит с помощью целительных приемов!");
    }

    public override void LevelUp()
    {
        level++;
        health += 15;
        strength += 3;
        agility += 2;
        intelligence += 2;
        armor += 2;
        Console.WriteLine("Монах повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Монах получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + name + ", Position(X, Y): " + position;
    }
}