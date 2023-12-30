﻿using App.Models;

namespace App.Data
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<PeopleModel>> GetListOfNamesAsync();
    }
}