using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Model
{
     public  class Role
    {
        public int RoleId;
        public string Name;
        public Role( int roleId,string name)
        {
            Name = name;
            RoleId = roleId;
        }
      
    }
}
