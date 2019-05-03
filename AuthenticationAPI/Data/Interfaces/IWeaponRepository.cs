using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Data
{
    public interface IWeaponRepository
    {
        IEnumerable<Weapon> GetAllWeapons { get;  }
        IEnumerable<Weapon> GetAllTrendingWeapons { get;  }
        Weapon GetWeaponById(int weaponId);

    }
}
