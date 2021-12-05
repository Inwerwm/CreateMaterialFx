using System.Text;

namespace MaterialGenerator.Material;

public class SdPbrMaterial : MaterialBase
{
    public SdPbrMaterial(string sourceDirectory, string embeddedPath, MapFileSelector selector) : base(sourceDirectory, embeddedPath, selector) { }

    public override void Write(string path)
    {
        File.WriteAllText(path, GenerateCode());
    }

    private string GenerateCode()
    {
        StringBuilder str = new(2048);
        str.Append(@"#define SDPBR_MATERIAL_VER 100
#include ""../../shader/sdPBRMaterialHead.fxsub""

void SetMaterialParam(inout Material m, float3 n,float3 l, float3 Eye, float2 uv)
{
    float loopNum = 10;
    m.baseColorLoops = loopNum;
    m.sssLoops = loopNum;
    m.normalLoops = loopNum;
    m.roughnessLoops = loopNum;
    m.specularLoops = loopNum;
    m.metallicLoops = loopNum;
    m.aoLoops = loopNum;
    m.heightLoops = loopNum;

    m.baseColor = 1.0;
    m.subsurface = 1.0;
    m.normalScale = 1.0;
    m.roughness = 1.0;
    m.specular = 1.0;
    m.metallic = 1.0;
    m.aoScale = 1.0;
    m.heightScale = 0.001;
}

");

        if(BaseColor != null)
        {
            str.AppendLine("#define BASECOLOR_FROM BASECOLOR_FROM_FILE");
            str.AppendLine($"#define BASECOLOR_FILE \"{BaseColor}\"");
            str.Append(Environment.NewLine);
        }
        if(SubSurface != null)
        {
            str.AppendLine("#define SUBSURFACE_FROM SUBSURFACE_FROM_FILE");
            str.AppendLine($"#define SUBSURFACE_FILE \"{SubSurface}\"");
            str.Append(Environment.NewLine);
        }
        if (Normal != null)
        {
            str.AppendLine("#define NORMAL_FROM NORMAL_FROM_FILE");
            str.AppendLine($"#define NORMAL_FILE \"{Normal}\"");
            str.Append(Environment.NewLine);
        }
        if (Roughness != null)
        {
            str.AppendLine("#define ROUGHNESS_FROM ROUGHNESS_FROM_FILE");
            str.AppendLine($"#define ROUGHNESS_FILE \"{Roughness}\"");
            str.Append(Environment.NewLine);
        }
        if (Specular != null)
        {
            str.AppendLine("#define SPECULAR_FROM SPECULAR_FROM_FILE");
            str.AppendLine($"#define SPECULAR_FILE \"{Specular}\"");
            str.Append(Environment.NewLine);
        }
        if (Metallic != null)
        {
            str.AppendLine("#define METALLIC_FROM METALLIC_FROM_FILE");
            str.AppendLine($"#define METALLIC_FILE \"{Metallic}\"");
            str.Append(Environment.NewLine);
        }
        if (AmbientOcclusion != null)
        {
            str.AppendLine("#define AO_FROM AO_FROM_FILE");
            str.AppendLine($"#define AO_FILE \"{AmbientOcclusion}\"");
            str.Append(Environment.NewLine);
        }
        if (Height != null)
        {
            str.AppendLine("#define HEIGHT_FROM HEIGHT_FROM_FILE");
            str.AppendLine($"#define HEIGHT_FILE \"{Height}\"");
            str.Append(Environment.NewLine);
        }

        str.Append($"#include \"../../shader/sdPBRMaterialTail.fxsub\"");

        return str.ToString();
    }
}
