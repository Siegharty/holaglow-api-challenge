﻿using App.Models;
using System.Text.Json;

namespace App
{
    public class PeopleDataStore
    {
        public List<PeopleModel> Peoples { get; set; }
        public static PeopleDataStore Current { get; } = new PeopleDataStore();

        public static List<PeopleModel> RetrievePeopleObject()
        {
            try
            {
                var jsonFile = File.ReadAllText("names.json");
                var peopleObject = JsonSerializer.Deserialize<PeopleResponseModel>(jsonFile);

                if (peopleObject?.response == null)
                {
                    return new List<PeopleModel>();
                }

                return peopleObject.response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al almacenar los datos en la base de datos: {ex.Message}");
                return new List<PeopleModel>();
            }
        }

        public PeopleDataStore()
        {
            Peoples = RetrievePeopleObject();
        }
    }

}