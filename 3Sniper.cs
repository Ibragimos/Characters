// Класс Снайпера
class Sniper : Character
{
    public Sniper(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("Снайпер атакует снайперской винтовкой!");
    }

    public override void Heal()
    {
        Console.WriteLine("Снайпер не может лечить.");
    }

    public override void LevelUp()
    {
        level++;
        health += 12;
        strength += 2;
        agility += 3;
        intelligence += 1;
        armor += 1;
        Console.WriteLine("Снайпер повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Снайпер получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + name;
    }
}