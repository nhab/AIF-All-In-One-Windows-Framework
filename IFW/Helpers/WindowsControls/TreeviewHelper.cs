using System.Windows.Forms;
using System.Xml;

public class TreeviewHelper
{
    public static string MakeAtribString (System.Xml.XmlNode x1)
   {
        int i ;
        string s ="";

        for (i = 0; i < x1.Attributes.Count - 1; i++)
            s += x1.Attributes[i].Name + " = " + x1.Attributes[i].Value + " , ";
        
        return s;
    }

   public static  void AddNodes(System.Xml.XmlNode xmlNode1 , TreeNode tvNode1 )
 {
        
        TreeNode tn1 ;

        foreach(System.Xml.XmlNode x1 in xmlNode1.ChildNodes)
      {
            tn1 = tvNode1.Nodes.Add(MakeAtribString(x1));
            AddNodes(x1, tn1);
        }
   }

    public static void  FillTree ( TreeView tv, System.Xml.XmlDocument xd)
{
        TreeNode n1;

        tv.Nodes.Clear();
        n1 = tv.Nodes.Add("XML");
        foreach(System.Xml.XmlNode  m in xd)
            AddNodes(m, n1);
        
    }
}

