using Rathee_Arsenal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
