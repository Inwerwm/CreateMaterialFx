namespace MaterialGenerator.Material;

public class SdPbrMaterial : MaterialBase
{
    public SdPbrMaterial(string sourceDirectory, string embeddedPath, MapFileSelector selector) : base(sourceDirectory, embeddedPath, selector) { }

    public override void Write(string path)
    {
        throw new NotImplementedException();
    }
}
