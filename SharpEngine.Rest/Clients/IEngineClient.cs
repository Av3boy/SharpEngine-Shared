using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SharpEngine.Shared.Dto;

namespace SharpEngine.Rest.Clients;

public interface IEngineClient
{
    Task<EngineVersionDto> GetLatestVersion();
}

public class EngineClient : RestClient, IEngineClient
{
    /// <summary>
    ///     Initializes a new instance of <see cref="EngineClient" />.
    /// </summary>
    /// <param name="httpClient">The HTTP client used to make requests.</param>
    /// <param name="logger">The logger used to log information.</param>
    public EngineClient(HttpClient httpClient, ILogger<RestClient> logger)
        : base(httpClient, logger) { }

    /// <inheritdoc />
    public async Task<EngineVersionDto> GetLatestVersion()
        => await GetAsync<EngineVersionDto>(Urls.Portal.EngineVersion);
}