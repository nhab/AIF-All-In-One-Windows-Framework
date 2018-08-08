
using Helpers.DB;
using IFramework.Controller;
using IFramework.Model;
using System.Collections;
using System.Collections.Generic;

using System.Windows.Forms;

namespace Helpers
{
    public class ComboboxHelper
    {
        public static void RefreshRoleComboFromDB(ref ComboBox combo1)
        {
            List<Role> roles = RoleController.GetRoles();
            combo1.Items.Clear();
            for (int i = 0; i < roles.Count; i++)
                combo1.Items.Add(roles[i].Name);
        }
        public static void RefreshComboFromList(ref ComboBox combo1, List<string> list)
        {
            combo1.Items.Clear();
            for (int i = 0; i < list.Count; i++)
                combo1.Items.Add(list[i]);
        }

        public static void RefreshComboFromDB(ref ComboBox combo1, string tblName, string fldName)
        {
            string[] cols = { };
            List<Hashtable> lht = DBHelper.RunSelectQuery("select " + fldName + " from " + tblName, out cols);
            combo1.Items.Clear();
            for (int i = 0; i < lht.Count; i++)
                combo1.Items.Add(lht[i][0].ToString());
        }
    }
}
