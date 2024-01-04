// Класс Крестьянина
class Peasant : Character
{
    public Peasant(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("Крестьянин атакует с факелом!");
    }

    public override void Heal()
    {
        Console.WriteLine("Крестьянин не может лечить.");
    }

    public override void LevelUp()
    {
        level++;
        health += 10;
        strength += 2;
        agility += 1;
        intelligence += 1;
        armor += 1;
        Console.WriteLine("Крестьянин повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Крестьянин получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + name;
    }
}