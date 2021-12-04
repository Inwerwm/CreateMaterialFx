namespace UnitTest;

internal static class TestData
{
    public static string Directory { get; } = @"..\..\TestData";

    public static string Get(string filename) => Path.Combine(Directory, filename);
}
