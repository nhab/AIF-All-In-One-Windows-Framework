
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace IFramework.Helpers.WindowsControls
{
    public class DataGridViewHelper
    {
        public static void Create(ref DataGridView dataGrid, string[] colNames,string[] colTypeName)
        {
            int nCount = colNames.Count();
            for (int i = 0; i < nCount; i++)
            {
                switch (colTypeName[i])
                {
                    case "TextBox":
                        DataGridViewTextBoxColumn ColumnText = new System.Windows.Forms.DataGridViewTextBoxColumn();
                        ColumnText.HeaderText = colNames[i];
                        ColumnText.Name = "col"+ colNames[i];
                        dataGrid.Columns.Add(ColumnText);
                        break;
                    case "CheckBox":
                        DataGridViewCheckBoxColumn ColumnCheckbox = new DataGridViewCheckBoxColumn();
                        ColumnCheckbox.HeaderText = colNames[i];
                        ColumnCheckbox.Name = "col" + colNames[i];
                        dataGrid.Columns.Add(ColumnCheckbox);
                        break;
                }
                
            }
        }

        public static void Fill(ref DataGridView dataGrid, List<Hashtable> hashList)
        {
            dataGrid.Font = new System.Drawing.Font("tahoma", 11);

            var source = new BindingSource();
            source.DataSource = hashList;
            dataGrid.DataSource = source;
            
            //DataTable dataTable1 = new DataTable();
            //DataTable dt = new DataTable("MyBlahsDataTable");


            //dataTable1.Columns.Add("Breed", typeof(string));
            // table.Columns.Add("Date", typeof(DateTime));

            //table.Rows.Add(57, "Koko", "Shar Pei",
            //    DateTime.Now);


            //for (int i = 0; i < hashList[0].Keys.Count; i++)
            //{
            //    string  column = hashList[0].Keys[i];
            //    DataRow dr = dt.NewRow();

            //    dr["Col1"] = column.ToString();
            //    dt.Rows.Add(dr);
            //}
            //dataGrid.DataSource = dataTable1;
            //dataGrid.Refresh();

            int rowCount = hashList.Count();
            int colCount = hashList[0].Keys.Count;
            //if (progressBar1 != null)
            //{
            //    progressBar1.Maximum = l;
            //    progressBar1.Value = 0;
            //}

            for (int i = 0; i < rowCount; i++)
            {
                //DataGridViewRow gridRow = (DataGridViewRow)dataGrid.Rows[0].Clone();
                //dataTable1.Rows.Add()
                //for (int j = 0; j < colCount; j++)
                //{
            
                //    gridRow.Cells[j].Value = hashList[i][j];
                //}
                //dataGrid.Rows.Add(gridRow);
                
                //if (progressBar1 != null)
                //    progressBar1.Value = i;
            }

           
            //int Id_colindex = 0;
            //if (!ShowFirstCol)
            //    listView1.Columns[Id_colindex].Width = 0;


    }
    }
}
