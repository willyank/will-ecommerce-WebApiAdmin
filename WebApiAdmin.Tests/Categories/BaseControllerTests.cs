using EcommerceModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiAdmin.Controllers;
using WebApiAdmin.Repositories;
using WebApiAdmin.Repositories.Interfaces;
using WebApiAdmin.Services;
using Xunit;

namespace WebApiAdmin.Tests.Categories
{
    public abstract class BaseCrudControllerTests<T> where T : BaseModel, new()
    {
        protected Mock<IBaseRepository<T>> baseMock;
        protected BaseCrudController<T> baseController;

        public BaseCrudControllerTests()
        {
            this.baseMock = new Mock<IBaseRepository<T>>();
            var baseService = new BaseCrudService<T>(baseMock.Object);
            baseController = new BaseCrudController<T>(baseService);
        }

        public abstract Task<IEnumerable<T>> GetFakeList();
        public abstract T GetInsertFake();

        //private Task<IEnumerable<T>> GetFakeList()
        //{
        //    IEnumerable<T> list = new List<T>()
        //        {
        //            new T()
        //        {
        //            Id = 1,
        //        },
        //            new T()
        //        {
        //            Id = 2,
        //        }
        //    };

        //    return Task.FromResult(list);
        //}

        [Fact]
        public async Task GetAllGeneric()
        {
            var t = Mock.Of<ICategoriesRepository>();
            baseMock.Setup(x => x.GetAll()).Returns(GetFakeList());

            var actionResult = await baseController.GetAll();

            var okResult = actionResult.Result as OkObjectResult;
            var result = okResult.Value as IEnumerable<Category>;

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task InsertGeneric()
        {
            baseMock.Setup(x => x.Save(It.IsAny<T>())).Returns(Task.FromResult<long>(1));

            var actionResult = await baseController.Post(GetInsertFake());

            var okResult = actionResult.Result as OkObjectResult;
            var result = (long)okResult.Value;

            Assert.Equal(1, result);
        }

    }
}
