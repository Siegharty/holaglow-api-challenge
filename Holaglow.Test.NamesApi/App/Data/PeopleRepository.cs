using App.Models;

namespace App.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly PeopleDataStore _peopleDataStore;
        public PeopleRepository() {
            _peopleDataStore = new PeopleDataStore();
        
        }
        public async Task<IEnumerable<PeopleModel>> GetAllNames()
        {
            var listOfPeople = _peopleDataStore.Peoples.ToList();
            return listOfPeople;
        }

        public async Task<IEnumerable<PeopleModel>> GetListOfNamesAsync(string name, string gender)
        {
            var nameIsNull = string.IsNullOrEmpty(name);
            var genderIsNull = string.IsNullOrEmpty(gender);

            if (nameIsNull && genderIsNull)
            {
                return await GetAllNames();
            }

            var peopleStore = _peopleDataStore.Peoples.AsQueryable();

            if (!nameIsNull)
            {
                var nameTrimed = name.Trim().ToLower();
                peopleStore = peopleStore.Where(p => p.name.ToLower().StartsWith(nameTrimed));
            }

            if (!genderIsNull)
            {
                var genderTrimed = gender.Trim().ToLower();
                peopleStore = peopleStore.Where(p => !genderIsNull && p.gender.ToLower() == genderTrimed);
            }

            return peopleStore.OrderBy(p => p.name).ToList();
        }
    }
}
