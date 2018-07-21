using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Helpers
{
    public class ProjectHelper
    {
        public static void ShowWindow(string formName,Form f,string Assembleyname)
        {

            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            Type[] types = myAssembly.GetTypes();

            foreach (Type t in types)
            {
                if ((t.BaseType != null) && (t.BaseType.ToString().ToUpper() == "SYSTEM.WINDOWS.FORMS.FORM"))
                {
                    if (t.Name == formName)
                    {
                       
                        var instance = Activator.CreateInstance(t);
                     
                        (instance as Form).MdiParent = f;
                        (instance as Form).WindowState = FormWindowState.Maximized;
                        (instance as Form).Show();
                    }
                }
            }
        }
    }
}
