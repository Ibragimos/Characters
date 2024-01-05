// Класс Арбалетчика
class Crossbowman : Character
{
    public Crossbowman(string name, int health, int strength, int agility,
                   int intelligence, int armor, int level, int experience,
                   Coordinates position)
        : base(name, health, strength, agility, intelligence, armor, level, experience, position)
        {
    }

    public override void Attack()
    {
        Console.WriteLine("Арбалетчик атакует арбалетом!");
    }

    public override void Heal()
    {
        Console.WriteLine("Арбалетчик не может лечить.");
    }

    public override void LevelUp()
    {
        level++;
        health += 18;
        strength += 4;
        agility += 3;
        intelligence += 1;
        armor += 2;
        Console.WriteLine("Арбалетчик повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Арбалетчик получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + name + ", Position(X, Y): " + position;
    }
}
