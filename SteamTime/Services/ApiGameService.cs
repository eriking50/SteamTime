using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SteamTime.Services
{
    public class ApiGameService
    {
        private string PathToSteamAccess = @"C:\Users\User\Documents\GitHub\SteamTime\SteamTime\steamAccess.json"; 
        public string SteamId {get; set; }
        public string FetchUrl { get; set; }
        public ApiGameService()
        {
            JObject data = JObject.Parse(File.ReadAllText(PathToSteamAccess));
            SteamId = data["id"].ToString();
            FetchUrl = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={data["key"].ToString()}&steamid={data["id"].ToString()}include_played_free_games=true&include_appinfo=true&format=json";
        }
        public async Task<JToken> FetchDataAsync()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(FetchUrl);
            HttpContent content = res.Content;
            string data = await content.ReadAsStringAsync();
            if (data != null)
            {
                var dataObj = JObject.Parse(data);
                return dataObj["response"];
            }
            else
            {
                //todo colocar uma exception
                return new JObject();
            }
        }
    }
}