using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDB
    {
        public bool User_add(Models.User model){ 
        
        string setting=ConfigurationManager.CconnectionStrings["ConnectionString"].ToString;
        SqlConnection myconn = new SqlCommand("insert to dbo.[user]([name])values(@name)",myconn); 
        }
    }
}
