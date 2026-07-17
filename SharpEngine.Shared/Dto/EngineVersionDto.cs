namespace SharpEngine.Shared.Dto;

public class EngineVersionDto
{
    public Version Version { get; set; } = new Version(1, 0, 0);
    public bool IsOutDated { get; set; }
}