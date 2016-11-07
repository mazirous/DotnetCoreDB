using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            String sqlConnStr = "DATA SOURCE=webserver01.c7a8ybhlu9ao.us-west-2.rds.amazonaws.com;UID=dbascend;PWD=r8Wkoqij8Uk7m6An;DATABASE=ascend_travel;connection timeout=0;Max Pool Size = 600;Pooling = True";
            String sqlStr = "select top 10 * from Product";

            SqlConnection sqlConn = new SqlConnection(sqlConnStr);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlConn);
            try
            {
                string spid = String.Empty;
                string program_name = String.Empty;

                sqlConn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    spid = reader["ProductID"].ToString();
                    program_name = reader["Title"].ToString();
                    Console.WriteLine("pid=" + spid + " " + "title=" + program_name);
                }
                //Console.WriteLine("The server is:"+svrName); 
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConn.Close();
            }
            //Console.Read(); 
        }
    }
}