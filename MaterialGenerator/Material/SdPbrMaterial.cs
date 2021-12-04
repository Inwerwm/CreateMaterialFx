namespace MaterialGenerator.Material;

public class SdPbrMaterial
{
    public string? BaseColor { get; private set; }
    public string? Normal { get; private set; }
    public string? Roughness { get; private set; }
    public string? Metallic { get; private set; }
    public string? Height { get; private set; }
    public string? AmbientOcclusion { get; private set; }
    public string? Specular { get; private set; }

    public SdPbrMaterial(string sourceDirectory, string embeddedPath, MapFileSelector selector) : this(sourceDirectory, embeddedPath, selector, new()) { }

    public SdPbrMaterial(string sourceDirectory, string embeddedPath, MapFileSelector selector, MaterialOptions options)
    {

    }

    public void Write(string path)
    {
        throw new NotImplementedException();
    }
}
