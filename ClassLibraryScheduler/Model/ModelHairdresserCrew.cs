using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryScheduler.Model
{
    public class ModelHairdresserCrew
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public ModelHairdresserCrew(int id, string name, string address, int phone, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public ModelHairdresserCrew()
        {
        }

        public ModelHairdresserCrew(string name, string address, int phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}
