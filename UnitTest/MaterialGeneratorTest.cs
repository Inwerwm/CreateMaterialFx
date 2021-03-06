using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace UnitTest;
[TestClass]
public class MaterialGeneratorTest
{
    [TestMethod]
    public void TestGenerate()
    {
        SdPbrMaterial aluminium = new(TestData.Get("Source/Aluminium"), "../../../../_JulioSillet/Map", new MapFileSelector());

        aluminium.Write(TestData.Get("Result/Aluminium.fx"), true);

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        var aluminiumMaterial = File.ReadAllText(TestData.Get("Result/Aluminium.fx"), Encoding.GetEncoding("Shift_JIS"));

        Assert.AreEqual(@"#define SDPBR_MATERIAL_VER 100
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
    m.metallic = 0.0;
    m.aoScale = 1.0;
    m.heightScale = 0.005;
}

#define BASECOLOR_FROM BASECOLOR_FROM_FILE
#define BASECOLOR_FILE ""../../../../_JulioSillet/Map/Aluminium/Aluminium_baseColor.png""

#define NORMAL_FROM NORMAL_FROM_FILE
#define NORMAL_FILE ""../../../../_JulioSillet/Map/Aluminium/Aluminium_normal.png""

#define ROUGHNESS_FROM ROUGHNESS_FROM_FILE
#define ROUGHNESS_FILE ""../../../../_JulioSillet/Map/Aluminium/Aluminium_roughness.png""

#define AO_FROM AO_FROM_FILE
#define AO_FILE ""../../../../_JulioSillet/Map/Aluminium/Aluminium_ambientOcclusion.png""

#define HEIGHT_FROM HEIGHT_FROM_FILE
#define HEIGHT_FILE ""../../../../_JulioSillet/Map/Aluminium/Aluminium_height.png""

#include ""../../shader/sdPBRMaterialTail.fxsub""", aluminiumMaterial);
    }

    [TestMethod]
    public void TestSelectMap()
    {
        var selector = new MapFileSelector();
        var maps = selector.SelectMapFiles(TestData.Get("Source/Aluminium"));
        
        Assert.AreEqual("Aluminium_baseColor.png", maps.BaseColor);
        Assert.IsNull(maps.SubSurface);
        Assert.AreEqual("Aluminium_normal.png", maps.Normal);
        Assert.AreEqual("Aluminium_roughness.png", maps.Roughness);
        Assert.IsNull(maps.Specular);
        Assert.IsNull(maps.Metallic);
        Assert.AreEqual("Aluminium_ambientOcclusion.png", maps.AmbientOcclusion);
        Assert.AreEqual("Aluminium_height.png", maps.Height);
    }
}