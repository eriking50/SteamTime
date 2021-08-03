using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SteamTime.Models
{
    public class SteamTimeContext : DbContext
    {
        public SteamTimeContext(DbContextOptions<SteamTimeContext> options) : base(options)
        {
        }
        public DbSet<SteamGame> SteamGame { get; set; }
    }
}