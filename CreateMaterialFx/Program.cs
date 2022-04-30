using MaterialGenerator.Material;

if (args.Length < 2)
{
    Console.WriteLine("引数1: マップ画像フォルダのあるディレクトリのパス");
    Console.WriteLine("引数2: 書込み先ディレクトリのパス");
    Console.WriteLine("引数3: 上書きするかの真理値 設定なしなら false");
    return;
}

var mapFolderPaths = Directory.EnumerateDirectories(args[0]);
var fxes = mapFolderPaths.Select(fp => (Material: new SdPbrMaterial(fp, Path.GetRelativePath(args[1], args[0]), new()), Name: Path.GetFileName(fp)));
bool enableOverWrite = bool.TryParse(args[2], out var parsed) ? parsed : false;

foreach (var (material, name) in fxes)
{
    material.Write(Path.Join(args[1], $"{name}.fx"), enableOverWrite);
}