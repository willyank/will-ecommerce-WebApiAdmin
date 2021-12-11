using EcommerceModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NgStore.Framework.Logs;
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
        protected Mock<ILoggerService> mockLog;
        protected BaseCrudController<T> baseController;


        public BaseCrudControllerTests()
        {
            this.baseMock = new Mock<IBaseRepository<T>>();
            mockLog = new Mock<ILoggerService>();

            var baseService = new BaseCrudService<T>(mockLog.Object, baseMock.Object);
            baseController = new BaseCrudController<T>(baseService);
        }

        public abstract Task<IEnumerable<T>> GetFakeList();
        public abstract T GetFakeObject();

        [Fact]
        public async Task GetAllGeneric()
        {
            baseMock.Setup(x => x.GetAll()).Returns(GetFakeList());

            var actionResult = await baseController.GetAll();

            var okResult = actionResult.Result as OkObjectResult;
            var result = okResult.Value as IEnumerable<Category>;

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public async Task GetPaginatedGeneric()
        {
            var list = await GetFakeList();
            var mockPage = new Pagination<T>() { Items = list.ToList(), Total = list.Count() };
            baseMock.Setup(x => x.GetPaginated(0, 4, null)).Returns(Task.FromResult(mockPage));

            var actionResult = await baseController.GetPaginated(0, 4);

            var okResult = actionResult.Result as OkObjectResult;
            var result = okResult.Value as Pagination<Category>;

            Assert.Equal(4, result.Items.Count());
        }

        [Fact]
        public async Task InsertGeneric()
        {
            baseMock.Setup(x => x.Save(It.IsAny<T>())).Returns(Task.FromResult<long>(1));

            var actionResult = await baseController.Post(GetFakeObject());

            var okResult = actionResult.Result as OkObjectResult;
            var result = (long)okResult.Value;

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetGeneric()
        {
            var obj = (await GetFakeList()).FirstOrDefault(f => f.Id == 1);
            baseMock.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(obj));

            var actionResult = await baseController.Get(1);
            var okResult = actionResult.Result as OkObjectResult;

            var returnObject = okResult.Value as T;

            Assert.Equal(1, returnObject.Id);
        }

    }
}
