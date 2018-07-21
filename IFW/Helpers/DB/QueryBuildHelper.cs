using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class QueryBuildHelper
    {
        public static string BuildSelect_LikeValues(string tableOrQueryName,string []FieldName,
            string[]EnteredValue,string orderby)//,bool IsTable)
        {
            string q = "select ";
            int l = FieldName.Count();
            for (int i = 0; i <l-1; i++)
                q += "[" + FieldName[i] + "],";
            q += "[" + FieldName[l - 1] + "] ";
            q +=" from "+ tableOrQueryName;
          
            bool hasWhere = false;

            for(int i=0;i<FieldName.Count();i++)
            {
                if(EnteredValue[i]!=null)
                    if (EnteredValue[i].Trim() != "")
                    {
                        
                        if (hasWhere)
                        {
                            if (EnteredValue[i].IndexOf("/") > 0)//' it is a date field'
                            {
                                EnteredValue[i] = EnteredValue[i].Replace("/","-");
                                if (i == 0)
                                    q += " CONVERT(VARCHAR(25), " + FieldName[i] + ", 126) LIKE '%" + EnteredValue[i] + "%'";
                                else
                                    q += " and " + " CONVERT(VARCHAR(25), " + FieldName[i] + ", 126) LIKE '%" + EnteredValue[i] + "%'";
                            }
                            else
                            {
                                if (i == 0)
                                    q += FieldName[i] + " like '%" + EnteredValue[i] + "%'";
                                else
                                    q += " and " + FieldName[i] + " like '%" + EnteredValue[i] + "%'";
                            }
                        }
                        else
                        {
                            if (EnteredValue[i].IndexOf("/") > 0)//' it is a date field'
                            {
                                EnteredValue[i] = EnteredValue[i].Replace("/", "-");
                                q += " where " + " CONVERT(VARCHAR(25), " + FieldName[i] + ", 126) LIKE '%" + EnteredValue[i] + "%'";

                            }
                            else
                                q += " where " + FieldName[i] + " like '%" + EnteredValue[i] + "%'";
                            hasWhere = true;
                        }
                    }
            }
            if(orderby!=null)
                q += " order by " + orderby;
            return q;
           
        }
        public static string BuildSelect_HaveValues(string tableOrQueryName,string returnFlields,
            string[] FieldName, string[] Values, string orderby)//,bool IsTable)
        {

            string q = "select  "+ returnFlields + " from "+tableOrQueryName +" where ";
            int n = FieldName.Count();
            bool IsFirst = true;

            for(int i=0;i<n;i++)
            {
                if (Values[i].Trim() != "")
                {
                    if (IsFirst)
                    {
                        q += FieldName[i] + "'" + Values[i] + "' ";
                        IsFirst = false;
                    }
                    else
                        q +=" and "+ FieldName[i] + "'" + Values[i] + "' ";
                }
            }

            return q+ orderby;
        }
        public static string BiuldUpdate(string tableName,string[] FiledName,string [] Enteredvalue,string whereClause)
        {
            string q = "update  " + tableName;
            q += " set ";
            bool isFirstFieldsBlank = false;
            for(int i=0;i<FiledName.Count();i++)
            {
                if (i == 0)
                {
                    if (Enteredvalue[i] != "")
                        q += FiledName[i] + "= '" + Enteredvalue[i] + "'";
                    else
                        isFirstFieldsBlank = true ;
                }
                else
                {
                    if (Enteredvalue[i] != "")
                    {
                        if (isFirstFieldsBlank == false)
                            q += "," + FiledName[i] + "= '" + Enteredvalue[i] + "'";
                        else
                        {
                            q += FiledName[i] + "= '" + Enteredvalue[i] + "'";
                            isFirstFieldsBlank = false ;
                        }
                    }
                }
            }
            if(whereClause!="")
                q += " where " + whereClause;
            return q;
        }
        public static string BiuldUpdate_EvenBlankValues(string tableName, string[] FiledName, string[] Enteredvalue, string whereClause)
        {
            string q = "update  " + tableName;
            if(Enteredvalue[0]!=null)
                q += " set "+ FiledName[0] + "= '" + Enteredvalue[0] + "'";
            else
                q += " set " + FiledName[0] + "= NULL ";

            for (int i = 1; i < FiledName.Count(); i++)
            {
                if (Enteredvalue[i] != null)
                    q += "," + FiledName[i] + "= '" + Enteredvalue[i] + "'";
                else
                    q += "," + FiledName[i] + "= NULL ";
            }
            if (whereClause != "")
                q += " where " + whereClause;
            return q;
        }
        public static string BiuldInsert_EvenBlankValues(string tableName, string[] FiledName, string[] Enteredvalue)
        {
            string q = "insert into " + tableName;
            q += " ( ";
            int cnt = FiledName.Count();
            for (int i = 0; i < cnt; i++)
            {
                if (i == 0)
                    q += FiledName[i] ;
                else
                    q += "," + FiledName[i] ;
            }
            q += ") values(";

            for (int i = 0; i < cnt; i++)
            {
                if (i == 0)
                {
                    if (Enteredvalue[0] != null)
                        q += " '" + Enteredvalue[i] + "'";
                    else
                        q += "NULL";
                }
                else
                {
                    if (Enteredvalue[i] != null)
                        q += ", '" + Enteredvalue[i] + "'";
                    else
                        q += ", NULL";
                }
            }

            q += ") " ;
            return q;
        }

        public static string BiuldInsert(string tableName, string[] FiledName, string[] Enteredvalue)
        {
            string q = "insert into " + tableName;
            q += " ( ";
            int cnt = FiledName.Count();
            for (int i = 0; i < cnt; i++)
            {
                if (i == 0)
                    q += FiledName[i];
                else
                    q += "," + FiledName[i];
            }
            q += ") values(";

            for (int i = 0; i < cnt; i++)
            {
                if (i == 0)
                    q += " '" + Enteredvalue[i] + "'";
                else
                    q += ", '" + Enteredvalue[i] + "'";
            }

            q += ") ";
            return q;
        }
    }
}
