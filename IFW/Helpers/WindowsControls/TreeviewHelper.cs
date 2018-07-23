public class TreeviewHelper
{
    public static string MakeAtribString Xml.XmlNode x1)
   {
        Int i ;
        string s ;

        for( i = 0;i< x1.Attributes.Count - 1;i++)
            s += x1.Attributes(i).Name + " = " + x1.Attributes(i).Value + " , "
        
        return s;
    }

   public static  AddNodes(ByVal xmlNode1 As Xml.XmlNode, ByVal tvNode1 As TreeNode)
 {
        Xml.XmlNode x1 ;
        TreeNode tn1 ;

        foreach( x1 In xmlNode1)
      {
            tn1 = tvNode1.Nodes.Add(MakeAtribString(x1));
            AddNodes(x1, tn1);
        }
   }

    pulic static void  FillTree ( TreeView tv,  Xml.XmlDocument xd)
{
        Xml.XmlNode m;
        TreeNode n1;

        tv.Nodes.Clear();
        n1 = tv.Nodes.Add("XML");
        Foreach( m In xd)
            AddNodes(m, n1);
        
    }
}

