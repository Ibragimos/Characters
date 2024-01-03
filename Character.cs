abstract class Character
{
    protected string name;
    protected int health;
    protected int strength;
    protected int agility;
    protected int intelligence;
    protected int armor;
    protected int level;
    protected int experience;

    public Character(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience)
    {
        this.name = name;
        this.health = health;
        this.strength = strength;
        this.agility = agility;
        this.intelligence = intelligence;
        this.armor = armor;
        this.level = level;
        this.experience = experience;
    }

    public abstract void Attack();

    public abstract void Heal();

    public abstract void LevelUp();

    public abstract void GainExperience(int amount);

    public override string ToString()
    {
        return name;
    }
}

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

// Класс Разбойника
class Rogue : Character
{
    public Rogue(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
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
        return this.GetType().Name + ": " + name;
    }
}

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

// Класс Колдуна
class Warlock : Character
{
    public Warlock(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
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
        return this.GetType().Name + ": " + name;
    }
}

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

// Класс Арбалетчика
class Crossbowman : Character
{
    public Crossbowman(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
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
        return this.GetType().Name + ": " + name;
    }
}

// Класс Монаха
class Monk : Character
{
    public Monk(string name, int health, int strength, int agility, int intelligence, int armor, int level, int experience) : base(name, health, strength, agility, intelligence, armor, level, experience)
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
        return this.GetType().Name + ": " + name;
    }
}