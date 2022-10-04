using XIV.Models;
using System.Text.Json;

namespace XIV.Services {
    public class CharacterService {

        public readonly IConfiguration _config;
        public readonly ILogger<CharacterService> _logger;

        public CharacterService(IConfiguration config,
        ILogger<CharacterService> logger){
            _config = config;
            _logger = logger;
        }

        public async Task<CharacterSearchResponse> SearchByName(string characterName){
            try{
                using var client = new HttpClient();
                
                var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("name", characterName);
                queryString.Add("private_key", (string)_config["apiKey"]);

                var queryStringCompiled = $"{(string)_config["CharacterSearch"]}?{queryString.ToString()}";
                _logger.Log(LogLevel.Debug, $"Running: {queryStringCompiled}", queryStringCompiled);

                var response = await client.GetAsync(queryStringCompiled);
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CharacterSearchResponse>(responseContent);
            }
            catch(Exception ex){
                _logger.Log(LogLevel.Error,ex.Message, ex);
		throw;
            }
        }
    }
}
