using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Rathee_Arsenal.Data.Model
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail> Orderdetails { get; set; }
        public Guid UserUid { get; set; }
        public User User { get; set; }

        //[Display(Name="name")]
        //[StringLength(25)]
        //[Required(ErrorMessage = "Name is a required field.")]
        //public string BuyerName { get; set; }

        //[Required(ErrorMessage = "Address is a required field.")]
        //public string Address { get; set; }

        //[EmailAddress]
        //[DataType(DataType.EmailAddress)]
        //[Required(ErrorMessage = "Email is a required field.")]
        //public string Email { get; set; }

        //public decimal OrderTotal { get; set; }
        //public DateTime OrderPlacedAt { get; set; }
        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Password is a required field.")]
        //public string Password { get; set; }
    }
}
