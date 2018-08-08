using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Helpers.DB
{
    public enum SqlRunStatus
    {
        successfull,
        hasError,
        AlreadyHasTheValue
    }
    public class DBHelper
    {
        public static string sInfoFileName="ft64sys.dll";
        public static string passPhrase="1dfes3r*t43#$@#$";

        public static string connectionString;
        public static void  setConnectionString()
        {
            bool IsSuccess;
            string sContent=FileHelper.ReadFile(sInfoFileName,out IsSuccess);
            if (!IsSuccess)
            {
                string sCN = "Data Source=someServer;" +
               // "Initial Catalog=;" +
              //  "User id=;" +
                "Password=";
                string sEncrypted=EncryptionHelper.Encrypt(sCN, passPhrase);
                FileHelper.WriteStrToFile(sInfoFileName, sEncrypted);
            }
            connectionString = EncryptionHelper.Decrypt(sContent,passPhrase);
           
        }
        /// <summary>
        /// Runs the given query
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>
        /// blank if everything is ok ,
        /// error message in case of error
        /// id of newly inserted or updated record;
        /// </returns>
        public static string RunSql(string sql, out bool successful)
        {
            sql += ";select @@IDENTITY;";
            string id = "0";

            successful = true;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
          
                try
                {
                    id=command.ExecuteScalar().ToString();
                }catch(Exception ex)
                {
                    successful = false;
                    id= ex.Message ;
                }
                conn.Close();
             
            }
            return id;
        }
      
        public static List<Hashtable> RunSelectQuery(string sql,out string[] colNames)
        {
            List<Hashtable> result = new List<Hashtable>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                SqlDataReader sdr = command.ExecuteReader();

                colNames = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                    colNames[i] = sdr.GetName(i);

                while (sdr.Read())
                {
                    Hashtable cols = new Hashtable();
                    for (int c = 0; c < sdr.FieldCount; c++)
                        cols.Add(c, sdr[c].ToString());//columns[c]
                      
                    result.Add(cols);
                };

                sdr.Close();
                conn.Close();
            }
            return result;
        }
         /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="colNames"></param>
        /// <returns>the hashtable with correct keyNames </returns>
        public static List<Hashtable> RunSelectQueryWithKeys(string sql, out string[] colNames)
        {
            List<Hashtable> result = new List<Hashtable>();

            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);
                command.CommandTimeout = 0;
                SqlDataReader sdr = command.ExecuteReader();

                colNames = new string[sdr.FieldCount];
                for (int i = 0; i < sdr.FieldCount; i++)
                    colNames[i] = sdr.GetName(i);

                while (sdr.Read())
                {
                    Hashtable cols = new Hashtable();
                    for (int c = 0; c < sdr.FieldCount; c++)
                        cols.Add(colNames[c], sdr[c].ToString());
                    result.Add(cols);
                };

                sdr.Close();
                conn.Close();
            }
            return result;
        }
        public static object RunSelectQuery(string sql,out bool successful)
        {
            object result1="";
            successful = true;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                SqlDataReader sdr = command.ExecuteReader();
                sdr.Read();
                try
                {
                    if (sdr.HasRows)
                        result1 = sdr[0];
                    else
                        result1 = null;
                }
                catch (Exception ex)// usually becaause of using selectquery instead of runsql
                {
                    string x = ex.ToString();
                    System.Diagnostics.Debugger.Break();
                    successful = false;
                    return null;
                }
                sdr.Close();
                conn.Close();
            }
            return result1;
        }
        public static string RunTransactSqls(string[] sqls, out bool successful)
        {
           successful = true;
            
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();

                var tran = conn.BeginTransaction();
                SqlCommand cmd;
                for (int i = 0; i < sqls.GetLength(0); i++)
                {
                    try
                    {
                        cmd = new SqlCommand(sqls[i], conn);
                        cmd.Transaction= tran;
                        cmd.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Ikap Database Transaction fail and rolled back.");
                        successful = false;
                        return "";
                    }
                }
                tran.Commit();
                conn.Close();
            }
            successful = true;
            return "";
        }
        public static void InsertBinaryFile(string tableName, string fieldName,byte[] fileConent,string filename,string curDate)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connectionString;
                conn.Open();
                filename = filename.Substring(filename.LastIndexOf("\\")+1);
                string q = "INSERT INTO " + tableName + "(" + fieldName + ",RecievedDROPTime,ReceievedTextFile_Name)";
                q+=" VALUES (@binaryValue,'"+curDate +"','" + filename+"')";
                using (SqlCommand cmd = new SqlCommand(q, conn))
                {
                    // Replace 8000, below, with the correct size of the field
                    cmd.Parameters.Add("@binaryValue", System.Data.SqlDbType.VarBinary, fileConent.GetLength(0)+10).Value =fileConent;
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static byte[] GetBinaryFile(string tbName,string fieldName, string whereClause)
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cm = cn.CreateCommand())
            {
                string q= "SELECT " + fieldName + " FROM   " + tbName;
                q += " WHERE  "+ whereClause;
                cm.CommandText = q;
                cn.Open();
                return cm.ExecuteScalar() as byte[];
            }
        }
        public static DataTable getDataTable(string ConnectionString, string Sql)
        {
            try
            {
                System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConnectionString);
                cn.Open();

                SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Sql, cn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();

                da.Fill(dt);
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static int RunNoneQuerySp(System.Data.SqlClient.SqlConnection cn, string spName, SqlParameter[] param)
        {
            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(spName, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(param);

            int n = cmd.ExecuteNonQuery();
            return n;
        }
        /*______________________________________________________________________________*/
        public static string RunScalerQuery(string ConnectionString, string sql)
        {
            System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConnectionString);
            cn.Open();

            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, cn);
            string s = cmd.ExecuteScalar().ToString();
            cn.Close();
            return s;
        }
        /*______________________________________________________________________________*/
        public static System.Data.SqlClient.SqlDataReader RunReader(string ConnectionString, string sql)
        {
            System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(ConnectionString);
            cn.Open();

            SqlCommand cmd = new System.Data.SqlClient.SqlCommand(sql, cn);
            cn.Close();
            return cmd.ExecuteReader();

        }
        /*______________________________________________________________________________*/
        public static System.Data.DataTable RunSqlDataTable(string ConnectionString, string sql)
        {
            try
            {
                System.Data.SqlClient.SqlDataAdapter da = new SqlDataAdapter(sql, ConnectionString);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n may be this sql is generated by a previous version.");
                return null;
            }
        }
    }
}
