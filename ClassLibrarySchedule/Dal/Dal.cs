using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrarySchedule.Model;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrarySchedule
{
    public class Dal
    {
        const string ConnectionString = @"Data Source=WINDEV2002EVAL\SQLEXPRESS;Initial Catalog=Estudos;Integrated Security=True";

        public List<ModelSchedule> Schedules()
        {
            List<ModelSchedule> ReturnList = new List<ModelSchedule>();
            using(SqlConnection connection = StringConnection )
            {

            }
        }
    }
}
