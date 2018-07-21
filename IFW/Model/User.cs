using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Model
{
    public class User
    {
        public string UserName;
        public int RoleId;
        public string  RoleName;
        public User(string userName,string role)
        {
            UserName = userName;
            RoleName = role ;
        }
    }
}
