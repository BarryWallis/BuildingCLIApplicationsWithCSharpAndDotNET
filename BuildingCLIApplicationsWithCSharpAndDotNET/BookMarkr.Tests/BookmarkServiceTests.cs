using System.Collections;
using System.Reflection;

namespace BookMarkr.Tests;

[TestClass]
[DoNotParallelize]
public sealed class BookmarkServiceTests
{
    private static readonly Type ServiceType = Assembly.Load("BookMarkr").GetType("BookMarkr.BookmarkService", throwOnError: true)!;
    private static readonly MethodInfo AddLinkMethod = ServiceType.GetMethod("AddLink", BindingFlags.Instance | BindingFlags.NonPublic)!;
    private static readonly FieldInfo BookmarksField = ServiceType.GetField("_bookmarks", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private readonly object _service = Activator.CreateInstance(ServiceType, nonPublic: true)!;

    [TestMethod]
    public void AddLink_ValidBookmark_AddsBookmarkAndReportsSuccess()
    {
        string output = InvokeAddLink("Docs", "https://example.test/docs");

        Assert.HasCount(1, Bookmarks);
        Assert.AreEqual("Docs", GetBookmarkProperty(0, "Name"));
        Assert.AreEqual("https://example.test/docs", GetBookmarkProperty(0, "Url"));
        Assert.AreEqual("Bookmark successfully added!" + Environment.NewLine, output);
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow(" \t")]
    public void AddLink_BlankName_DoesNotAddBookmarkAndReportsError(string? name)
    {
        string output = InvokeAddLink(name, "https://example.test/docs");

        Assert.IsEmpty(Bookmarks);
        Assert.AreEqual(
            "the 'name' for the link is not provided. The expected syntax is:" + Environment.NewLine +
            "bookmarkr link add <name> <url>" + Environment.NewLine,
            output);
    }

    [TestMethod]
    [DataRow(null)]
    [DataRow("")]
    [DataRow(" \t")]
    public void AddLink_BlankUrl_DoesNotAddBookmarkAndReportsError(string? url)
    {
        string output = InvokeAddLink("Docs", url);

        Assert.IsEmpty(Bookmarks);
        Assert.AreEqual(
            "the 'url' for the link is not provided. The expected syntax is:" + Environment.NewLine +
            "bookmarkr link add <name> <url>" + Environment.NewLine,
            output);
    }

    [TestMethod]
    public void AddLink_DuplicateNameIgnoringCase_PreservesBookmarkAndReportsWarning()
    {
        InvokeAddLink("Docs", "https://example.test/original");

        string output = InvokeAddLink("dOcS", "https://example.test/replacement");

        Assert.HasCount(1, Bookmarks);
        Assert.AreEqual("Docs", GetBookmarkProperty(0, "Name"));
        Assert.AreEqual("https://example.test/original", GetBookmarkProperty(0, "Url"));
        Assert.AreEqual(
            "A link with the name 'dOcS' already exists. It will thus not be added" + Environment.NewLine +
            "To update the existing link, use the command: bookmarkr link update 'dOcS' 'https://example.test/replacement'" + Environment.NewLine,
            output);
    }

    private IList Bookmarks => (IList)BookmarksField.GetValue(_service)!;

    private object? GetBookmarkProperty(int index, string propertyName) =>
        Bookmarks[index]!.GetType().GetProperty(propertyName)!.GetValue(Bookmarks[index]);

    private string InvokeAddLink(string? name, string? url)
    {
        TextWriter originalOutput = Console.Out;
        using StringWriter output = new();
        Console.SetOut(output);

        try
        {
            AddLinkMethod.Invoke(_service, [name, url]);
            return output.ToString();
        }
        finally
        {
            Console.SetOut(originalOutput);
        }
    }
}