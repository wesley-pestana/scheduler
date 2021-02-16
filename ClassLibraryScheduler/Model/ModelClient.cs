using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryScheduler.Model
{
    public class ModelClient    
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public ModelClient(int id, string name, string address, int phone, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }

        public ModelClient()
        {
        }

        public ModelClient(string name, string address, int phone, string email)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
    }
}
