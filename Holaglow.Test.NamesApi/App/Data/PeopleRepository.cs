using App.Models;

namespace App.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleDataStore _peopleDataStore;
        public PeopleRepository()
        {
            _peopleDataStore = new PeopleDataStore();

        }

        public async Task<(IEnumerable<PeopleModel>, PeoplePaginationMetaData)> GetListOfNamesAsync(PeopleValidationParams peopleParams)
        {
            var nameIsNull = string.IsNullOrEmpty(peopleParams.Name);
            var genderIsNull = string.IsNullOrEmpty(peopleParams.Gender);

            var peopleStore = _peopleDataStore.Peoples.AsQueryable();

            if (!nameIsNull)
            {
                var nameTrimed = peopleParams.Name.Trim().ToLower();
                peopleStore = peopleStore.Where(p => p.name.ToLower().StartsWith(nameTrimed));
            }

            if (!genderIsNull)
            {
                var genderTrimed = peopleParams.Gender.Trim().ToLower();
                peopleStore = peopleStore.Where(p => !genderIsNull && p.gender.ToLower() == genderTrimed);
            }

            var totalPeopleCount = peopleStore.Count();

            var paginationMetaData = new PeoplePaginationMetaData(totalPeopleCount, peopleParams.Size, peopleParams.Page);

            var collectionToReturn = peopleStore
                .OrderBy(p => p.name)
                .Skip(peopleParams.Size * (peopleParams.Page - 1))
                .Take(peopleParams.Size)
                .ToList();

            return (collectionToReturn, paginationMetaData);
        }
    }
}
