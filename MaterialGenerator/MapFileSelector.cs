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

    public MapFiles SelectMapFiles(string sourceDirectoryPath) => new()
    {
        BaseColor = SelectMapFile(NamePattern.BaseColor, sourceDirectoryPath),
        Normal = SelectMapFile(NamePattern.Normal, sourceDirectoryPath),
        Height = SelectMapFile(NamePattern.Height, sourceDirectoryPath),
        Metallic = SelectMapFile(NamePattern.Metallic, sourceDirectoryPath),
        Roughness = SelectMapFile(NamePattern.Roughness, sourceDirectoryPath),
        AmbientOcclusion = SelectMapFile(NamePattern.AmbientOcclusion, sourceDirectoryPath),
        Specular = SelectMapFile(NamePattern.Specular, sourceDirectoryPath)
    };

    private string? SelectMapFile(IEnumerable<string> pattern, string sourcePath)
    {
        throw new NotImplementedException();
    }
}
