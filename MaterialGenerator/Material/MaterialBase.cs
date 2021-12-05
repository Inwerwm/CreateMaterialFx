﻿namespace MaterialGenerator.Material;

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

        BaseColor = MakePath(filenames.BaseColor);
        Normal = MakePath(filenames.Normal);
        Roughness = MakePath(filenames.Roughness);
        Specular = MakePath(filenames.Specular);
        Metallic = MakePath(filenames.Metallic);
        Height = MakePath(filenames.Height);
        AmbientOcclusion = MakePath(filenames.AmbientOcclusion);

        string? MakePath(string? filename) => filename is null ? null : dir + filename;
    }

    public abstract void Write(string path);
}