using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
namespace web
{
    /// <summary>
    /// UserinfoService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class UserinfoService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public bool Login(string user_no, string user_pwd)
        {
            try
            {
                int row_count = Convert.ToInt32(SqlHelper.Instance.ExecuteScalar("SELECT COUNT(1) FROM base_info WHERE user_no=@user_no AND user_pwd =@user_pwd", new SqlParameter("@user_no", user_no), new SqlParameter("@user_pwd", user_pwd)));
                if (row_count > 0)
                    return true;//返回不了true
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            ////拼接sql语句
            //string strSQL = "SELECT * FROM base_info WHERE user_no='" + user_no + "'AND user_pwd='" + user_pwd + "'";
            //DBConn dbconn = new DBConn();
            //SqlConnection conn = dbconn.OpenConn();

            //SqlCommand comm = new SqlCommand(strSQL,conn);
            //int row_count = comm.ExecuteNonQuery();
            //if (row_count > 0)
            //    return true;//返回不了true
            //return false;
        }

        [WebMethod]
        public bool Register(string user_no, string user_pwd, string user_name)
        {

            try
            {
                //拼接sql语句
                string strSQL = @"INSERT INTO [user_info].[dbo].[base_info]
           ([user_no]
           ,[user_name]
           ,[user_pwd])
     VALUES
           ('" + user_no + @"'
           ,'" + user_name + @"'
           ,'" + user_pwd + @"'
   )";
                bool ret = SqlHelper.Instance.ExecuteNonQuery(strSQL) > 0;
                return ret;
            }
            catch (Exception ex)
            {
                return false;
            }

            //DBConn dbconn = new DBConn();
            //SqlConnection conn = dbconn.OpenConn();

            //SqlCommand comm = new SqlCommand(strSQL, conn);

            //try
            //{
            //    int row_count = comm.ExecuteNonQuery();//  执行sql语句，返回搜影响的行数
            //}catch(Exception ex)
            //{
            //    return ex.Message;
            //}
            ////if (row_count > 0)
            ////    return true;//返回不了true
            ////return false;

            //return null;
        }

    }

}