using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rathee_Arsenal.Data;
using Rathee_Arsenal.ViewModels;

namespace Rathee_Arsenal.Controllers
{
    public class WeaponController : Controller
    {
        private ICategoryRepository _categoryRepo;
        private IWeaponRepository _weaponRepo;

        public WeaponController(ICategoryRepository categoryRepo,IWeaponRepository weaponRepo)
        {
            _categoryRepo = categoryRepo;
            _weaponRepo = weaponRepo;
        }

        public ViewResult WeaponList()
        {
            ViewBag.Heading = "Big Boy Toys!!!";
            var weapons = _weaponRepo.GetAllWeapons;
            WeaponListVM weaponListVm = new WeaponListVM();
            weaponListVm.Weapons= _weaponRepo.GetAllWeapons; ;
            weaponListVm.CurrentCategory = _categoryRepo.Categories.First().CategoryName;
            return View(weaponListVm);
        }
    }
}