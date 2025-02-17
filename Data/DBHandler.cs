using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BillAutomation      //DO NOT change the namespace name
{
    public class DBHandler    //DO NOT change the class name
    {
        //Implement the methods as per the description
        public DBHandler(){}
        public SqlConnection GetConnection()
        {
            string CS=ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            SqlConnection conn=new SqlConnection(CS);
            return conn;
        }
    }
}
