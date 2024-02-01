using System;
using System.Collections.Generic;
using System.Diagnostics;

class MainClass
{
    public static void Main(string[] args)
    {
        List<Character> leftTeam = new List<Character>();
        List<Character> rightTeam = new List<Character>();
        List<Character> team;
        Character? characterTeam = null;
        List<Peasant> peasantList = new List<Peasant>();

        if (leftTeam.Contains(characterTeam!))
        {
            team = rightTeam;
        }
        else
        {
            team = leftTeam;
        }

        Peasant peasant = new Peasant("Ethan", 100, 10, 5, 3, 2, 1, 0, new Coordinates(0, 1), 0, team);
        Rogue rogue = new Rogue("Olivia", 80, 20, 10, 4, 2, 1, 0, new Coordinates(4, 1), 2, team);
        Sniper sniper = new Sniper("Noah", 90, 30, 8, 5, 1, 1, 0, new Coordinates(1, 1), 3, team, peasantList);
        Warlock warlock = new Warlock("Ava", 70, 40, 3, 10, 1, 1, 0, new Coordinates(1, 3), 1, team);
        Spearman spearman = new Spearman("Samuel", 110, 50, 6, 2, 3, 1, 0, new Coordinates(1, 1), 2, team);
        Crossbowman crossbowman = new Crossbowman("Charlotte", 120, 60, 7, 3, 2, 1, 0, new Coordinates(0, 0), 3, team, peasantList);
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

        peasantList.Add(peasant);


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

        View.PrintGreen("***leftTeam = Green***");
        foreach (Character player in leftTeam)
        {
            View.PrintGreen(player.GetName());
        }

        View.PrintBlue("***leftTeam = Blue***");
        foreach (Character player in rightTeam)
        {
            View.PrintBlue(player.GetName());
        }


        Character nearestEnemySniper = sniper.FindNearestEnemySniper(rightTeam);
        Character nearestEnemyCrossbowman = crossbowman.FindNearestEnemyCrossbowman(rightTeam);
        
        sniper.Step();
        sniper.HealString();
        System.Console.WriteLine();
        crossbowman.Step();
        crossbowman.HealString();
        System.Console.WriteLine();
        rogue.Step();
        rogue.HealString();
        System.Console.WriteLine();
        spearman.Step();
        spearman.HealString();
        System.Console.WriteLine();
        monk.Step();
        monk.HealString();
        System.Console.WriteLine();
        peasant.Step();
        peasant.HealString();
        System.Console.WriteLine();
        warlock.Step();
        warlock.HealString();
        System.Console.WriteLine();

        Console.WriteLine($"{peasant}, team: {Teams.Team(leftTeam, rightTeam, peasant)}");
        Console.WriteLine($"{rogue}, team: {Teams.Team(leftTeam, rightTeam, rogue)}");
        Console.WriteLine($"{sniper}, team: {Teams.Team(leftTeam, rightTeam, sniper)}");
        Console.WriteLine($"{warlock}, team: {Teams.Team(leftTeam, rightTeam, warlock)}");
        Console.WriteLine($"{spearman}, team: {Teams.Team(leftTeam, rightTeam, spearman)}");
        Console.WriteLine($"{crossbowman}, team: {Teams.Team(leftTeam, rightTeam, crossbowman)}");
        Console.WriteLine($"{monk}, team: {Teams.Team(leftTeam, rightTeam, monk)}");
        System.Console.WriteLine();

        CharacterInitiations.CharacterInitiation(characters);

        GameOver gameOver = new GameOver();
        gameOver.GameOverWinner(leftTeam, rightTeam);

    }
}