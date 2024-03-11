using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TechDistribution.DAL
{
    public class UtilityDB
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            connDB.Open();
            return connDB;
        }
    }
}
