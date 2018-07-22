using IFramework.Controls;
using IFramework.Helpers;
using IFramework.Helpers.WindowsControls;
using SourceGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFW_Demo
{
    public partial class frmMain : Form
    {
        #region Variables
        Grid grdMaster, grdDetail;
        #endregion
        #region Events
        public frmMain()
        {
            InitializeComponent();
            Form f = this;
            FormHelper.MaximizeForm(ref f);
            int top=FormHelper.AddHeader(ref f, "IFW Demo");

            DateTimeRangePickerJ dtPicker = new DateTimeRangePickerJ();
            dtPicker.Top = top + 10;
            dtPicker.HideJaliEquevalents();
            f.Controls.Add(dtPicker);
            dtPicker.Set(DateTime.Now.AddDays(-5), DateTime.Now);

            grdMaster = new Grid();
            f.Controls.Add(grdMaster);
            Point loc = new System.Drawing.Point(10, top+dtPicker.Height+10);
            Size  siz = new Size(f.Width - 30, 200);
            grdMaster = SourceGridHelper.Create(ref f, loc, siz);

            RefreshGridMaster(ref grdMaster);

            grdDetail = new Grid();
            f.Controls.Add(grdDetail);
            Point loc2 = new System.Drawing.Point(10, grdMaster.Top+grdMaster.Height + 10);
            Size siz2 = new Size(f.Width - 30, 200);
            grdDetail = SourceGridHelper.Create(ref f, loc2, siz2);

            grdMaster.Click += grdMaster_Click;
            grdMaster.PreviewKeyDown += GrdMaster_PreviewKeyDown;
           
        }

        private void GrdMaster_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void grdMaster_Click(object sender, EventArgs e)
        {
            int col = SourceGridHelper.GetColIndex(grdMaster, "Name");
            string loc = "";
            if (grdMaster[SourceGridHelper.getSelectedRow(grdMaster), col].Value != null)
            {
                loc = grdMaster[SourceGridHelper.getSelectedRow(grdMaster), col].Value.ToString();
                RefreshGridDetail(ref grdDetail ,loc );

            }
        }
        #endregion
        #region Functions
        public static void RefreshGridMaster(ref Grid grdMaster)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] cols = { "IsOk", "Name", "Description" };
            List<Hashtable> lst;
            lst = new List<Hashtable>();
            string[] colTypeName = { "CheckBox", "string","string" };
            Hashtable itm1 = new Hashtable();
            itm1.Add("IsOk", "True");
            itm1.Add("Name", "Fred");
            itm1.Add("Description", "Is the clerk behind the wall");

            lst.Add(itm1);

            Hashtable itm2 = new Hashtable();
            itm2.Add("IsOk", "False");
            itm2.Add("Name", "Alen");
            itm2.Add("Description", "Is the guy behind the vitrin");

            lst.Add(itm2);

            SourceGridHelper.Populate(ref grdMaster, cols, colTypeName, lst,
             Color.DarkBlue,Color.LightBlue, Color.White );

            Cursor.Current = Cursors.Default;
          }

        public static void RefreshGridDetail(ref Grid grdDetail ,string loc)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] cols = { "Item",  "Value" };
            List<Hashtable> lst;
            lst = new List<Hashtable>();
            string[] colTypeName = { "string", "string" };
            if (loc == "Fred")
            {
                Hashtable itm1 = new Hashtable();
                itm1.Add("Item", "Apple");
                itm1.Add("Value", "21");
                lst.Add(itm1);

                Hashtable itm2 = new Hashtable();
                itm2.Add("Item", "Orange");
                itm2.Add("Value", "44");
                lst.Add(itm2);

                Hashtable itm3 = new Hashtable();
                itm3.Add("Item", "Grape");
                itm3.Add("Value", "44");
                lst.Add(itm3);
            }
            else
            {
                Hashtable itm2 = new Hashtable();
                itm2.Add("Item", "Melon");
                itm2.Add("Value", "54");
                lst.Add(itm2);

                Hashtable itm3 = new Hashtable();
                itm3.Add("Item", "Peach");
                itm3.Add("Value", "11");
                lst.Add(itm3);

            }
            SourceGridHelper.Populate(ref grdDetail, cols, colTypeName, lst,
             Color.DarkBlue, Color.LightBlue, Color.White);

            Cursor.Current = Cursors.Default;
        }

        #endregion
    }
}
