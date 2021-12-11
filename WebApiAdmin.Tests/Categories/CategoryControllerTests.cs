using EcommerceModels;
using System;
using System.Threading.Tasks;
using WebApiAdmin.Controllers;
using WebApiAdmin.Services;
using Xunit;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApiAdmin.Repositories.Interfaces;
using WebApiAdmin.Repositories;
using Moq;
using WebApiAdmin.Tests.Categories;
using NgStore.Framework.Logs;

namespace WebApiAdmin.Tests
{
    public class CategoryControllerTests : BaseCrudControllerTests<Category>
    {
        Mock<ICategoriesRepository> mock;       
        CategoriesController controller;
        public CategoryControllerTests(): base()
        {
           mock = new Mock<ICategoriesRepository>();
            var service = new CategoriesService(mockLog.Object, mock.Object);
            controller = new CategoriesController(service);
           
        }

        public override Task<IEnumerable<Category>> GetFakeList()
        {
            return CategoriesFakeModelProvider.CreateCategories();
        }

        public override Category GetFakeObject()
        {
            return CategoriesFakeModelProvider.GetInsertFake();
        }

       
       

    }
}
