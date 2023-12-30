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
    }
}
