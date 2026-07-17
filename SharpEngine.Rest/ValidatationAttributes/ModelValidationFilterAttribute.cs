using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace SharpEngine.Rest.ValidationAttributes;

/// <summary>
///     Represents an action filter on API calls that checks, whether the API parameters are valid.
/// </summary>
public class ModelValidationFilterAttribute : ActionFilterAttribute
{
    private readonly ILogger<ModelValidationFilterAttribute> _logger;

    /// <summary>
    ///     Initializes a new instance of <see cref="ModelValidationFilterAttribute"/>.
    /// </summary>
    /// <param name="logger">A logger instance used to log executed actions.</param>
    public ModelValidationFilterAttribute(ILogger<ModelValidationFilterAttribute> logger)
    {
        _logger = logger;
    }

    /// <inheritdoc />
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            _logger.LogWarning("Model validation failed for the request: {request}", context.HttpContext.Request.Path);
            context.Result = FilterAttributeUtils.CreateResult(Status400BadRequest, context.ModelState);
        }

        _logger.LogDebug("Model validation passed for the request: {request}", context.HttpContext.Request.Path);
        base.OnActionExecuting(context);
    }
}