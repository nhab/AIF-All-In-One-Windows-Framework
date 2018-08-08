using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Helpers.DB;

namespace GeneralLib.Controls
{
    public partial class comboBoxEx : ComboBox
    {
        string m_tableName="";
        string m_caption;
        ConnectionStr m_cs;
        bool m_isDistinct=false ;
        bool m_IsMandatory = false;

        public comboBoxEx()
        {
            InitializeComponent();
            Fill();
        }
        public comboBoxEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Fill();
        }

        public string ExCaption
        {
            get { return m_caption; }
            set { m_caption = value; }
        }
        //____________________________________________
        public string ExTableName
        {
            get { return m_tableName; }
            set { m_tableName = value; }
        }
        //____________________________________________
        public ConnectionStr ExConnectionStr
        {
            get { return m_cs; }
            set {m_cs=value;}
        }
        //____________________________________________
        public bool ExIsMandatory
        {
            get { return m_IsMandatory; }
            set { m_IsMandatory = value; }
        }
        //____________________________________________
        public bool ExIsDistinct
        {
            get { return m_isDistinct; }
            set { m_isDistinct = value; }
        }
        //____________________________________________
        public void  Fill()
        {

            if (m_cs != null)
            {
                System.Data.DataTable dt;
                if ((m_tableName == null) || (m_tableName == "")) return;
                string sql;
                if (m_isDistinct)
                    sql = "select  distinct "+this.DisplayMember +" from " + m_tableName;
                else
                    sql = "select * from " + m_tableName;
                
                
                dt=DBHelper.getDataTable(m_cs.ConnectionString  , sql );
                this.DataSource = dt;
            }
        }
        //____________________________________________
        public bool exCheckValidation()
        {
            if (m_IsMandatory)
            {
                if (this.SelectedIndex < 0)
                {
                    MessageBox.Show( m_caption + " Can`t be empty.");
                    this.Focus();
                    return false;
                }
             
            }
            return true;
        }
    }
}
