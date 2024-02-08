using System.Text;
using System.Text.Json;
using Platformservice.Dtos;

namespace Platformservice.SyncDataServices.Http;
public class HttpCommandDataClient : ICommandDataClient
{
    private readonly HttpClient _http;
    private readonly IConfiguration _configuration;

    public HttpCommandDataClient(HttpClient http, IConfiguration configuration)
    {
        _http = http;
        _configuration = configuration;
    }
    public async Task SendPlatformToCommand(PlatformReadDto plat)
    {
        var httpContent = new StringContent(
            JsonSerializer.Serialize(plat),
            Encoding.UTF8,
            "application/json"
        );
        var response = await _http.PostAsync($"{_configuration["CommandService"]}", httpContent);
        if(response.IsSuccessStatusCode)
        {
            Console.WriteLine("-->Sync Post to command service was OK");
        }
        else{
            Console.WriteLine("-->Sync Post to command service was fail");
        }
    }
}