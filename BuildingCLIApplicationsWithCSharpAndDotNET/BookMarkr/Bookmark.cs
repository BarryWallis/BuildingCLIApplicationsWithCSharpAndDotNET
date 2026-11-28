namespace BookMarkr;

/// <summary>Represents a named link held by the bookmark service.</summary>
internal class Bookmark
{
    /// <summary>Gets or sets the name used to identify the bookmark.</summary>
    public required string Name { get; set; }

    /// <summary>Gets or sets the bookmark's destination URL.</summary>
    public required string Url { get; set; }
}
