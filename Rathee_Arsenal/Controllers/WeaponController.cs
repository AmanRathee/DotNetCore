using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rathee_Arsenal.Data;
using Rathee_Arsenal.Model;
using Rathee_Arsenal.ViewModels;

namespace Rathee_Arsenal.Controllers
{
    public class WeaponController : Controller
    {
        private ICategoryRepository _categoryRepo;
        private IWeaponRepository _weaponRepo;

        public WeaponController(ICategoryRepository categoryRepo,IWeaponRepository weaponRepo)
        {
            ViewBag.Heading = "Big Boy Toys!!!";

            _categoryRepo = categoryRepo;
            _weaponRepo = weaponRepo;
        }

        public ViewResult WeaponList(string category)
        {
            IEnumerable<Weapon> weapons;
            string currentCategory;
            if (string.IsNullOrEmpty(category))
            {
                weapons = _weaponRepo.GetAllWeapons.OrderBy(p => p.WeaponId);
                currentCategory = "ALL";
            }
            else
            {
                var matchingCategoryWeapons = _categoryRepo.Categories.FirstOrDefault(x => x.CategoryName.Equals(category, StringComparison.OrdinalIgnoreCase));
                if (matchingCategoryWeapons!=null)
                {
                    weapons = _weaponRepo.GetAllWeapons.Where(x=>x.Category.CategoryId== matchingCategoryWeapons.CategoryId);
                    currentCategory = category;
                }
                else
                {
                    weapons = _weaponRepo.GetAllWeapons.OrderBy(p => p.WeaponId);
                    currentCategory = "ALL";
                }
            }

            WeaponListVM weaponListVm = new WeaponListVM() { Weapons=weapons,CurrentCategory= currentCategory };
            return View(weaponListVm);
        }
    }
}