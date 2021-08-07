using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using SteamTime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            bool playtime_2weeks;
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
                        playtime_2weeks = false;
                    }
                    else
                    {
                        playtime_2weeks = true;
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
        public async Task UpdateGamesAsync()
        {
            bool playtime_2weeks;
            string img_logo_url;
            JToken data = await apiGameService.FetchDataAsync();
            foreach (var game in data["games"])
            {
                if (game["playtime_2weeks"] == null)
                        {
                            playtime_2weeks = false;
                        }
                        else
                        {
                            playtime_2weeks = true;
                        }
                        if (game["img_logo_url"].ToString() == "")
                        {
                            img_logo_url = "NotFound";
                        }
                        else
                        {
                            img_logo_url = (string)game["img_logo_url"];
                        }
                SteamGame gameObj = new SteamGame(apiGameService.SteamId, (int)game["appid"], game["name"].ToString(), (int)game["playtime_forever"], playtime_2weeks, img_logo_url);
                System.Console.WriteLine(gameObj);
                _context.Update(gameObj);
            }
            await _context.SaveChangesAsync();
        }
    }
}