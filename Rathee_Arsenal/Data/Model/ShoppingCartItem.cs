using Rathee_Arsenal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.Data.Model
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Weapon Weapon { get; set; }
        public int Number { get; set; }
        public Guid ShoppingCartId { get; set; }
    }
}
