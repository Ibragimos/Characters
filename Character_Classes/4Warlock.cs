// Класс Колдуна
class Warlock : Character
{
    public Warlock(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position)
        {
    }

    public override void Attack()
    {
        Console.WriteLine("Колдун атакует заклинанием!");
    }

    public override void Heal()
    {
        Console.WriteLine("Колдун лечит с помощью магии!");
    }

    public override void LevelUp()
    {
        level++;
        health += 8;
        strength += 1;
        agility += 1;
        intelligence += 3;
        armor += 1;
        Console.WriteLine("Колдун повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Колдун получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + name + ", Position(X, Y): " + position;
    }
}
