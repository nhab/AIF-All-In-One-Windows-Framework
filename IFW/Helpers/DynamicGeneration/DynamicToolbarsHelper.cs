using Helpers;
using Helpers.DB;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IFramework.Helpers.WindowsControls
{
    /// toolbars functionality ///////////////////////////////////////
    public class DynamicToolbarsHelper
    {
        #region  variables
        private static ListView listview;
        public  static string tableName;
        public static string orderBy;

        public static int ToolbarHeight=37;
        public static int buttonWeight = 30;
        public static int buttonHeight = 30;
        public static int buttonsDistance = 5;
        public static Color ButtonColor = Color.FromArgb(225, 225, 225);
        public static Color panelColor= System.Drawing.Color.FromArgb(190, 190, 190);
        public static string FILETER_TEXTBOXES_PANEL_NAME = "pnlFilterTextBoxes";
        public static string txtBoxes4FilterPrefix = "txtFilterFld";
        #endregion
        #region Events
        private static void btnfilter_click(object sender, System.EventArgs e)
        {
            FilterListView(ref listview,tableName, orderBy,null);
        }
        private static void btnClear_click(object sender, System.EventArgs e)
        {
            for (int j = 0; j < listview.Columns.Count; j++)
                for (int i = 0; i < listview.Parent.Controls.Count; i++)
                    if (listview.Parent.Controls[i].Name.Length > 12 && listview.Parent.Controls[i].Name.Substring(0, 12) == "txtFilterFld")
                        listview.Parent.Controls[i].Text = "";
            FilterListView(ref listview, tableName, orderBy);
        }
        private static void btn2Excel_click(object sender, System.EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel file;*.xlsx|*.xlsx";
            sfd.ShowDialog();

            int colCount = listview.Columns.Count;
            string[] headers = new string[colCount];

            for (int i = 1; i < colCount; i++)
                headers[i] = listview.Columns[i].Text;
            int rowCout = listview.Items.Count;
            string[][] vals = new string[rowCout][];

            for (int i = 0; i < rowCout; i++)
            {
                vals[i] = new string[colCount];
                for (int j = 1; j < colCount; j++)
                    vals[i][j] = listview.Items[i].SubItems[j].Text;
            }
            OfficeHelper.saveToExcel(sfd.FileName, headers, vals);
        }
        private static void btnCopyRow_click(object sender, System.EventArgs e)
        {
            if (listview.SelectedItems.Count <= 0) return;
            int colCount = listview.Columns.Count;
            string s = "";
            for(int i=0;i<colCount;i++)
                s+=listview.Columns[i].Text+" : "+ listview.SelectedItems[0].SubItems[i].Text+"\r\n";
            Clipboard.SetText(s);
        }
        #endregion
        #region functiions
        public static Panel FindPanelInForm(Form f, string panelName)
        {
            Panel pnl = null;
            foreach (Control ctl in f.Controls)
            {
                if (ctl.Name == panelName)
                {
                    pnl = (Panel)ctl;
                }
            }
            if (pnl == null)
            {
                pnl = new Panel();
                pnl.Name = panelName;
            }
            return pnl;
        }
        private static void AddSearchTextBoxesPanel(ref ListView lv)
        {
            int left = lv.Left;
            Panel pnl = FindPanelInForm((Form)lv.Parent, FILETER_TEXTBOXES_PANEL_NAME);
            pnl.Name = FILETER_TEXTBOXES_PANEL_NAME;
            pnl.Top = lv.Top - 20;
            pnl.Left = left;
            pnl.Height = new TextBox().Height;
            pnl.Width = lv.Width;
            pnl.BackColor = Color.Aqua;

            left = 0;
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                TextBox tb1 = new TextBox();
                tb1.Top = 0;// lv.Top - 20;
                tb1.Left = left;
                left += lv.Columns[i].Width;
                tb1.Width = lv.Columns[i].Width;
                tb1.Name = txtBoxes4FilterPrefix + StringHelper.RemoveSpaces((lv.Columns[i]).Text);
                pnl.Controls.Add(tb1);
            }
            lv.Parent.Controls.Add(pnl);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns>values of each textbox </returns>
        private static string[] RemoveSearchTextBoxes(ref ListView list)
        {
            int count = list.Columns.Count;
            string[] controlName = new string[count];
            string[] controlValue = new string[count];
            
            int nCount = list.Parent.Controls.Count;
            for (int i = 0; i < nCount; i++)
                if (list.Parent.Controls[i].Name == FILETER_TEXTBOXES_PANEL_NAME)
                {
                    Panel pnl = (Panel)list.Parent.Controls[i];
                    nCount = pnl.Controls.Count;
                    for(int j=0;j<nCount;j++)
                    {
                        Control ctl = pnl.Controls[j];
                        controlName[j] = ctl.Name;
                        controlValue[j] = ctl.Text;
                        j++;

                    };
                    pnl.Controls.Clear();

                    return controlValue;
                }

            return controlValue;
        }
        private static void AddValues(ref ListView list, string[] vals)
        {
            int nCount = list.Parent.Controls.Count;
            for (int i = 0; i < nCount; i++)
                if (list.Parent.Controls[i].Name == FILETER_TEXTBOXES_PANEL_NAME)
                {
                    Panel pnl = (Panel)list.Parent.Controls[i];
                    int j = 0;
                    foreach (Control ctl in pnl.Controls)
                    {
                        list.Parent.Controls[i].Text = vals[j++];
                    };
                    return;
                }
        }
        public static void RefreshFilterTextBoxesPanel(ref ListView lv)//, string[] cols)
        {
            string[] vals = DynamicToolbarsHelper.RemoveSearchTextBoxes(ref lv);
            DynamicToolbarsHelper.AddSearchTextBoxesPanel(ref lv);
            DynamicToolbarsHelper.AddValues(ref lv, vals);
        }
        public static void RefreshButtonsPanel(ref ListView lv )
        {
            int parentWidth = lv.Parent.Width;
            int top         = lv.Top - DynamicFormHelper.marginVert;
            Panel pnl1=null;
            //Clear panel controls
            //{
            foreach (Control ctl in lv.Parent.Controls)
            {
                if (ctl.Name == "pnlButtonsOfFilter")
                {
                    (ctl as Panel).Controls.Clear();
                    pnl1 = (Panel)ctl;
                }
            }
            if( pnl1 == null )
                pnl1 = new Panel();
            //}
            pnl1.Left = DynamicFormHelper.marginHoriz;
            pnl1.Width = parentWidth - 2 * DynamicFormHelper.marginHoriz - 20;
            pnl1.Height = ToolbarHeight;
            pnl1.Top = top;
            pnl1.Name = "pnlButtonsOfFilter";
            pnl1.BackColor = panelColor;
            pnl1.BorderStyle = BorderStyle.FixedSingle;
            top = 10;

            ToolTip toolTip1 = new System.Windows.Forms.ToolTip();
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(24, 24);
            // Filter button :
            Button btnFilter = new Button();

            btnFilter.Name = "btnFilter";
            btnFilter.Click += btnfilter_click;
            toolTip1.SetToolTip(btnFilter, "Filter");
            imgList.Images.Add("filter", IFramework.Properties.Resources.filter);
            btnFilter.ImageIndex = 0;
            pnl1.Controls.Add(btnFilter);

            // Clear button :
            Button btnClear = new Button();
            btnClear.Name = "btnClear";
            btnClear.Click += btnClear_click;
            toolTip1.SetToolTip(btnClear, "Clear Filter");
            imgList.Images.Add("Clear", IFramework.Properties.Resources.Clear);
            btnClear.ImageIndex = 1;
            pnl1.Controls.Add(btnClear);

            // Export to Excell :
            Button btn2Excel = new Button();
            btn2Excel.Click += btn2Excel_click;
            btn2Excel.Name = "btnExcel";
            toolTip1.SetToolTip(btn2Excel, "Export to excell");
            imgList.Images.Add("Clear", IFramework.Properties.Resources.toexcel);
            btn2Excel.ImageIndex = 2;
            pnl1.Controls.Add(btn2Excel);

            // Copy Row :
            Button btnCopyRow = new Button();
            btnCopyRow.Click += btnCopyRow_click;
            btnCopyRow.Name = "btnCopyRow";
            toolTip1.SetToolTip(btnCopyRow, "Copy Row to Clipboard");
            imgList.Images.Add("CopyRow", IFramework.Properties.Resources.Copy);
            btnCopyRow.ImageIndex = 3;
            pnl1.Controls.Add(btnCopyRow);

            foreach (Control ctl in pnl1.Controls)
            {
                (ctl as Button).Top = 3;
                (ctl as Button).TextImageRelation = TextImageRelation.Overlay;
                (ctl as Button).ImageList = imgList;//IFramework.Properties.Resources.filt;
                (ctl as Button).FlatStyle = FlatStyle.Flat;
                (ctl as Button).BackColor = ButtonColor;
                (ctl as Button).Width = buttonWeight;
                (ctl as Button).Height = buttonHeight;
                (ctl as Button).ImageAlign = ContentAlignment.MiddleCenter;
            }

            btnFilter.Left = 10;
            btnClear.Left = btnFilter.Left + btnFilter.Width + buttonsDistance;
            btn2Excel.Left = btnClear.Left + btnClear.Width + buttonsDistance;
            btnCopyRow.Left = btn2Excel.Left + btn2Excel.Width + buttonsDistance;
            lv.Parent.Controls.Add(pnl1);
        }
        public static void RefreshToolBars(ref ListView lv,string tablename )
        {
            DynamicToolbarsHelper.tableName = tablename;// sets global table name variable needed in filter function and other toolbar functions
          
            listview = lv;

            RefreshButtonsPanel   (ref lv);            
            RefreshFilterTextBoxesPanel(ref lv);
        }

        private static List<Hashtable> FilterByTable(ref ListView list, out string[] cols,
            string tableName, string orderby)
        {
            int l = list.Columns.Count;
            string[] fldNames = new string[l];
            string[] vals = new string[l];
            for (int i = 0; i < l; i++)
                fldNames[i] = list.Columns[i].Text;
            Panel pnl = FindPanelInForm((Form)list.Parent, FILETER_TEXTBOXES_PANEL_NAME);
            foreach (Control ctl in pnl.Controls)
            {
                if (ctl.Name.Length > 12)
                    if (ctl.Name.Substring(0, 12) == "txtFilterFld")
                    {
                        for (int j = 0; j < list.Columns.Count; j++)
                        {
                            if (list.Columns[j].Text == ctl.Name.Substring(12))
                            {
                                vals[j] = ((TextBox)ctl).Text;
                                break;
                            };
                        }
                    }
            }
            string q = QueryBuildHelper.BuildSelect_LikeValues(tableName, fldNames, vals, orderby);

            List<Hashtable> filteredList = DBHelper.RunSelectQuery(q, out cols);
            return filteredList;
        }
        private static List<Hashtable> FilterByQuery(ref ListView list, string[] cols, string query, string orderby)
        {
            int l = list.Columns.Count;
            string[] vals = new string[l];
            foreach (Control ctl in list.Parent.Controls)
            {
                if (ctl.Name.Length > 12)
                    if (ctl.Name.Substring(0, 12) == "txtFilterFld")
                        for (int j = 0; j < list.Columns.Count; j++)
                            if (list.Columns[j].Text == ctl.Name.Substring(12))
                            {
                                vals[j] = ((TextBox)ctl).Text;
                                break;
                            };
            }
            // string q = QueryBuildHelper.BuidQuery(query, cols, vals, orderby );
            List<Hashtable> filteredList = DBHelper.RunSelectQuery(query, out cols);
            return filteredList;
        }
        public static void FilterListView(ref ListView lv, string tableNameOrQuery,
            string orderby,ProgressBar progressbar1=null, string[] fields = null, bool IsByQuery = false)
        {
            string[] cols;
            
            List<Hashtable> filteredList;
            if (IsByQuery)
            {
                cols = new string[fields.Count()];
                for (int i = 0; i < fields.Count(); i++)
                    cols[i] = fields[i];
                filteredList = FilterByQuery(ref lv, fields, tableNameOrQuery, orderby);
            }
            else
                filteredList = FilterByTable(ref lv, out cols, tableNameOrQuery, orderby);

            ListViewHelper.Fill(ref lv, filteredList, cols, progressbar1,false);
            Form form1 = (Form)lv.Parent;
            DynamicFormHelper.RefreshStatistics(ref form1, "0", filteredList.Count.ToString());

            // DynamicToolbarsHelper.RefreshFilterTextBoxesPanel(ref lv);
        }
        #endregion
    }
}
