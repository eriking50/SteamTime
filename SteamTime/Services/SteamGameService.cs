using System.Linq;
using SteamTime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SteamTime.Services
{
    public class SteamGameService
    {
        private SteamTimeContext _context;
        
        public SteamGameService(SteamTimeContext context)
        {
            _context = context;
        }

        public async Task<List<SteamGame>> FindAllAsync()
        {
            return await _context.SteamGame.ToListAsync();
        }
        // var seller = await _context.Seller.FindAsync(id);
        //         _context.Seller.Remove(seller);
        //         await _context.SaveChangesAsync();
    }
}