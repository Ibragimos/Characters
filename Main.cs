using System;

class MainClass
{
    public static void Main(string[] args)
    {
        
Peasant peasant = new Peasant("Иван", 100, 10, 5, 3, 2, 1, 0, new Coordinates(0, 1));
        Rogue rogue = new Rogue("Владимир", 80, 20, 10, 4, 2, 1, 0, new Coordinates(4, 1));
        Sniper sniper = new Sniper("Алексей", 90, 30, 8, 5, 1, 1, 0, new Coordinates(1, 1));
        Warlock warlock = new Warlock("Артем", 70, 40, 3, 10, 1, 1, 0, new Coordinates(1, 12));
        Spearman spearman = new Spearman("Михаил", 110, 50, 6, 2, 3, 1, 0, new Coordinates(1, 1));
        Crossbowman crossbowman = new Crossbowman("Николай", 120, 60, 7, 3, 2, 1, 0, new Coordinates(0, 0));
        Monk monk = new Monk("Дмитрий", 130, 70, 8, 5, 2, 1, 0, new Coordinates(5, 1));

        Console.WriteLine(peasant);
        Console.WriteLine(rogue);
        Console.WriteLine(sniper);
        Console.WriteLine(warlock);
        Console.WriteLine(spearman);
        Console.WriteLine(crossbowman);
        Console.WriteLine(monk);

        System.Console.WriteLine();

    //      peasant.Attack();
    //      rogue.Heal();
    //      sniper.Attack();
    //      warlock.Heal();
    //      spearman.Attack();
    //      crossbowman.LevelUp();
    //      monk.GainExperience(200);
    
    }
}