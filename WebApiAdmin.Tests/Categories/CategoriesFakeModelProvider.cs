using EcommerceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAdmin.Tests.Categories
{
    static class CategoriesFakeModelProvider
    {
        public static Category GetInsertFake()
        {
            return new Category()
            {
                Id = 1,
                //Name = "To Insert",
                Color = "Color 1",
                Icon = "Icon1",
            };
        }

        public static Task<IEnumerable<Category>> CreateCategories()
        {
            var list = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cat1",
                    Color = "Color 1",
                    Icon = "Icon1",
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cat2",
                    Color = "Color 2",
                    Icon = "Icon2",
                },
                 new Category()
                {
                    Id = 3,
                    Name = "Cat3",
                    Color = "Color 3",
                    Icon = "Icon2",
                },
                  new Category()
                {
                    Id = 4,
                    Name = "Cat4",
                    Color = "Color 4",
                    Icon = "Icon2",
                }
            };

            return Task.FromResult(list.AsEnumerable());
        }
    }
}
