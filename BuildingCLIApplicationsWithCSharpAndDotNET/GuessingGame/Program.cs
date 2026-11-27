/*
Change the title of the terminal window to GUESSING GAME!

Generate a random integer value between 1 and 20

Tells the player that they have three chances to figure out that number

After each player’s trial, it should then do the following:
    If the player figured out the number, the program displays, in green text, Congratulations, you won!, along with the number of trials it took the 
        player to figure it out
    If the player was not able to figure out the number within the three granted trials, the program should display, in red text, Better luck next time!
        The number to be guessed was along with the value to be guessed
    If the player hits Enter without providing a number, the program should consider that the value is zero and proceed with it
    If the player hits Ctrl + C, the program should exit and display, in yellow text, Thank you for playing!
*/
Console.Title = "Guessing Game!";
const int UpperBound = 20;
ConsoleColor originalForegroundColor = Console.ForegroundColor;
Random random = new();

// Handle Ctrl+C ourselves so the farewell message is displayed before the program exits.
Console.CancelKeyPress += (sender, e) =>
{
    e.Cancel = true;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Thank you for playing!");
    Console.WriteLine();
    Console.ForegroundColor = originalForegroundColor;
    Environment.Exit(0);
};


Console.WriteLine($"Welcome to the Guessing Game! You have three chances to guess the number between 1 and {UpperBound}.");
// Random.Next excludes its upper bound, so add one to include UpperBound in the range.
int number = random.Next(1, UpperBound + 1);
bool winner = false;
int i;
// Keep the attempt number available after the loop for the winning message.
for (i = 1; i <= 3; i++)
{
    Console.Write($"Your guess: ");
    if (int.TryParse(Console.ReadLine(), out int guess))
    {
        if (guess == number)
        {
            winner = true;
            break;
        }
    }
}

if (winner)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"Congratulations, you won! It took you {i} tries.");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Better luck next time!");
}

Console.ForegroundColor = originalForegroundColor;
