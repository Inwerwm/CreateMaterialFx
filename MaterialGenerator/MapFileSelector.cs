namespace MaterialGenerator;
public class MapFileSelector
{
    public NamePattern NamePattern { get; }

    public MapFileSelector(NamePattern namePattern)
    {
        NamePattern = namePattern;
    }
}
