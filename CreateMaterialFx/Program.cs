using MaterialGenerator.Material;

if (args.Length < 2)
{
    Console.WriteLine("引数1: マップ画像フォルダのあるディレクトリのパス");
    Console.WriteLine("引数2: 書込み先ディレクトリのパス");
    return;
}

var mapFolderPaths = Directory.EnumerateDirectories(args[0]);
var fxes = mapFolderPaths.Select(fp => (Material: new SdPbrMaterial(fp, "../../../../_JulioSillet/Map", new()), Name: Path.GetFileName(fp)));
foreach (var fx in fxes)
{
    fx.Material.Write(Path.Join(args[1], $"{fx.Name}.fx"));
}