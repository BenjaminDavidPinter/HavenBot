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

	//TODO: Build this
	public async Task<ItemDetail> GetItemDetails(int itemID)
	{
	    using var client = new HttpClient();
	    var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
	    queryString.Add("private_key", (string)_config["apiKey"]);

	    var queryStringCompiled = $"{(string)_config["ItemSearch"]}/{itemID}";
	    _logger.Log(LogLevel.Information, queryStringCompiled, null);

	    var response = await client.GetAsync(queryStringCompiled);
	    var responseContent = await response.Content.ReadAsStringAsync();
	    _logger.Log(LogLevel.Information, responseContent, null);
	    var item = JsonSerializer.Deserialize<ItemDetail>(responseContent);
	
	    return item;
	}
    }
}
