namespace MaterialGenerator.Material;

public abstract class MaterialBase
{
    public string? BaseColor { get; private set; }
    public string? Normal { get; private set; }
    public string? Roughness { get; private set; }
    public string? Metallic { get; private set; }
    public string? Height { get; private set; }
    public string? AmbientOcclusion { get; private set; }
    public string? Specular { get; private set; }

    protected MaterialBase(string sourceDirectory, string embeddedPath, MapFileSelector selector)
    {

    }

    public abstract void Write(string path);
}