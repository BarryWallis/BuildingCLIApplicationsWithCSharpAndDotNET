///* dotnet run */
//HelloWorld();

///* dotnet run Packt */
//PassingOneParameter(args);

///* dotnet run Packt Publishing */
//PassingMoreThanOneParameter(args);

///* dotnet run 42 */
//ParsingInputParameters(args);

///* dotnet run Packt Publishing */
//SwitchingInputParameters(args);

///* dotnet run */
//MissingInputParameter(args);

///* dotnet run */
//ConsoleProperties();

///* dotnet run */
//ReadLine();

///* dotnet run */
//ReadKeyTrue();

///* dotnet run */
//ReadKeyFalse();

///* dotnet run */
//Clear();

///* dotnet run */
//CancelKeyPress();


#pragma warning disable CS8321 // Local function is declared but never used
// Print a greeting without using command-line arguments.
static void HelloWorld()
{
    Console.WriteLine("Hello, World!");
}

// Use the first command-line argument as the name in the greeting.
static void PassingOneParameter(string[] args)
{
    Console.WriteLine($"Hello, {args[0]}!");
}

// Combine the first two command-line arguments in a greeting.
static void PassingMoreThanOneParameter(string[] args)
{
    Console.WriteLine($"Hello, {args[0]} {args[1]}!");
}

// Parse the first command-line argument as an integer and display its type before and after parsing.
static void ParsingInputParameters(string[] args)
{
    string value = args[0];
    Console.WriteLine($"The input value {value} is of type {value.GetType()}");
    int parsedValue = int.Parse(value);
    Console.WriteLine($"The parsed value {parsedValue} is of type {parsedValue.GetType()}");
}

// Display the first two arguments in reverse order without changing the args array.
static void SwitchingInputParameters(string[] args)
{
    Console.WriteLine($"Before switching => {args[0]} {args[1]}");

    Console.WriteLine($"After switching => {args[1]} {args[0]}");
}

// Access the first argument without checking that one was supplied.
static void MissingInputParameter(string[] args)
{
    Console.WriteLine($"Hello, {args[0]}!");
}

static void ConsoleProperties()
{
    // performing a backup of the background and foreground colors
    ConsoleColor originalBackgroundColor = Console.BackgroundColor;
    ConsoleColor originalForegroundColor = Console.ForegroundColor;

    // changing the background and foreground colors
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.Yellow;

    // setting the title of the terminal while the application is running 
    Console.Title = "Packt Publishing Console App";

    // displaying a message
    Console.WriteLine($"Hello from Packt Publishing!");

    // restoring the background and foreground colors to their original values
    Console.BackgroundColor = originalBackgroundColor;
    Console.ForegroundColor = originalForegroundColor;

    Console.WriteLine("Press any key to exit...");
    // waiting for the user to press a key to end the program.
    // this is useful to see the altering of the terminal's title
    _ = Console.ReadKey(true);
}

// Read and echo lines until the user submits an empty line.
static void ReadLine()
{
    Console.WriteLine("enter some text then hit ENTER, or simply hit ENTER to end the program");

    string? line;
    while ((line = Console.ReadLine()) != "")
    {
        Console.WriteLine(line);
    }

    // if we reach this point, it means that the user has hit ENTER without entering any text.
    Console.WriteLine("bye!");
}

// Read keys without echoing them; stop when Escape is pressed.
static void ReadKeyTrue()
{
    Console.WriteLine("Press any key or ESC to exit...");

    ConsoleKey keyPressed = Console.ReadKey(true).Key;

    while (keyPressed != ConsoleKey.Escape)
    {
        Console.WriteLine($"you pressed {keyPressed}");
        keyPressed = Console.ReadKey(true).Key;
    }
}

// Read keys with console echo enabled; stop when Escape is pressed.
static void ReadKeyFalse()
{
    Console.WriteLine("Press any key or ESC to exit...");

    ConsoleKey keyPressed = Console.ReadKey(false).Key;

    while (keyPressed != ConsoleKey.Escape)
    {
        Console.WriteLine($"you pressed {keyPressed}");
        keyPressed = Console.ReadKey(false).Key;
    }
}

// Print sample text and clear the console only when the user presses C.
static void Clear()
{
    string lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut " +
        "enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
        "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa " +
        "qui officia deserunt mollit anim id est laborum.";
    Console.WriteLine(lorem);
    Console.WriteLine();

    Console.WriteLine("Press [C] to clear the screen...");
    if (Console.ReadKey(true).Key == ConsoleKey.C)
    {
        Console.Clear();
    }
}

// Handle Ctrl+C, report the event, and terminate the application.
static void CancelKeyPress()
{
    Console.CancelKeyPress += (sender, e) =>
    {
        e.Cancel = true; // prevent the application from terminating
        Console.WriteLine("CancelKeyPress event raised!\nPerforming cleanup...");
        Environment.Exit(0);
    };


    int counter = 1;
    while (true)
    {
        // waiting for the user to press CTRL+C
        Console.WriteLine($"Printing line number {counter++}");
        Task delayTask = Task.Run(async () => await Task.Delay(1000));
        delayTask.Wait();
    }
}

#pragma warning restore CS8321 // Local function is declared but never used
