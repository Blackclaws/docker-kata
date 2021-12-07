using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.AspNetCore.CookiePolicy;

namespace aspnetcore.Controllers;

[ApiController]
[Route("[controller]")]
public class SecretController : ControllerBase
{


    private readonly ILogger<SecretController> _logger;
    private SecretsOptions Options { get; set; }

    public SecretController(ILogger<SecretController> logger, IOptions<SecretsOptions> options)
    {
        _logger = logger;
        Options = options.Value;
    }

    private const string SecretFileName = "Secret.dat";

    private Guid CreateSecret(string path)
    {
        if (Directory.Exists(path))
        {
            var secretPath = Path.Combine(path, SecretFileName);
            var secretFileInfo = new FileInfo(secretPath);
            if (secretFileInfo.Exists)
            {
                var file = secretFileInfo.OpenText();
                    var content = file.ReadToEnd();
                    file.Close();
                return Guid.Parse(content);
            }
            else
            {
                var secret = Guid.NewGuid();
                using StreamWriter file = new(secretPath);
                    file.WriteLineAsync(secret.ToString());
                    file.Close();
                return secret;
            }
        }

        throw new Exception("Secret dir not found");
    }

    [HttpGet("/builtin", Name = "GetBuiltinSecret")]
    public Guid GetBuiltIn()
    {
        return Options.Secret;
    }

    [HttpGet("/persistent", Name = "GetPersistentSecret")]
    public Guid GetPersistent()
    {
        return CreateSecret(Options.SecretPath);
    }
}
