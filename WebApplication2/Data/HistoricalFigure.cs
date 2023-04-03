namespace WebApplication2.Data;

public class HistoricalFigure
{
    public required Guid Id { get; init; }

    public required string Name { get; init; }

    public required string Surname { get; init; }

    public required string Occupation { get; init; }

    public required string ShortDescription { get; init; }
    
    public required string FullDescription { get; init; }

    public required string ShortImageUrl { get; init; }
    
    public required string FullImageUrl { get; init; }
    
    public required DateOnly DateOfBirth { get; init; }

    public required DateOnly DateOfDeath { get; init; }
}