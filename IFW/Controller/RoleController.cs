using Helpers.DB;
using IFramework.Helpers;
using IFramework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IFramework.Controller
{
   public  class RoleController
    {

        public static List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection conn = new SqlConnection())
            {
                //conn.ConnectionString = DBHelper.getConnectionString();
                //conn.Open();

                string [] colNames;
                string sql = "select RoleId,name from TblRole order by RoleId";

                List<Hashtable> htlist = DBHelper.RunSelectQuery(sql,out colNames);
                for (int i = 0; i < htlist.Count; i++)
                {
                    roles.Add(new Model.Role(
                        int.Parse(htlist[i][0].ToString()),
                        htlist[i][1].ToString()
                     )   );                    

                }
                //SqlCommand command = new SqlCommand(sql, conn);
                //SqlDataReader sdr = command.ExecuteReader();
                //while (sdr.Read())
                //{
                //    roles.Add(new Model.Role(int.Parse(sdr[0].ToString()), sdr[1].ToString()));
                //}
                //sdr.Close();
                //conn.Close();
            };
            return roles;
        }
        public static List<string> GetRoleNams()
        {
            string q = "select  name from TblRole order by RoleId";
            string[] cols;
            List<Hashtable> roles=DBHelper.RunSelectQuery(q, out cols);
            List<string>  strRoles= new List<string>();
            foreach (Hashtable itm in roles)
                strRoles.Add(itm[0].ToString());
            return strRoles;
        }
        public static string getRoleId(string roleName)
        {
            string q = " select RoleId from TblRole where name='" + roleName + "'";
            bool IsSuccessfull = true;
           string roleid= DBHelper.RunSelectQuery(q,out IsSuccessfull).ToString();
            return roleid;
        }
    }
}
