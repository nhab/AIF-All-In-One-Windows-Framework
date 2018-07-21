using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IFramework.Helpers.WindowsControls
{
    public class DynamicFormHelper
    {
        #region Variables
        public static int marginHoriz = 10;
        public static int marginVert = 58;

        public static int listview_top = 200;
        public static int listview_height = 350;
        public static TextBox txtFromDate;
        public static string STATISTICS_PANEL_NAME = "pnlStatistics_";

        #endregion
        #region Events
        private static void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            txtFromDate.Text = PersianHelper.ConvertToJalaliDate((sender as DateTimePicker).Value);
        }
        #endregion
        #region Functions
        public static ListView Create_Listview(ref Form form,string listviewName,Point location)
        {
            form.WindowState = FormWindowState.Maximized;
            form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            //form.MinimumSize = form.Size;
            //form.MaximumSize = form.Size;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            ListView lv;
            lv = new ListView();

            lv.Name = listviewName;
            lv.Location =location;
            lv.GridLines = true;
            lv.FullRowSelect = true;
            lv.Height = listview_height;// form.Height - 240;
            //lv.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            lv.Width = form.Width - 40;
            lv.View = View.Details;
            lv.ShowItemToolTips = true;
            form.Controls.Add(lv);
            return lv;
        }
        public static ListView ShowList(
           ref Form form1,string listviewName, List<Hashtable> of_list, string[] cols,
           string fromDate, string toDate, string newCount, string tableName,
           string orderby,ProgressBar progressBar1)
        {

            Cursor.Current = Cursors.WaitCursor;
            DynamicToolbarsHelper.orderBy = orderby;

            RefreshStatistics(ref form1,newCount, of_list.Count.ToString());

            ListView listView1=null;
            int nLen = form1.Controls.Count;
            int listviewIndex=-1;
            for (int i = 0; i < nLen; i++)
                if (form1.Controls[i].Name == listviewName)
                {
                    listviewIndex = i;
                }
            if (listviewIndex >= 0)
                form1.Controls.RemoveAt(listviewIndex);
            Point location =new Point(10, listview_top);
            listView1 = DynamicFormHelper.Create_Listview(ref form1, listviewName,location);

            ListViewHelper.Fill(ref listView1, of_list, cols, progressBar1, false);

            // sets global orderBy variable
            DynamicToolbarsHelper.RefreshToolBars(ref listView1, tableName);
           // listView1.Focus();
            Cursor.Current = Cursors.Default;
            return listView1;
        }
        public static DateTimePicker AddDateTimePicker(ref Form form,string text, Point location,bool IsFromDate)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Location = location;
            lbl.AutoSize = true;
            form.Controls.Add(lbl);

            DateTimePicker dtp = new DateTimePicker();
            dtp.Left = lbl.Left + lbl.Width;
            dtp.Top = location.Y;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat= "yyyy - MM - dd";
            dtp.Width = 130;
            
            dtp.ValueChanged+= dtFromDate_ValueChanged;
            form.Controls.Add(dtp);

            TextBox txtJalali = new TextBox();
            txtJalali.ReadOnly = true;
            txtJalali.Top = dtp.Top + dtp.Height;
            txtJalali.Left = lbl.Left;

            form.Controls.Add(txtJalali);
            if (IsFromDate)
                txtFromDate = txtJalali;
            return dtp;
        }
        public static void RefreshStatistics(ref Form form1,string NewCount, string AllCount)
        {
            Panel pnl = DynamicToolbarsHelper.FindPanelInForm( form1,
                DynamicFormHelper.STATISTICS_PANEL_NAME);
            
            pnl.Width = form1.Width;
            pnl.Size = new Size(form1.Width,25);
            int o = form1.Height - 30;
            pnl.Location = new Point(marginHoriz , 550);//);
            pnl.BackColor = Color.AliceBlue;
            pnl.Controls.Clear();

            Label lbl1 = new Label();
            lbl1.Text= "New OFs Count:"+NewCount+ "  All OFs Count: "+AllCount;
            lbl1.Left = 0;
            lbl1.Width = pnl.Width;
            lbl1.Height = 20;
            pnl.Controls.Add(lbl1);
            form1.Controls.Add(pnl);
        }
        #endregion
    }
}
