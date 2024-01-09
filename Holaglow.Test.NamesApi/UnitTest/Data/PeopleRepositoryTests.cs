using App.Data;
using App.Models;

namespace UnitTest.Data
{
    public class PeopleRepositoryTests
    {
        private PeopleRepository _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new PeopleRepository();
        }

        [Test]
        public async Task ShouldReturnAFilterGenderMale()
        {
            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "", Gender = "M", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(10));
            Assert.Multiple(() =>
            {
                foreach (var expected in result)
                {
                    Assert.AreEqual("M", expected.gender);
                }
            }
            );

        }

        [Test]
        public async Task ShouldReturnAFilterGenderFemale()
        {

            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "", Gender = "F", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(10));
            Assert.Multiple(() =>
            {
                foreach (var expected in result)
                {
                    Assert.AreEqual("F", expected.gender);
                }
            }
            );

        }

        [Test]
        public async Task ShouldReturnAPerson()
        {
            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "Andrea", Gender = "F", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task ShouldReturnAllPersons()
        {
            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "", Gender = "" };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(10));
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task ShouldReturnEmptyPerson()
        {
            PeopleValidationParams peopleParams = new PeopleValidationParams() { Name = "Marcel", Gender = "F", Page = 1, Size = 10 };

            var (result, metaData) = await _repository.GetListOfNamesAsync(peopleParams);

            Assert.That(result.Count(), Is.EqualTo(0));
            Assert.IsNotNull(result);

        }
    }
}
