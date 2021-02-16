using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrarySchedule.Model
{
    public class ModelSchedule
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public DateTime ScheduledTime { get; set; }
    }
}
