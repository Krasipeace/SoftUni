﻿namespace BorderControl.Models
{
    using Interfaces;

    public class Citizen : IIdentify, IBirthdate
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}
