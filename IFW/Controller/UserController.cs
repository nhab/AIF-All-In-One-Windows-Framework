using IFramework.Helpers;
using IFramework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace IFramework.Controller
{
   public  class UserController
    {

        public static void AddUserToDB(string UserName,int RoleID)
        {
            string sql = "Insert into TblUser (UserName,RoleID)values('";
            sql += UserName + "'," + RoleID.ToString() + ")";
           
            bool b;
            DBHelper.RunSql(sql, out b);
        }
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string sql = "select UserName,r.name from TblUser u ";
            sql+= "inner join tblRole r on u.RoleId = r.RoleId order by UserName";
            string[] colNames;
            List<Hashtable> htUserList= DBHelper.RunSelectQuery(sql, out colNames);
            for (int i = 0; i < htUserList.Count; i++)
                users.Add(
                    new User(htUserList[i][0].ToString(),
                    htUserList[i][1].ToString()
                    ) ) ;
         
            return users;
        }
        public static void DeleteUser(string UserName)
        {
            string sql = "delete TblUser where UserName='" + UserName + "';";
            bool isSuccess;
            DBHelper.RunSql(sql,out isSuccess);
        }
    }
}
