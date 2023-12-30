namespace App.Models
{
    public class PeopleModel
    {
        public string name { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
    }

    public class PeopleResponseModel
    {
        public List<PeopleModel> response { get; set; }
    }
}
