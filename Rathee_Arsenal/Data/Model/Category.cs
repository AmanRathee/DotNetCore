using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public List<Weapon> Weapons { get; set; }
    }
}
