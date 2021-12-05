namespace MaterialGenerator.Material;

public abstract class MaterialBase
{
    public string? BaseColor { get; private set; }
    public string? Normal { get; private set; }
    public string? Roughness { get; private set; }
    public string? Specular { get; private set; }
    public string? Metallic { get; private set; }
    public string? Height { get; private set; }
    public string? AmbientOcclusion { get; private set; }

    protected MaterialBase(string sourceDirectory, string embeddedPath, MapFileSelector selector)
    {
        var dir = embeddedPath + Path.GetFileName(sourceDirectory) + "/";
        var filenames = selector.SelectMapFiles(sourceDirectory);

        BaseColor = dir + filenames.BaseColor;
        Normal = dir + filenames.Normal;
        Roughness = dir + filenames.Roughness;
        Specular = dir + filenames.Specular;
        Metallic = dir + filenames.Metallic;
        Height = dir + filenames.Height;
        AmbientOcclusion = dir + filenames.AmbientOcclusion;
    }

    public abstract void Write(string path);
}