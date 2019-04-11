using Rathee_Arsenal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.Data
{
    public interface IWeaponRepository
    {
        IEnumerable<Weapon> GetAllWeapons { get; set; }
        IEnumerable<Weapon> GetAllTrendingWeapons { get; set; }
        Weapon GetWeaponById(int weaponId);

    }
}
