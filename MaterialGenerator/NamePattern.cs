using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialGenerator;

public record NamePattern
{
    public IEnumerable<string> BaseColor { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> SubSurface { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> Normal { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> Roughness { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> Specular { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> Metallic { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> AmbientOcclusion { get; init; } = Enumerable.Empty<string>();
    public IEnumerable<string> Height { get; init; } = Enumerable.Empty<string>();
}
