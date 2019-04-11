using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rathee_Arsenal.Model;

namespace Rathee_Arsenal.Data.Mock
{
    public class MockWeaponRepository : IWeaponRepository
    {
        private readonly ICategoryRepository _categoryRepo=new MockCategoryRepository();
        public IEnumerable<Weapon> GetAllWeapons
        {
            get => new List<Weapon>()
                    {
                        new Weapon(){
                                        WeaponId =1,Description="Smith & Wesson 686 Stainless 6 357MAG Revolvr NEW",ImageUrl="~/wwwroot/Images/1_Cat1.jpg",Price=100000M,
                                        InStock=5,IsTrending=true,Name="Smith & Wesson 686 Stainless 6 357MAG Revolvr NEW",Category=_categoryRepo.Categories.First()
                                    },
                        new Weapon(){
                                       WeaponId =2,Description="TAURUS MODEL 94 .22LR",ImageUrl="~/wwwroot/Images/2_Cat1.jpg",Price=100660M,
                                        InStock=10,IsTrending=false,Name="TAURUS MODEL 94 .22LR",Category=_categoryRepo.Categories.First()
                                    },
                        new Weapon(){
                                       WeaponId =3,Description="COLT 38 DS II - NO CC FEES!",ImageUrl="~/wwwroot/Images/3_Cat1.jpg",Price=90000M,
                                        InStock=2,IsTrending=false,Name="COLT 38 DS II - NO CC FEES!",Category=_categoryRepo.Categories.First()

                                    },
                        new Weapon(){
                                        WeaponId =4,Description="Ruger Bearcat .22 LR 1971",ImageUrl="~/wwwroot/Images/4_Cat1.jpg",Price=350000M,
                                        InStock=10,IsTrending=true,Name="Ruger Bearcat .22 LR 1971",Category=_categoryRepo.Categories.First()

                                    },
                        new Weapon(){
                                        WeaponId =5,Description="Pointer Phenoma PPHCW2028GRY 20/28 3 Walther 5CT",ImageUrl="~/wwwroot/Images/1_Cat2.jpg",Price=600000M,
                                        InStock=50,IsTrending=true,Name="Pointer Phenoma PPHCW2028GRY 20/28 3 Walther 5CT",Category=_categoryRepo.Categories.Last()

                                    },
                        new Weapon(){
                                       WeaponId =6,Description="Remington TAC-14 12GA Wood Remington TAC14 81231",ImageUrl="~/wwwroot/Images/2_Cat2.jpg",Price=956320M,
                                        InStock=10,IsTrending=true,Name="Remington TAC-14 12GA Wood Remington TAC14 81231",Category=_categoryRepo.Categories.Last()

                                    }
                    };
            set => throw new NotImplementedException();
        }
        public IEnumerable<Weapon> GetAllTrendingWeapons
        {
            get => GetAllWeapons.Where(x => x.IsTrending);
            set => throw new NotImplementedException();
        }

        public Weapon GetWeaponById(int weaponId)
        {
            return GetAllWeapons.FirstOrDefault(x=>x.WeaponId==weaponId);
        }
    }
}
