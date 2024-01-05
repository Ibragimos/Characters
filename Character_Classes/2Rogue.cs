// Класс Разбойника
class Rogue : Character
{
    public Rogue(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position)
        {
    }

    public override void Attack()
    {
        Console.WriteLine("Разбойник атакует кинжалом!");
    }

    public override void Heal()
    {
        Console.WriteLine("Разбойник не может лечить.");
    }

    public override void LevelUp()
    {
        level++;
        health += 15;
        strength += 3;
        agility += 2;
        intelligence += 1;
        armor += 2;
        Console.WriteLine("Разбойник повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Разбойник получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
         return this.GetType().Name + ": " + name + ", Position(X, Y): " + position;
    }
}
