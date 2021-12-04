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
}
