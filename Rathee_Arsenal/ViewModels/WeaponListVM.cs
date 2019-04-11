using Rathee_Arsenal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.ViewModels
{
    public class WeaponListVM
    {
        public IEnumerable<Weapon> Weapons { get; set; }
        public string CurrentCategory { get; set; }
    }
}
