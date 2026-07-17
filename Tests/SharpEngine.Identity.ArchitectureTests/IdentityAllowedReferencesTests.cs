using SharpEngine.Shared.Dto.AssetStore;
using Xunit;

namespace SharpEngine.Identity.ArchitectureTests;

public class IdentityAllowedReferencesTests
{
    // Only Telemetry can be referenced, other projects will cause a fail

    [Fact]
    public void OnlyAllowedAssembliesArePresent()
    {
        string[] allowedReferenceAssemblies = 
        [
            "Microsoft.Extensions.Logging.Abstractions",
            "SharpEngine.Shared.Telemetry",
            "SharpEngine.Rest",
            this.GetType().Assembly.FullName!
        ];

        var assembly = typeof(SharpEngine.Identity.Auth0Client).Assembly;
        var referencedAssemblies = assembly.GetReferencedAssemblies()
            .Where(a => !a.FullName.StartsWith("System"))
            .Where(a => !allowedReferenceAssemblies.Contains(a.Name));

        foreach (var referencedAssembly in referencedAssemblies)
            Assert.Fail($"Invalid reference to assembly: {referencedAssembly.FullName}");
    }
}
