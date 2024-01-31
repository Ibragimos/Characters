public static class View
{
    public static void PrintColor(string text, string color)
    {
        Console.WriteLine($"{color}{text}{AnsiColors.RESET}");
    }

    public static void PrintRed(string text)
    {
        PrintColor(text, AnsiColors.RED);
    }

    public static void PrintGreen(string text)
    {
        PrintColor(text, AnsiColors.GREEN);
    }

    public static void PrintYellow(string text)
    {
        PrintColor(text, AnsiColors.YELLOW);
    }

    public static void PrintBlue(string text)
    {
        PrintColor(text, AnsiColors.BLUE);
    }

    public static void PrintPurple(string text)
    {
        PrintColor(text, AnsiColors.PURPLE);
    }

    public static void PrintCyan(string text)
    {
        PrintColor(text, AnsiColors.CYAN);
    }

    public static void PrintWhite(string text)
    {
        PrintColor(text, AnsiColors.WHITE);
    }
}