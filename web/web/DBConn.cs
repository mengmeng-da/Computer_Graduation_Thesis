using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace web
{
    public class DBConn
    {
        //连接数据库
        public SqlConnection OpenConn()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            var aaa = scsb.ToString();
            scsb.DataSource = "MMD-PC\\SQLEXPRESS";//本机IP
            scsb.UserID = "sa";//数据库名称
            scsb.Password = "123456";
            scsb.InitialCatalog = "user_info";

            SqlConnection conn = new SqlConnection(scsb.ToString());
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            return conn;

        }
    }
}