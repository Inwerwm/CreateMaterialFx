using System.Text.RegularExpressions;

namespace MaterialGenerator;
public class MapFileSelector
{
    public NamePattern NamePattern { get; }

    public MapFileSelector()
    {
        NamePattern = new()
        {
            BaseColor = new[] { "diffuse", "basecolor", "base color", "base_color", "albedo" },
            SubSurface = new[] { "scattering" },
            Normal = new[] { "normal" },
            Roughness = new[] { "roughness", "smoothness" },
            Specular = new[] { "specular", "glossiness" },
            Metallic = new[] { "metallic", "metallness" },
            AmbientOcclusion = new[] { "ambientocclusion", "ambient occlusion", "ambient_occlusion" },
            Height = new[] { "height" },
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
            SubSurface = SelectMapFile(NamePattern.SubSurface, sourceDirectoryPath),
            Normal = SelectMapFile(NamePattern.Normal, sourceDirectoryPath),
            Roughness = SelectMapFile(NamePattern.Roughness, sourceDirectoryPath),
            Specular = SelectMapFile(NamePattern.Specular, sourceDirectoryPath),
            Metallic = SelectMapFile(NamePattern.Metallic, sourceDirectoryPath),
            AmbientOcclusion = SelectMapFile(NamePattern.AmbientOcclusion, sourceDirectoryPath),
            Height = SelectMapFile(NamePattern.Height, sourceDirectoryPath),
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
