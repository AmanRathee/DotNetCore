using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Data.Model
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int WeaponId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual Order Order { get; set; }
    }
}
