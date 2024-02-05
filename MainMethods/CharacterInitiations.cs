public static class CharacterInitiations
{
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

}
