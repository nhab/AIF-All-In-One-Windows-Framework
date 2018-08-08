
using IFramework.Controller;
using IFramework.Helpers.WindowsControls;
using IFramework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Helpers
{
    public class ListViewHelper
    {
       
        public static Color HeaderColor=Color.FromArgb(196, 222, 255);

        [DebuggerStepThrough]
        public static void listview1_DrawListViewColHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.Alignment = StringAlignment.Center;

                using (var headerFont = new Font("Tahoma", 10, FontStyle.Bold))
                {
                    e.Graphics.FillRectangle(new SolidBrush(HeaderColor), e.Bounds);
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
        }
        private static void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            const int TEXT_OFFSET = 1;    // I don't know why the text is located at 1px to the right. Maybe it's only for me.

            ListView listView = (ListView)sender;

            // Check if e.Item is selected and the ListView has a focus.
            if (!listView.Focused && e.Item.Selected)
            {
                Rectangle rowBounds = e.SubItem.Bounds;
                Rectangle labelBounds = e.Item.GetBounds(ItemBoundsPortion.Label);
                int leftMargin = labelBounds.Left - TEXT_OFFSET;
                Rectangle bounds = new Rectangle(rowBounds.Left + leftMargin, rowBounds.Top, e.ColumnIndex == 0 ? labelBounds.Width : (rowBounds.Width - leftMargin - TEXT_OFFSET), rowBounds.Height);
                TextFormatFlags align;
                switch (listView.Columns[e.ColumnIndex].TextAlign)
                {
                    case HorizontalAlignment.Right:
                        align = TextFormatFlags.Right;
                        break;
                    case HorizontalAlignment.Center:
                        align = TextFormatFlags.HorizontalCenter;
                        break;
                    default:
                        align = TextFormatFlags.Left;
                        break;
                }
                TextRenderer.DrawText(e.Graphics, e.SubItem.Text, listView.Font, bounds, SystemColors.HighlightText,
                    align | TextFormatFlags.SingleLine | TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.VerticalCenter | TextFormatFlags.WordEllipsis);
            }
            else
                e.DrawDefault = true;
        }
        [DebuggerStepThrough]
        private static void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            ListView listView = (ListView)sender;

            // Check if e.Item is selected and the ListView has a focus.
            if (!listView.Focused && e.Item.Selected)
            {
                Rectangle rowBounds = e.Bounds;
                int leftMargin = e.Item.GetBounds(ItemBoundsPortion.Label).Left;
                Rectangle bounds = new Rectangle(leftMargin, rowBounds.Top, rowBounds.Width - leftMargin, rowBounds.Height);
                e.Graphics.FillRectangle(SystemBrushes.Highlight, bounds);
            }
            else
                e.DrawDefault = true;
        }
        public static void HideColumn(ref ListView listView1, int colIndex)
        {
            if(colIndex>=0)
                listView1.Columns[colIndex].Width = 0;
        }
        public static ListView Fill(ref ListView listView1, List<Hashtable> rows,
            string[] cols,ProgressBar progressBar1, bool ShowFirstCol,bool DoesRowsHasKey=false )
        {
            listView1.BeginUpdate();

            listView1.View = System.Windows.Forms.View.Details;
            listView1.GridLines = true;

            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Font = new System.Drawing.Font("tahoma", 11);
            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listview1_DrawListViewColHeader);
            listView1.DrawItem += new DrawListViewItemEventHandler(listView1_DrawItem);
            listView1.DrawSubItem += new DrawListViewSubItemEventHandler(listView1_DrawSubItem);
            if(progressBar1!=null)
                progressBar1.Show();

            Listview_AddColumns(ref listView1, cols);
            
            int l = rows.Count();
            if (progressBar1 != null)
            {
                progressBar1.Maximum = l;
                progressBar1.Value = 0;
            }
            for (int i = 0; i < l; i++)
            {
                if (DoesRowsHasKey)
                {
                  
                    ListView_AddRow(ref listView1, rows[i], cols);
                }
                
                else
                    ListView_AddRow(ref listView1, rows[i], null);
                if (progressBar1 != null)
                    progressBar1.Value=i;
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int Id_colindex = 0;// ListViewHelper.GetColIndex(listView1, FirstColName);
            if (!ShowFirstCol)
                listView1.Columns[Id_colindex].Width = 0;

            listView1.EndUpdate();
            if (progressBar1 != null)
                progressBar1.Hide();
            return listView1;
        }

        public static ListView Fill_With_CheckboxCols(ref ListView listView1, List<Hashtable> rows,
          string[] cols, ProgressBar progressBar1, bool ShowFirstCol,string[] checkBoxCols)//,bool ShowFirstCol=true
        {

            listView1.BeginUpdate();

            listView1.View = System.Windows.Forms.View.Details;
            listView1.GridLines = true;

            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Font = new System.Drawing.Font("tahoma", 11);
            listView1.OwnerDraw = true;
            listView1.DrawColumnHeader += new DrawListViewColumnHeaderEventHandler(listview1_DrawListViewColHeader);
            listView1.DrawItem += new DrawListViewItemEventHandler(listView1_DrawItem);
            listView1.DrawSubItem += new DrawListViewSubItemEventHandler(listView1_DrawSubItem);

            Listview_AddColumns(ref listView1, cols);

            int l = rows.Count();
            if (progressBar1 != null)
            {
                progressBar1.Maximum = l;
                progressBar1.Value = 0;
            }
            for (int i = 0; i < l; i++)
            {
                ListView_AddRow(ref listView1, rows[i]);
                if (progressBar1 != null)
                    progressBar1.Value = i;
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            int Id_colindex = 0;// ListViewHelper.GetColIndex(listView1, FirstColName);
            if (!ShowFirstCol)
                listView1.Columns[Id_colindex].Width = 0;

            listView1.EndUpdate();
            return listView1;
        }
        public static void Listview_AddColumns(ref ListView listView1, string[] ColNames)
        {
            ColumnHeader h;
            for (int i = 0; i < ColNames.GetLength(0); i++)
            {
                h = new ColumnHeader();
                h.Name = ColNames[i];
                h.Text = ColNames[i];
                h.TextAlign=HorizontalAlignment.Center;
                listView1.Columns.Add(h);
            }
              
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public static void ListView_AddRow(ref ListView listView1, Hashtable items,string[] cols=null)
        {

            ListViewItem lvi;
            if (cols != null)
                lvi = new ListViewItem(items[cols[0]].ToString());
            else
                lvi = new ListViewItem(items[0].ToString());
            DateTime dt = new DateTime();
            int cnt= items.Keys.Count;
            for (int i = 1; i <cnt ; i++)
            {
                string sItem;
                if (cols != null)
                    sItem = items[cols[i]].ToString();
                else
                    sItem = items[i].ToString();

                if (!DateTime.TryParse(sItem, out dt))
                {
                    lvi.SubItems.Add(sItem);
                }
                else
                {

                    ListViewItem.ListViewSubItem lvsi;

                    string s;
                    if(listView1.Columns[i].Name== "GetOFTime")
                         s =PersianHelper.ConvertToJalaliDateTime(dt);
                    else
                        s=string.Format("{0:yyyy/MM/dd,hh:mm:ss}", dt);
                    if (s.Substring(s.Length - 8) == "12:00:00")
                        lvsi=lvi.SubItems.Add(s.Substring(0, s.Length - 9));
                    else
                       lvsi= lvi.SubItems.Add(s);
                   
                }

            }
                listView1.Items.Add(lvi);
        }
        public static void ListView_AddRow(ref ListView listView1, string[] items)
        {
            ListViewItem lvi = new ListViewItem(items[0]);


            lvi.SubItems.Add(items[1]);
            listView1.Items.Add(lvi);
        }
        public static void ListView_RefreshFromDB(ref ListView listView1)
        {
            List<User> users = UserController.GetAllUsers();
            listView1.Items.Clear();
            for (int i = 0; i < users.Count; i++)
            {
                ListViewItem lvi = new ListViewItem(users[i].UserName);

                lvi.SubItems.Add(users[i].RoleName.ToString());
                listView1.Items.Add(lvi);
            }
        }
        public static void RefreshListView(ref ListView lv, List<Hashtable> tbl)
        {
            lv.Items.Clear();
            for (int k = 0; k < tbl.Count; k++)
            {

                Hashtable row = (Hashtable)tbl[k];
                string[] str = new string[row.Count];

                for (int l = 0; l < row.Count; l++)
                    str[l] = row[l].ToString();

                var listViewItem = new ListViewItem(str);
                lv.Items.Add(listViewItem);
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        public static void RefreshListView(ref ListView lv, string[] rows)
        {
            lv.Items.Clear();
            for (int k = 0; k < rows.GetLength(0); k++)
                lv.Items.Add(rows[k]);
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public static string[] GetCols(ListView listview1)
        {
            string[] ret = new string[listview1.Columns.Count];
            for (int i = 0; i < listview1.Columns.Count; i++)
                ret[i] = listview1.Columns[i].Text;
            return ret;
        }
        public static string[][] GetValues(ListView listview1)
        {
            int rowCount, colCount;
            rowCount = listview1.Items.Count;
            colCount = listview1.Columns.Count;
            string[][] ret = new string[rowCount][];
            for (int r = 0; r < rowCount; r++)
            {
                ret[r] = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    ret[r][i] = listview1.Items[r].SubItems[i].Text;
                }
            }
            return ret;
        }
        public static void ListItemSorter(ref ListView list, int colIndex)
        {
            int total = list.Items.Count;
            list.BeginUpdate();
            ListViewItem[] items = new ListViewItem[total];
            for (int i = 0; i < total; i++)
            {
                int count = list.Items.Count;
                int minIdx = 0;
                for (int j = 1; j < count; j++)
                    if (list.Items[j].SubItems[colIndex].Text.CompareTo(list.Items[minIdx].SubItems[colIndex].Text) < 0)
                        minIdx = j;
                items[i] = list.Items[minIdx];
                list.Items.RemoveAt(minIdx);
            }
            list.Items.AddRange(items);
            list.EndUpdate();
        }
        public static int GetColIndex(ListView lv, string colName)
        {
            int l = lv.Columns.Count;
            for (int i = 0; i < l; i++)
            {
                if (lv.Columns[i].Text.Trim().ToLower() == colName.Trim().ToLower())
                    return i;
            }
            return -1;
        }
      
   
    }
}
