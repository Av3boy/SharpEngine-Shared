using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

public class StronglyTypedIdConverter<TStrong, TValue> : ValueConverter<TStrong, TValue>
    where TStrong : struct
{
    public StronglyTypedIdConverter(Expression<Func<TStrong, TValue>> toProvider, Expression<Func<TValue, TStrong>> fromProvider)
        : base(toProvider, fromProvider) { }
}