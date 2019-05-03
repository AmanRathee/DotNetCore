using AuthenticationAPI.Data.Model;
using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Weapon> TrendingWeapon { get; set; }
    }
}
