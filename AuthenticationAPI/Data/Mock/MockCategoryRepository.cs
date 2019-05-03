using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationAPI.Model;

namespace AuthenticationAPI.Data.Mock
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories =>
            new List<Category>()
            {
                new Category(){ CategoryId=1,CategoryName="Pistol",Description="A pistol is a type of handgun. The pistol originates in the 16th century, when early handguns were produced in Europe."},
                new Category(){ CategoryId=2,CategoryName="ShotGun",Description="A shotgun is a firearm that is usually designed to be fired from the shoulder, which uses the energy of a fixed shell to fire a number of small spherical pellets."},
            //    new Category(){ CategoryId=3,CategoryName="Bullets",Description="A bullet is a kinetic projectile and the component of firearm ammunition that is expelled from the gun barrel during shooting."},
            //    new Category(){ CategoryId=4,CategoryName="Bombs",Description="A bomb is an explosive weapon that uses the exothermic reaction of an explosive material to provide an extremely sudden and violent release of energy."}
            };

    }
}
