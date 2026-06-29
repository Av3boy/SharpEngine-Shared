using System.Globalization;

namespace SharpEngine.Shared.Extensions;

/// <summary>
///     Provides extension methods for string manipulation.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    ///     Parses a string representation of a floating-point number using the invariant culture format.
    /// </summary>
    /// <param name="floatString">The string representation of the floating-point number.</param>
    /// <returns>The parsed floating-point number.</returns>
    public static float ParseInvariantFloat(this string floatString) 
        => float.Parse(floatString, CultureInfo.InvariantCulture.NumberFormat);

    /// <summary>
    ///     Parses a string representation of an integer using the invariant culture format.
    /// </summary>
    /// <param name="intString">The string representation of the integer.</param>
    /// <returns>The parsed integer.</returns>
    public static int ParseInvariantInt(this string intString) 
        => int.Parse(intString, CultureInfo.InvariantCulture.NumberFormat);

    /// <summary>
    ///     Checks if the string is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="str">The first string to compare.</param>
    /// <param name="s">The second string to compare.</param>
    /// <returns>true if the strings are equal, ignoring case; otherwise, false.</returns>
    public static bool EqualsOrdinalIgnoreCase(this string str, string s) 
        => str.Equals(s, StringComparison.OrdinalIgnoreCase);

}