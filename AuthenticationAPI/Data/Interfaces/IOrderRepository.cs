using AuthenticationAPI.Data.Model;
using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Data
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

    }
}
