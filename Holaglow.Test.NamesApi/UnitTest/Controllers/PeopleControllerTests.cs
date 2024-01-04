using App.Controllers;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            _mockPeopleRepository
               .Setup(repo => repo.GetListOfNamesAsync(It.IsAny<string>(), It.IsAny<string>()))
               .ReturnsAsync(new List<PeopleModel>() { new PeopleModel() { gender = "M", name = "Kevin" } });
            PeopleController _controller = new PeopleController(_mockPeopleRepository.Object);

            PeopleValidationParams _validationParams = new PeopleValidationParams();
            var result = await _controller.GetNamesAsync(_validationParams);
            var getResultValue = GetObjectResult.GetValue(result);


            Assert.That(getResultValue.Count(), Is.EqualTo(1));
            Assert.IsInstanceOf<ActionResult<IEnumerable<PeopleModel>>>(result);
        }
    }
}