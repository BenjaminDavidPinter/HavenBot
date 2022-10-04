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
    [Route("Get")]
    public async Task<string> Get(string CharacterName)
    {
        var cxtr = await _charServ.SearchByName(CharacterName);

        if (cxtr == null) return "No character found!";
        if (cxtr.Results == null) return "No character found!";

        var relevantChar = cxtr.Results.First(x => x.Server == "Malboro");
        if (relevantChar == null || !relevantChar.ID.HasValue)
        {
            return "No character found!";
        }
        else
        {
            var cxtrDetails = await _charServ.GetCharacterDetails(relevantChar.ID.Value);
            return JsonSerializer.Serialize(cxtrDetails);
        }
    }
}
