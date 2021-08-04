using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SteamTime.Models.ViewModels;
using SteamTime.Services;

namespace SteamTime.Controllers
{
    public class SteamGameController : Controller
    {
        private readonly SteamApiService _steamApiService;
        private readonly SteamGameService _steamGameService;
        public SteamGameController(SteamApiService steamApiService, SteamGameService steamGameService)
        {
            _steamApiService = steamApiService;
            _steamGameService = steamGameService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _steamGameService.FindAllAsync();
            var sum = _steamGameService._context.SteamGame.Sum(game => game.PlayTime);
            ViewData["TotalPlayedTime"] = sum;
            return View(list);
        }
        public async Task<IActionResult> Update()
        {
            await _steamApiService.FetchGamesAsync();
            return View();
        }
    }
}