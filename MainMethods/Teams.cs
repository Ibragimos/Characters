public static class Teams
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
}
