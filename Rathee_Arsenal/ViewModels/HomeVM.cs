using Rathee_Arsenal.Data.Model;
using Rathee_Arsenal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Weapon> TrendingWeapon { get; set; }
    }
}
