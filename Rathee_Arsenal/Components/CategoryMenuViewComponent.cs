using Microsoft.AspNetCore.Mvc;
using Rathee_Arsenal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.Components
{
    public class CategoryMenu:ViewComponent
    {
        private ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.Categories);
        }
    }
}
