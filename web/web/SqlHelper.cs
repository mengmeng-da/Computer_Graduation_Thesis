using System.Data;
using System.Data.SqlClient;
namespace web
{
    public class SqlHelper 
    {
        //public static SqlHelper Instance = new SqlHelper(System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString());
        public static SqlHelper Instance = new SqlHelper(@"Data Source=MMD-PC\SQLEXPRESS;Initial Catalog=user_info;User ID=sa;Password=123456");
        public SqlHelper(string connStr)
        {
            this.connStr = connStr;
        }
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string connStr;
        /// <summary>
        ///  增删改，返回受影响函数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询单个值
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;//清除旧数据
                    cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 查询多行多列
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;//
                    cmd.Parameters.AddRange(parameters);
                    DataTable dt = new DataTable();//1.新建数据集
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);//2.填充数据集
                    }
                    return dt;//3.返回数据集的一张表，因为这里返回的是一张表，所以没有第4步和第5步了。
                }
            }
        }
    }
}
