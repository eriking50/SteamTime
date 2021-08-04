using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SteamTime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SteamTime.Services
{
    public class SteamApiService
    {
        private SteamTimeContext _context;
        private ApiGameService apiGameService;
        public SteamApiService(SteamTimeContext context)
        {
            _context = context;
            apiGameService = new ApiGameService();
        }
        public async Task<bool> FetchGamesAsync()
        {
            int appId;
            string name;
            int playtime_forever;
            int playtime_2weeks;
            string img_logo_url;
            if (_context.SteamGame.Any())
            {
                if (_context.SteamGame.Any(steamGame => steamGame.SteamId == apiGameService.SteamId))
                {
                    return false;
                }
            }
            JToken data = await apiGameService.FetchDataAsync();
            if (data.Any())
            {
                
                foreach (var g in data["games"])
                {
                    appId = (int)g["appid"];
                    name = (string)g["name"];
                    playtime_forever = (int)g["playtime_forever"];
                    if (g["playtime_2weeks"] == null)
                    {
                        playtime_2weeks = 0;
                    }
                    else
                    {
                        playtime_2weeks = (int)g["playtime_2weeks"];
                    }
                    if (g["img_logo_url"].ToString() == "")
                    {
                        img_logo_url = "NotFound";
                    }
                    else
                    {
                        img_logo_url = (string)g["img_logo_url"];
                    }
                    SteamGame game = new SteamGame(apiGameService.SteamId, appId, name, playtime_forever, playtime_2weeks, img_logo_url);
                    _context.Add(game);
                }
            await _context.SaveChangesAsync();

            return true;
            }
        return false;
        }
    }
}