using AuthenticationAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationAPI.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
