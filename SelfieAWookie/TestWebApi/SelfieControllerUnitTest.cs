using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SelfieAWookie.Application.DTO_s;
using SelfieAWookie.Controllers;
using SelfieAWookie.Core.Framework;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System.Collections.Generic;
using Xunit;

namespace TestWebApi
{
    public class SelfieControllerUnitTest
    {
        private readonly SelfiesContext context2;

        [Fact]
        public void ShouldAddOneSelfies()
        {
            SelfieDTO selfie =new SelfieDTO();
            var repositoryMock = new Mock<ISelfieRepository>();
            var unit = new Mock<IUnitOfWork>();
            repositoryMock.SetupGet(x => x.UnitOfWork).Returns(unit.Object);
            repositoryMock.SetupGet(x => x.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() { Id = 4 });

            var controller = new SelfieController(repositoryMock.Object);
            var result = controller.AddOne(selfie);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var addedSelfie = (result as OkObjectResult).Value as SelfieDTO;
            Assert.NotNull(addedSelfie);
            Assert.True(addedSelfie.Id > 0);

        }

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            var repositoryMock = new Mock<ISelfieRepository>();

            repositoryMock.Setup(item => item.GetAll(null)).Returns(new List<Selfie>()
            {
                new Selfie(){Wookie = new Wookie()},
                new Selfie(){Wookie = new Wookie()}
            });

            var controller = new SelfieController(repositoryMock.Object);

            var result = controller.GetAll(null);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult =  result as OkObjectResult;

            Assert.IsType<List<SelfieResumeDTO>>(okResult.Value);
            Assert.NotNull(okResult.Value);

            List<SelfieResumeDTO> list = okResult.Value as List<SelfieResumeDTO>;
            Assert.NotNull(list);
            Assert.True(list.Count == 2);
            
        }
        
    }
}