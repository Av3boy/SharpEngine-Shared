using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

/// <summary>
///     Used to convert strongly typed IDs to their underlying value type and vice versa when storing them in a database using Entity Framework Core, allowing for seamless integration of strongly typed IDs with EF Core's data access capabilities.
/// </summary>
/// <typeparam name="TStrong">The strongly typed ID type.</typeparam>
/// <typeparam name="TValue">The underlying value type.</typeparam>
public class StronglyTypedIdConverter<TStrong, TValue> : ValueConverter<TStrong, TValue>
    where TStrong : struct
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="StronglyTypedIdConverter{TStrong, TValue}"/> class with the specified conversion expressions for converting to and from the provider type,
    ///     enabling Entity Framework Core to correctly handle strongly typed IDs when persisting them to the database and retrieving them back into their strongly typed form.
    /// </summary>
    /// <param name="toProvider">The expression for converting the strongly typed ID to the provider type.</param>
    /// <param name="fromProvider">The expression for converting the provider type to the strongly typed ID.</param>
    public StronglyTypedIdConverter(Expression<Func<TStrong, TValue>> toProvider, Expression<Func<TValue, TStrong>> fromProvider)
        : base(toProvider, fromProvider) { }
}