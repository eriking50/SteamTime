using System.Linq;
using SteamTime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SteamTime.Services
{
    public class SteamGameService
    {
        public SteamTimeContext _context {get; private set;}
        
        public SteamGameService(SteamTimeContext context)
        {
            _context = context;
        }

        public async Task<List<SteamGame>> FindAllAsync()
        {
            return await _context.SteamGame.ToListAsync();
        }
    }
}