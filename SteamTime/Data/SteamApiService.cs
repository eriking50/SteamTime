using System.Linq;
using Newtonsoft.Json.Linq;
using SteamTime.Models;
using System.Threading.Tasks;

namespace SteamTime.Data
{
    public class SteamApiService
    {
        private SteamTimeContext _context;
        private ApiGameService apiGameService;
        public SteamApiService(SteamTimeContext context)
        {
            _context = context;
        }
        public async Task FetchGamesAsync()
        {
            if (_context.SteamGame.Any(steamGame => steamGame.SteamId == apiGameService.SteamId))
            {
                return;
            }
            apiGameService = new ApiGameService();
            JObject data = await apiGameService.FetchDataAsync();
            SteamGame user = new SteamGame(apiGameService.SteamId,
                                (int)data["appid"], 
                                (string)data["name"],
                                (int)data["playtime_forever"], 
                                (int)data["playtime_2weeks"], 
                                (string)data["img_logo_url"]);
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}