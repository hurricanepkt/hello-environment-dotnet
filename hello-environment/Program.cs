using hello_environment;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context, IConfiguration config) =>
{
    var envVariables = Environment.GetEnvironmentVariables();
    var envDict = new SortedDictionary<string, string>();

    foreach (System.Collections.DictionaryEntry entry in envVariables)
    {
        envDict.Add($"{entry.Key ?? Guid.NewGuid()}", $"{entry.Value}");
    }

    var configDict = new SortedDictionary<string, string>();

    foreach (var kvp in config.AsEnumerable())
    {
        configDict.Add(kvp.Key, $"{kvp.Value}");
    }


    var headersDict = new SortedDictionary<string, string>();

    foreach (var header in context.Request.Headers)
    {
        headersDict.Add(header.Key, $"{header.Value}");
    }

    var combinedDict = new Dictionary<string, SortedDictionary<string, string>>
 {
 { "EnvironmentVariables", envDict },
 { "ConfigurationVariables", configDict },
 { "RequestHeaders", headersDict }

 };

    return combinedDict;
});

app.Run();
