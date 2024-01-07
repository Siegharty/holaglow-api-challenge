namespace App.Models
{
    public class PeoplePaginationMetaData
    {
        public int TotalPeopleCount { get; set; }

        public int TotalPageCount { get; set; }

        public int Size { get; set; }
        public int CurrentPage { get; set; }

        public PeoplePaginationMetaData(int totalPeopleCount, int size, int currentPage)
        {
            TotalPeopleCount = totalPeopleCount;
            TotalPageCount = (int)Math.Ceiling(totalPeopleCount / (double)size);
            CurrentPage = currentPage;
            Size = size;


        }
    }
}
