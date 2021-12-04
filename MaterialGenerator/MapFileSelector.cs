using System.Text.RegularExpressions;

namespace MaterialGenerator;
public class MapFileSelector
{
    public NamePattern NamePattern { get; }

    public MapFileSelector()
    {
        NamePattern = new NamePattern()
        {
            BaseColor = new[] { "diffuse", "basecolor", "base_color", "albedo" },
            Normal = new[] { "normal" },
            Height = new[] { "height" },
            Metallic = new[] { "metallic", "metallness" },
            Roughness = new[] { "roughness", "smoothness" },
            AmbientOcclusion = new[] { "ambientocclusion", "ambient_occlusion" },
            Specular = new[] { "specular", "glossiness" }
        };
    }

    public MapFileSelector(NamePattern namePattern)
    {
        NamePattern = namePattern;
    }

    public MapFiles SelectMapFiles(string sourceDirectoryPath)
    {
        if (!Directory.Exists(sourceDirectoryPath)) throw new DirectoryNotFoundException($"Directory not found: {sourceDirectoryPath}");

        return new()
        {
            BaseColor = SelectMapFile(NamePattern.BaseColor, sourceDirectoryPath),
            Normal = SelectMapFile(NamePattern.Normal, sourceDirectoryPath),
            Height = SelectMapFile(NamePattern.Height, sourceDirectoryPath),
            Metallic = SelectMapFile(NamePattern.Metallic, sourceDirectoryPath),
            Roughness = SelectMapFile(NamePattern.Roughness, sourceDirectoryPath),
            AmbientOcclusion = SelectMapFile(NamePattern.AmbientOcclusion, sourceDirectoryPath),
            Specular = SelectMapFile(NamePattern.Specular, sourceDirectoryPath)
        };
    }

    private string? SelectMapFile(IEnumerable<string> patterns, string sourcePath)
    {
        var files = Directory.EnumerateFiles(sourcePath).Select(path => Path.GetFileName(path));
        var pattern = $"({string.Join("|", patterns)})";
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        return files.FirstOrDefault(filename => regex.IsMatch(filename));
    }
}
