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
            ViewBag.Db = true;
            bool dbData = await _steamGameService.AnyDataAsync();
            if (!dbData)
            {
                ViewBag.Db = false;
                return View();
            }
            var list = await _steamGameService.FindAllAsync();
            var sum = TimeSpan.FromMinutes(_steamGameService._context.SteamGame.Sum(game => game.PlayTime));
            ViewData["TotalPlayedTime"] = Math.Ceiling(sum.TotalHours);
            return View(list.OrderBy(game => game.Name).OrderByDescending(game => game.PlayedInLastTwoWeeks));
        }
        public async Task<IActionResult> Update()
        {
            ViewBag.Db = true;
            await _steamApiService.UpdateGamesAsync();
            return View();
        }
        public async Task<IActionResult> Create()
        {
            await _steamApiService.FetchGamesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}