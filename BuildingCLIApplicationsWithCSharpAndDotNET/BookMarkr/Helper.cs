/// <summary>Writes status messages in severity-specific colors and restores the previous console color.</summary>
internal static class Helper
{
    /// <summary>Writes each error message in red.</summary>
    /// <param name="errorMessages">The lines to display.</param>
    public static void ShowErrorMessage(string[] errorMessages)
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        foreach (string message in errorMessages)
        {
            Console.WriteLine(message);
        }
        Console.ForegroundColor = color;
    }

    /// <summary>Writes each warning message in yellow.</summary>
    /// <param name="errorMessages">The lines to display.</param>
    public static void ShowWarningMessage(string[] errorMessages)
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (string message in errorMessages)
        {
            Console.WriteLine(message);
        }
        Console.ForegroundColor = color;
    }

    /// <summary>Writes each success message in green.</summary>
    /// <param name="errorMessages">The lines to display.</param>
    public static void ShowSuccessMessage(string[] errorMessages)
    {
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (string message in errorMessages)
        {
            Console.WriteLine(message);
        }
        Console.ForegroundColor = color;
    }
}