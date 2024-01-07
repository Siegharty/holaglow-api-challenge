using App.Controllers;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnitTest.Helpers;

namespace UnitTest.Controllers
{

    [TestFixture]
    public class PeopleControllerTests
    {

        [Test]
        public async Task ShouldReturnOneName()
        {
            Mock<IPeopleRepository> _mockPeopleRepository = new Mock<IPeopleRepository>();
            Mock<ILogger<PeopleController>> _mockLogger = new Mock<ILogger<PeopleController>>();

            PeopleValidationParams _validationParams = new PeopleValidationParams() { Name = "", Gender = "", Page = 1, Size = 10 };
            PeoplePaginationMetaData paginationMetaData = new PeoplePaginationMetaData(1, 1, 1);

            _mockPeopleRepository
               .Setup(repo => repo.GetListOfNamesAsync(_validationParams))
               .ReturnsAsync((new List<PeopleModel>() { new PeopleModel() { gender = "M", name = "Kevin" } }, paginationMetaData));

            PeopleController _controller = new PeopleController(_mockPeopleRepository.Object, _mockLogger.Object);

            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();           

            var result = await _controller.GetNamesAsync(_validationParams);
            var getResultValue = GetObjectResult.GetValue(result);


            Assert.That(getResultValue.Count(), Is.EqualTo(1));
            Assert.IsInstanceOf<ActionResult<IEnumerable<PeopleModel>>>(result);
        }
    }
}