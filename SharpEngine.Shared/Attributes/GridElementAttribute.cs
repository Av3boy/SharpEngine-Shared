using Launcher.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Shared.Attributes;

public class GridElementAttribute : Attribute
{
    /// <summary>Gets or sets whether the column allows filtering.</summary>
    public bool IsFilterable { get; set; }

    /// <summary>Gets or sets the title of the column.</summary>
    public string Title { get; set; }

    public int Order { get; set; }

    public SvgIcon Icon { get; set; }

    /// <summary>
    ///     Initializes a new instance of <see cref="FilterAttribute"/>.
    /// </summary>
    /// <param name="isFilterable">Determines whether the target property is filterable.</param>
    public GridElementAttribute(string title, bool isFilterable = true, int order = 0, SvgIcon icon = SvgIcon.None)
    {
        Title = title;
        IsFilterable = isFilterable;
        Order = order;
        Icon = icon;
    }

    /// <summary>
    ///     Initializes a new instance of <see cref="FilterAttribute"/>.
    /// </summary>
    public GridElementAttribute() { }
}
