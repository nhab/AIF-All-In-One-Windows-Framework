using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace GeneralLib.Controls
{
    
////[Designer( typeof( listviewgridDesigner))]
    public partial class ListViewGrid : ListView 
    {
        public  event  EventHandler  ExSelectedRowChanged ;
       public ListViewGrid()
        {
            InitializeComponent();
            this.View = View.Details;
            this.FullRowSelect = true;
        }
        //________________________________
        public ListViewGrid(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        int m_testp;
        public int testp
        {
            get { return m_testp; }
            set { m_testp = value; }
        }
        //________________________________
        public void AddValues(int count,string []s)
        { 
            if(count<=0)return ;
            ListViewItem lv= this.Items.Add(s[0]);
            for (int i = 1; i < count; i++)
                lv.SubItems.Add(s[i]);
        }
        //________________________________
        public string Cell(int row, int col)
        {
            ListViewItem lvi = this.Items[row];
            if (col == 0)
                return lvi.Text;
            else
                return lvi.SubItems[col].Text.ToString();
        }
        //________________________________
        private void ListViewGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.SelectedIndices.Count >0)
                ExSelectedRowChanged(sender, e);
        }
        //________________________________
        public void RemoveSelectedRow()
        {
            
            if (this.SelectedIndices.Count <= 0) return;
            int r = this.SelectedIndices[0];
           this.Items.RemoveAt(r);
        }
        //________________________________
        public string getColNames()
        {
            string colNames=""; 
            
            if (this.Columns.Count<=0)return "";
            for (int i = 0; i < this.Columns.Count; i++)
            {
                colNames += this.Columns[i].Tag +",";
            }
            colNames = colNames.Substring(0, colNames.Length - 1);
            return colNames;
        }
        //________________________________
        public string getRowValues(int row)
        {
            string RowValues="";

            if (this.Columns.Count <= 0) return "";
            RowValues +="'"+ this.Items[row].Text + "',";
            for (int i = 1; i < this.Columns.Count; i++)
            {

                RowValues += "'"+this.Items[row ].SubItems[i].Text +"',";
            }
            RowValues = RowValues.Substring(0, RowValues.Length - 1);
            return RowValues;
        }
        //________________________________
    }
}
