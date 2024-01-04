// Класс Копейщика
class Spearman : Character
{
    public Spearman(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
    {
    }

    public override void Attack()
    {
        Console.WriteLine("Копейщик атакует копьем!");
    }

    public override void Heal()
    {
        Console.WriteLine("Копейщик не может лечить.");
    }

    public override void LevelUp()
    {
        level++;
        health += 20;
        strength += 5;
        agility += 2;
        intelligence += 1;
        armor += 3;
        Console.WriteLine("Копейщик повысил уровень! Текущий уровень: " + level);
    }

    public override void GainExperience(int amount)
    {
        experience += amount;
        Console.WriteLine("Копейщик получил " + amount + " опыта! Текущий опыт: " + experience);
    }

    public override string ToString()
    {
        return this.GetType().Name + ": " + name;
    }
}