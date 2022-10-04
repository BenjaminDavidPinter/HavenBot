using XIV.Models;
using System.Text.Json;

namespace XIV.Services 
{
    public class ItemService
    {
	public readonly IConfiguration _config;
	public readonly ILogger<ItemService> _logger;

	public ItemService(IConfiguration config,
	    ILogger<ItemService> logger)
	{
	    _config = config;
	    _logger = logger;
	}

	public async Task<object> GetItemDetails(int itemID)
	{
	    using var client = new HttpClient();
	    return new Object();
	}
    }
}
