using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using XIV.Models;
using XIV.Services;

namespace HavenBot.Controllers;

[ApiController]
[Route("Character")]
public class XivCharacterController : ControllerBase
{
    private readonly ILogger<XivCharacterController> _logger;
    private readonly IConfiguration _config;
    private readonly CharacterService _charServ;

    public XivCharacterController(ILogger<XivCharacterController> logger,
    IConfiguration config,
    CharacterService charServ)
    {
        _logger = logger;
        _config = config;
	_charServ = charServ;
    }

    [HttpGet]
    public async Task<string> Get(string CharacterName)
    {
        var cxtr = _charServ.SearchByName(CharacterName);
        
        
        
/*
        var profileSearchString = System.Web.HttpUtility.ParseQueryString(string.Empty);
        profileSearchString.Add("private_key", (string)_config["apiKey"]);
        var profileSearchStringCompiled = $"{profileUrl}{characterResult.Results.First(x => x.Server == "Malboro").ID}?{profileSearchString.ToString()}";
        Console.WriteLine(profileSearchStringCompiled);
*/
        //return await (await client.GetAsync(profileSearchStringCompiled)).Content.ReadAsStringAsync();
	return JsonSerializer.Serialize(cxtr);
    }
}
