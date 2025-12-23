namespace SharpEngine.Shared.Dto.Primitives;

/// <summary>
///     Represents a primitive wrapper for Auth0 Ids.
/// </summary>
/// <remarks>
///     The Id is in the format 'auth0|12345'.
/// </remarks>
/// <param name="value">The string value of the Id.</param>
internal struct Auth0Sub(string value)
{
    public string Value = value;

    public static implicit operator string(Auth0Sub id) => id.Value;
    public static implicit operator Auth0Sub(string value) => new(value);

    public string Provider => Value.Split('|')[0];
    public string ProviderId => Value.Split('|')[1];
}
