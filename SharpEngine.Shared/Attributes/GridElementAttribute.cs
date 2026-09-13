using Launcher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Shared.Attributes;

/// <summary>
///     Represents an attribute that can be applied to properties to define their behavior in a grid layout.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class GridElementAttribute : Attribute
{
    /// <summary>Gets or sets whether the column allows filtering.</summary>
    public bool IsFilterable { get; set; }

    /// <summary>Gets or sets the title of the column.</summary>
    public string Title { get; set; } = null!;

    /// <summary>Gets or sets the order of the column in the grid.</summary>
    public int Order { get; set; }

    /// <summary>Gets or sets the icon associated with the column.</summary>
    public SvgIcon Icon { get; set; }

    /// <summary>
    ///     Initializes a new instance of <see cref="GridElementAttribute"/>.
    /// </summary>
    /// <param name="title">The title of the column.</param>
    /// <param name="isFilterable">Determines whether the target property is filterable.</param>
    /// <param name="order">The order of the column in the grid.</param>
    /// <param name="icon">The icon associated with the column.</param>
    public GridElementAttribute(string title, bool isFilterable = true, int order = 0, SvgIcon icon = SvgIcon.None)
    {
        Title = title;
        IsFilterable = isFilterable;
        Order = order;
        Icon = icon;
    }
}
