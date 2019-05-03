using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthenticationAPI.Model;

namespace AuthenticationAPI.Data.Repository
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly AppDbContext _appDbContext;
        public WeaponRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Weapon> GetAllWeapons => _appDbContext.Weapons.Include(c => c.Category);
        public IEnumerable<Weapon> GetAllTrendingWeapons => _appDbContext.Weapons.Where(x=>x.IsTrending).Include(c => c.Category);

        public Weapon GetWeaponById(int weaponId)
        {
            return _appDbContext.Weapons.FirstOrDefault(x=>x.WeaponId==weaponId);
        }
    }
}
