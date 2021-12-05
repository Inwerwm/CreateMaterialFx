namespace MaterialGenerator;

public record MapFiles
{
    public string? BaseColor { get; init; }
    public string? SubSurface { get; init; }
    public string? Normal { get; init; }
    public string? Roughness { get; init; }
    public string? Specular { get; init; }
    public string? Metallic { get; init; }
    public string? AmbientOcclusion { get; init; }
    public string? Height { get; init; }
}