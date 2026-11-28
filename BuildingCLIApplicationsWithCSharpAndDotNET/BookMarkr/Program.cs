using BookMarkr;
using System.CommandLine;

// Bookmarks live in this service only for the lifetime of the process.
BookmarkService service = new();

// The root action runs when no subcommand is selected.
RootCommand rootCommand = new("Bookmarkr is a bookmark manager provided as a CLI application.")
{
};
rootCommand.SetAction(OnHandleRootCommand);

// Group link-related operations under the "link" command.
Command linkCommand = new("link", "Manage bookmarks links")
{
};
rootCommand.Subcommands.Add(linkCommand);

// Both options are required; each also has a short alias.
Option<string> nameOption = new("--name", "-n")
{
    Description = "The name of the bookmark",
    Required = true
};
Option<string> urlOption = new("--url", "-u")
{
    Description = "The URL of the bookmark",
    Required = true
};
// Bind the options and action to "link add", rather than to the parent command.
Command addLinkCommand = new("add", "Add a new bookmark link")
{
    nameOption, urlOption
};
linkCommand.Subcommands.Add(addLinkCommand);
addLinkCommand.SetAction(OnHandleAddLinkCommand);

// The parser checks required options before the handler reads their values.
void OnHandleAddLinkCommand(ParseResult result)
{
    service.AddLink(result.GetRequiredValue(nameOption), result.GetRequiredValue(urlOption));
}

// Parse the command line, invoke its selected action, and return the resulting exit code.
return await rootCommand.Parse(args).InvokeAsync();

static void OnHandleRootCommand(ParseResult result)
{
    Console.WriteLine("Hello from the root command!");
}
