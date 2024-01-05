using System;
using System.Reflection.Metadata.Ecma335;

class MainClass
{


    public static string Team(List<Character> leftTeam, List<Character> rightTeam, Character character)
    {
        foreach (var item in leftTeam)
        {
            if (character == item) return "leftTeam";
        }
        foreach (var item in rightTeam)
        {
            if (character == item) return "rightTeam";
        }
        return null;
    }

    public static void Main(string[] args)
    {

        Peasant peasant = new Peasant("Ethan", 100, 10, 5, 3, 2, 1, 0, new Coordinates(0, 1));
        Rogue rogue = new Rogue("Olivia", 80, 20, 10, 4, 2, 1, 0, new Coordinates(4, 1));
        Sniper sniper = new Sniper("Noah", 90, 30, 8, 5, 1, 1, 0, new Coordinates(1, 1));
        Warlock warlock = new Warlock("Ava", 70, 40, 3, 10, 1, 1, 0, new Coordinates(1, 12));
        Spearman spearman = new Spearman("Samuel", 110, 50, 6, 2, 3, 1, 0, new Coordinates(1, 1));
        Crossbowman crossbowman = new Crossbowman("Charlotte", 120, 60, 7, 3, 2, 1, 0, new Coordinates(0, 0));
        Monk monk = new Monk("Benjamin", 130, 70, 8, 5, 2, 1, 0, new Coordinates(5, 1));

        List<Character> leftTeam = new List<Character>();
        List<Character> rightTeam = new List<Character>();

        leftTeam.Add(sniper);
        rightTeam.Add(rogue);

 Character nearestEnemy = sniper.FindNearestEnemy(rightTeam);

        if (nearestEnemy != null)
        {
            Console.WriteLine($"The nearest enemy to the sniper is {nearestEnemy.GetName()} at position {nearestEnemy.GetPosition().X}, {nearestEnemy.GetPosition().Y}.");
        }



        Console.WriteLine(peasant);
        Console.WriteLine($"{rogue}, team: {Team(leftTeam, rightTeam, rogue)}");
        Console.WriteLine($"{sniper}, team: {Team(leftTeam, rightTeam, sniper)}");
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