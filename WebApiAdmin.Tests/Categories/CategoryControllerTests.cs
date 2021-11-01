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
        Mock<ILoggerService> mockLog;
        CategoriesController controller;
        public CategoryControllerTests()
        {
           mock = new Mock<ICategoriesRepository>();

            var service = new CategoriesService(mockLog.Object, mock.Object);
            controller = new CategoriesController(service);
           
        }

        public override Task<IEnumerable<Category>> GetFakeList()
        {
            return CategoriesFakeModelProvider.CreateCategories();
        }

        public override Category GetInsertFake()
        {
            return CategoriesFakeModelProvider.GetInsertFake();
        }

        [Fact]
        public async Task InsertBlue()
        {
            mock.Setup(x => x.Save(It.IsAny<Category>()));

            var actionResult = await controller.Post(new Category() { Color= "blue"});

            var result = await Assert.ThrowsAsync<Exception>(() => controller.Post(new Category() { Color = "blue" }));
            Assert.Equal("blue nao pode", result.Message);
        }


        //[Fact]
        //public async Task GetAll()
        //{
        //    mock.Setup(x => x.GetAll()).Returns(CategoriesFakeModelProvider.CreateCategories());

        //    var actionResult = await controller.GetAll();

        //    var okResult = actionResult.Result as OkObjectResult;
        //    var result = okResult.Value as IEnumerable<Category>;

        //    Assert.Equal(2, result.Count());
        //}

        //[Fact]
        //public async Task Insert()
        //{
        //    mock.Setup(x => x.Save(It.IsAny<Category>())).Returns(Task.FromResult<long>(1));            

        //    var actionResult = await controller.Post(CategoriesFakeModelProvider.GetInsertFake());

        //    var okResult = actionResult.Result as OkObjectResult;
        //    var result = (long)okResult.Value;

        //    Assert.Equal(1, result);
        //}





    }
}
