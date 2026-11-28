namespace BookMarkr;

/// <summary>Manages bookmarks in memory for the lifetime of this service instance.</summary>
internal class BookmarkService
{
    private readonly List<Bookmark> _bookmarks = [];

    /// <summary>Adds a link with a nonblank, case-insensitively unique name and a nonblank URL.</summary>
    /// <param name="name">The name used to identify the bookmark.</param>
    /// <param name="url">The destination URL; it is checked for blankness but not URL validity.</param>
    internal void AddLink(string name, string url)
    {
        // Validate inputs here as well as requiring options at the command line.
        if (string.IsNullOrWhiteSpace(name))
        {
            Helper.ShowErrorMessage(["the 'name' for the link is not provided. The expected syntax is:", "bookmarkr link add <name> <url>"]);
            return;
        }

        if (string.IsNullOrWhiteSpace(url))
        {
            Helper.ShowErrorMessage(["the 'url' for the link is not provided. The expected syntax is:", "bookmarkr link add <name> <url>"]);
            return;
        }

        // Names are unique regardless of case; a duplicate leaves the existing link unchanged.
        if (_bookmarks.Any(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
        {
            Helper.ShowWarningMessage([$"A link with the name '{name}' already exists. It will thus not be added",
                                       $"To update the existing link, use the command: bookmarkr link update '{name}' '{url}'"]);
            return;
        }

        _bookmarks.Add(new Bookmark { Name = name, Url = url });
        Helper.ShowSuccessMessage(["Bookmark successfully added!"]);
    }
}
