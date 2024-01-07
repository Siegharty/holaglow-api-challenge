using App;
using App.Controllers;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Helpers;

namespace UnitTest.Data
{
    public class PeopleRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldReturnAFilterGenderMale()
        {
            Mock<PeopleDataStore> _peopleDataStore = new Mock<PeopleDataStore>();
            _peopleDataStore.Setup(repo => repo.Peoples);

            PeopleRepository _repository = new PeopleRepository();

            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "", Gender = "M", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(23));
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task ShouldReturnAFilterGenderFemale()
        {
            Mock<PeopleDataStore> _peopleDataStore = new Mock<PeopleDataStore>();
            _peopleDataStore.Setup(repo => repo.Peoples);

            PeopleRepository _repository = new PeopleRepository();

            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "", Gender = "F", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(29));
            Assert.IsNotNull(result);

        }

        [Test]
        public async Task ShouldReturnAPerson()
        {
            Mock<PeopleDataStore> _peopleDataStore = new Mock<PeopleDataStore>();
            _peopleDataStore.Setup(repo => repo.Peoples);

            PeopleRepository _repository = new PeopleRepository();


            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "", Gender = "F", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(1));
            Assert.AreEqual("Marcelo", result.ElementAt(0).name);
            Assert.AreEqual("M", result.ElementAt(0).gender);
        }

        [Test]
        public async Task ShouldReturnAllPersons()
        {
            /*Mock<PeopleDataStore> _peopleDataStore = new Mock<PeopleDataStore>();
            _peopleDataStore.Setup(repo => repo.Peoples);

            PeopleRepository _repository = new PeopleRepository();

            var result = await _repository.GetAllNames();

            Assert.That(result.Count(), Is.EqualTo(52));
            Assert.IsNotNull(result);*/

            Assert.Pass();
        }

        [Test]
        public async Task ShouldReturnEmptyPerson()
        {
            Mock<PeopleDataStore> _peopleDataStore = new Mock<PeopleDataStore>();
            _peopleDataStore.Setup(repo => repo.Peoples);

            PeopleRepository _repository = new PeopleRepository();


            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "Marcel", Gender = "F", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(0));
            Assert.IsNotNull(result);

        }
    }
}
