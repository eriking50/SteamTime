using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SteamTime.Models
{
    public class SteamGame
    {
        [Key]
        [Display(Name = "Game Id")]
        public int AppId { get; set; }
        public string SteamId { get; set; }
        [Display(Name = "Game Name")]
        public string Name { get; set; }
        [Display(Name = "Total Played Time")]
        public int PlayTime { get; set; }
        [Display(Name = "Played In Last Two Weeks?")]
        public bool PlayedInLastTwoWeeks { get; set; }
        public string HashImgLogo { get; set; }

        public SteamGame()
        {
        }
        public SteamGame(string steamId, int appId, string name, int playTime, bool playedInLastTwoWeeks, string hashImgLogo)
        {
            SteamId = steamId;
            AppId = appId;
            Name = name;
            PlayTime = playTime;
            PlayedInLastTwoWeeks = playedInLastTwoWeeks;
            HashImgLogo = hashImgLogo;
        }
    }
}
