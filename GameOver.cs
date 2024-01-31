
public class GameOver
{
 public void GameOverWinner(List<Character> leftTeam, List<Character> rightTeam)
    {
        bool anyLeftTeamAlive = leftTeam.Any(character => character.Heal() > 0);
        bool anyRightTeamAlive = rightTeam.Any(character => character.Heal() > 0);
        View.PrintRed("Game Over");

        if (anyLeftTeamAlive && !anyRightTeamAlive)
        {
            View.PrintBlue("Left team is the winner!");
        }
        else if (anyRightTeamAlive && !anyLeftTeamAlive)
        {
            View.PrintGreen("Right team is the winner!");
        }
        else
        {
            View.PrintPurple("It's a draw! Both teams lost.");
        }
    }
}

