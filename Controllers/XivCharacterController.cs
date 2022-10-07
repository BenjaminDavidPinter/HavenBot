using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
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
	    List<Task<ItemDetail>> itemTasks = new List<Task<ItemDetail>>();

	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Head.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Body.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Bracelets.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Earrings.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Feet.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Hands.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Legs.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.MainHand.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Necklace.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Ring1.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.Ring2.ID.Value));
	    itemTasks.Add(_itemServ.GetItemDetails(cxtrDetails.Character.GearSet.Gear.SoulCrystal.ID.Value));

	    Task.WaitAll(itemTasks.ToArray());

	    StringBuilder sb = new StringBuilder();
	    sb.Append($"{cxtrDetails.Character.Name} the {cxtrDetails.Character.ActiveClassJob.Name}\n");  
	    foreach(var t in itemTasks)
	    {
	    	sb.Append($"-{t.Result.Name}\n");	
	    }

	    return sb.ToString(); 
        }
    }
}
