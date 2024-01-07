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

        public async Task<IEnumerable<PeopleModel>> GetListOfNamesAsync(PeopleValidationParams peopleParams)
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

            return peopleStore
                .OrderBy(p => p.name)
                .Skip(peopleParams.Size * (peopleParams.Page - 1))
                .Take(peopleParams.Size)
                .ToList();
        }
    }
}
