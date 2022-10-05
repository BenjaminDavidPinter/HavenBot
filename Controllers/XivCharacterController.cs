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
    private readonly ItemService _itemServ;

    public XivCharacterController(ILogger<XivCharacterController> logger,
        IConfiguration config,
        CharacterService charServ,
	ItemService itemServ)
    {
        _logger = logger;
        _config = config;
        _charServ = charServ;
	_itemServ = itemServ;
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
	    
	    var headDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Head.ID.Value);
	    var bodyDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Body.ID.Value);
	    var braceletDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Bracelets.ID.Value);
	    var earringsDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Earrings.ID.Value);
	    var feetDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Feet.ID.Value);
	    var handsDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Hands.ID.Value);
	    var legsDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Legs.ID.Value);
	    var mainHandDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.MainHand.ID.Value);
	    var necklaceDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Necklace.ID.Value);
	    var ring1Details = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Ring1.ID.Value);
	    var ring2Details = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Ring2.ID.Value);
	    var soulCrystalDetails = await _itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.SoulCrystal.ID.Value);

	    return $"{cxtrDetails.Character.Name} the {cxtrDetails.Character.ActiveClassJob.Name}\n" + 
                    $"\t Head: {headDetails.Name}\n" +  
                    $"\t Body: {bodyDetails.Name}\n" +  
                    $"\t Bracelets: {braceletDetails.Name}\n" +  
                    $"\t Earrings: {earringsDetails.Name}\n" + 
                    $"\t Feet: {feetDetails.Name}\n" + 
                    $"\t Hands: {handsDetails.Name}\n" + 
                    $"\t Legs: {legsDetails.Name}\n" + 
                    $"\t Main Hand: {mainHandDetails.Name}\n" +  
                    $"\t Necklace: {necklaceDetails.Name}\n" + 
                    $"\t Ring: {ring1Details.Name}\n" +  
                    $"\t Ring: {ring2Details.Name}\n" +  
                    $"\t Crystal: {soulCrystalDetails.Name}"; 
        }
    }
}
