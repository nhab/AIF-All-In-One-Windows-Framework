using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Helpers.DB;

public  class MetaDataClass
    {
       public static string strCN;
       public static  void FillTablesCombo(ComboBox cmbTables)
       {
           string s = "select TABLE_NAME from information_schema.Tables";
           DataTable dt = DBHelper.getDataTable(strCN, s);
           cmbTables.Items.Clear();
           cmbTables.Text = "";
           for (int i = 0; i < dt.Rows.Count; i++)
               cmbTables.Items.Add(dt.Rows[i][0].ToString());
       }
       
       //_________________________________________________________
       public static  void FillFieldsCombo(string tableName, ComboBox cmbFields)
       {
           //selectedTable = tableName;
           string s = "select COLUMN_NAME from ";
           s += " information_Schema.Columns where TABLE_NAME='" + tableName + "'";
           DataTable dt = DBHelper.getDataTable(strCN, s);
           cmbFields.Items.Clear();
           cmbFields.Text = "";
           for (int i = 0; i < dt.Rows.Count; i++)
               cmbFields.Items.Add(dt.Rows[i][0].ToString());

       }
       //_________________________________________________________
       public static void FillFieldValueLists(string tableName,string fieldName,ListBox lb)
       {
           string s = "select " + fieldName + " from " + tableName;
         
           DataTable dt = DBHelper.getDataTable(strCN, s);
           lb.Items.Clear();
           int i;

           for (i = 0; i < dt.Rows.Count;i++ )
               lb.Items.Add(dt.Rows[i][0].ToString() );
       }
       //_________________________________________________________
       public static void FillFieldValueLists(string tableName, string ListFieldName,string ValueFieldName, ListView  lv)
       {
           string s = "select distinct " + ListFieldName+","+ValueFieldName  + " from " + tableName;
           
           DataTable dt =DBHelper.getDataTable(strCN, s);
           lv.Items.Clear();
           int i;
           ListViewItem lvi;
           for (i = 0; i < dt.Rows.Count; i++)
           {
               lvi=lv.Items.Add(dt.Rows[i][ListFieldName ].ToString());
               lvi.SubItems.Add(dt.Rows[i][ValueFieldName].ToString());
           }
       }
       //_____________________________________________________________________________________
       public static void FillFieldsList(string tableName, string FieldName, ListView lv)
       {
           string s = "select distinct " + FieldName  + " from " + tableName+" order by "+FieldName ;
           
           DataTable dt = DBHelper.getDataTable(strCN, s);
           lv.Items.Clear();
           int i;
           ListViewItem lvi;
           for (i = 0; i < dt.Rows.Count; i++)
               lvi = lv.Items.Add(dt.Rows[i][FieldName].ToString());
       }
       //_____________________________________________________________________________________
       public static void FillAllFieldsList(string tableName, string FieldName, ListView lv)
       {
           string s = "select distinct " + FieldName + " from " + tableName + " order by " + FieldName;
         
           DataTable dt = DBHelper.getDataTable(strCN, s);
           lv.Items.Clear();
           int i;
           ListViewItem lvi;
           for (i = 0; i < dt.Rows.Count; i++)
               lvi = lv.Items.Add(dt.Rows[i][FieldName].ToString());
       }
    }
