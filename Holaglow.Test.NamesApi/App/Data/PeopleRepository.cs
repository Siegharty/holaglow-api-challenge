using App.Models;

namespace App.Data
{
    public class PeopleRepository : IPeopleRepository
    {
        public async Task<IEnumerable<PeopleModel>> GetListOfNamesAsync()
        {
            var listOfPeople = PeopleDataStore.Current.Peoples.ToList();
            return listOfPeople;
        }

        public async Task<IEnumerable<PeopleModel>> GetListOfNamesAsync(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await GetListOfNamesAsync();
            }

            name = name.Trim().ToLower();
            return PeopleDataStore.Current.Peoples.Where(p => p.name.ToLower().StartsWith(name)).OrderBy(p => p.name).ToList();
        }
    }
}
