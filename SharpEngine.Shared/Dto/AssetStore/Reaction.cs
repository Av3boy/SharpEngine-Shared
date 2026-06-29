namespace SharpEngine.Shared.Dto.AssetStore;

/// <summary>
///     Represents a reaction to a SharpEngine entity, including the type of reaction and the count of how many times that reaction has been given.
/// </summary>
/// <param name="ReactionType">The type of the reaction.</param>
/// <param name="Count">The count of how many times the reaction has been given.</param>
public readonly record struct Reaction(string ReactionType, int Count);