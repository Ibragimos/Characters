using System;
using System.Collections.Generic;
using System.Diagnostics;

class MainClass
{
    public static string Team(List<Character> leftTeam, List<Character> rightTeam, Character character)
    {
        if (leftTeam.Contains(character))
        {
            return "leftTeam";
        }
        else if (rightTeam.Contains(character))
        {
            return "rightTeam";
        }
        
        return null;
    }

    public static List<Character> TeamSide(List<Character> leftTeam, List<Character> rightTeam, Character characterTeam)
    {
        List<Character> team;
        if (leftTeam.Contains(characterTeam))
        {
            team = rightTeam;
        }
        else
        {
            team = leftTeam;
        }

        return null;
    }



    public static void CharacterInitiation(List<Character> characters)
    {
        characters.Sort((a, b) => b.GetInitiative().CompareTo(a.GetInitiative()));

        foreach (Character character in characters)
        {
            int initiativeLevel = character.GetInitiative();

            switch (initiativeLevel)
            {
                case 0:
                    System.Console.WriteLine($"{character} walks last");
                    break;
                case 1:
                    System.Console.WriteLine($"{character} coming in third");
                    break;
                case 2:
                    System.Console.WriteLine($"{character} coming second");
                    break;
                case 3:
                    System.Console.WriteLine($"{character} goes first");
                    break;
                default:
                    System.Console.WriteLine($"Unknown initiation level for {character}");
                    break;
            }
        }
    }
    public static void Main(string[] args)
    {
        List<Character> leftTeam = new List<Character>();
        List<Character> rightTeam = new List<Character>();
        List<Character> team;
        Character? characterTeam = null;

        if (leftTeam.Contains(characterTeam!))
        {
            team = rightTeam;
        }
        else
        {
            team = leftTeam;
        }

        Peasant peasant = new Peasant("Ethan", 100, 10, 5, 3, 2, 1, 0, new Coordinates(0, 1), 0);
        Rogue rogue = new Rogue("Olivia", 80, 20, 10, 4, 2, 1, 0, new Coordinates(4, 1), 2, team);
        Sniper sniper = new Sniper("Noah", 90, 30, 8, 5, 1, 1, 0, new Coordinates(1, 1), 3, team);
        Warlock warlock = new Warlock("Ava", 70, 40, 3, 10, 1, 1, 0, new Coordinates(1, 12), 1);
        Spearman spearman = new Spearman("Samuel", 110, 50, 6, 2, 3, 1, 0, new Coordinates(1, 1), 2, team);
        Crossbowman crossbowman = new Crossbowman("Charlotte", 120, 60, 7, 3, 2, 1, 0, new Coordinates(0, 0), 3, team);
        Monk monk = new Monk("Benjamin", 130, 70, 8, 5, 2, 1, 0, new Coordinates(5, 1), 2, team);

        List<Character> characters = new List<Character>
        {
            peasant,
            rogue,
            sniper,
            warlock,
            spearman,
            crossbowman,
            monk
        };


        foreach (Character character in characters)
        {
            if (leftTeam.Count < 4)
            {
                leftTeam.Add(character);
            }
            else
            {
                rightTeam.Add(character);
            }
        }

        Character nearestEnemySniper = sniper.FindNearestEnemySniper(rightTeam);
        Character nearestEnemyCrossbowman = crossbowman.FindNearestEnemyCrossbowman(rightTeam);
        sniper.Step();
        System.Console.WriteLine();
        crossbowman.Step();
        System.Console.WriteLine();
        rogue.Step();
        System.Console.WriteLine();
        spearman.Step();
        System.Console.WriteLine();
        monk.Step();
        System.Console.WriteLine();

        Console.WriteLine($"{peasant}, team: {Team(leftTeam, rightTeam, peasant)}");
        Console.WriteLine($"{rogue}, team: {Team(leftTeam, rightTeam, rogue)}");
        Console.WriteLine($"{sniper}, team: {Team(leftTeam, rightTeam, sniper)}");
        Console.WriteLine($"{warlock}, team: {Team(leftTeam, rightTeam, warlock)}");
        Console.WriteLine($"{spearman}, team: {Team(leftTeam, rightTeam, spearman)}");
        Console.WriteLine($"{crossbowman}, team: {Team(leftTeam, rightTeam, crossbowman)}");
        Console.WriteLine($"{monk}, team: {Team(leftTeam, rightTeam, monk)}");
        System.Console.WriteLine();

        CharacterInitiation(characters);

    }
}