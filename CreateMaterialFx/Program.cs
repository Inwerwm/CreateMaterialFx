using MaterialGenerator.Material;

if (args.Length < 2)
{
    Console.WriteLine("引数1: マップ画像フォルダのあるディレクトリのパス");
    Console.WriteLine("引数2: 書込み先ディレクトリのパス");
    Console.WriteLine("引数3: 上書きするかの真理値 設定なしなら false");
    return;
}

var mapFolderPaths = Directory.EnumerateDirectories(args[0]);
var fxes = mapFolderPaths.Select(fp => (Material: new SdPbrMaterial(fp, Path.GetRelativePath(args[1], fp), new()), Name: Path.GetFileName(fp)));
bool.TryParse(args[2], out bool enableOverWrite);

foreach (var fx in fxes)
{
    fx.Material.Write(Path.Join(args[1], $"{fx.Name}.fx"), enableOverWrite);
}