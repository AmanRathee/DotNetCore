using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rathee_Arsenal.Data;
using Rathee_Arsenal.ViewModels;

namespace Rathee_Arsenal.Controllers
{
    public class HomeController : Controller
    {
        private IWeaponRepository _weaponRepository;
        public HomeController(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }
        public ViewResult Index()
        {
            var homeVM = new HomeVM() { TrendingWeapon = _weaponRepository.GetAllTrendingWeapons };
            return View(homeVM);
        } 
    }
}