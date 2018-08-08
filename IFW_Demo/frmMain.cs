using Demo;
using Helpers;
using IFramework.Controls;
using SourceGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinControl;
using WinControls;
using WindowsControls;

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
            int top = FormHelper.AddHeader(ref f, "IFW Demo")+80;

            DateTimeRangePickerJ dtPicker = new DateTimeRangePickerJ();
            dtPicker.Top = top + 10;
            dtPicker.HideJaliEquevalents();
            f.Controls.Add(dtPicker);
            dtPicker.Set(DateTime.Now.AddDays(-5), DateTime.Now);

            grdMaster = new Grid();
            f.Controls.Add(grdMaster);
            Point loc = new System.Drawing.Point(10, top + dtPicker.Height + 10);
            Size siz = new Size(f.Width - 30, 200);
            grdMaster = SourceGridHelper.Create(ref f, loc, siz);

            RefreshGridMaster(ref grdMaster);

            grdDetail = new Grid();
            f.Controls.Add(grdDetail);
            Point loc2 = new System.Drawing.Point(10, grdMaster.Top + grdMaster.Height + 10);
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
                RefreshGridDetail(ref grdDetail, loc);

            }
        }

        private void btnHoverButton_Click(object sender, EventArgs e)
        {
            HoverButton btn = new WinControl.HoverButton();
            btn.Text = "Hover button";
            panel1.Controls.Add(btn);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
        }

        private void btnColorPicker_Click(object sender, EventArgs e)
        {
            frmColorPicker f = new frmColorPicker();
            f.ShowDialog();
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            ctlClock cloc = new WinControls.ctlClock();
            panel1.Controls.Add(cloc);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmTestEGrid f = new frmTestEGrid();
            f.Show();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmGridView f = new frmGridView();
            f.ShowDialog();
        }

   

        private void btnInputBox_Click(object sender, EventArgs e)
        {
            string s1 = InputBox.ShowInputBox("Please enter some text.", "Need user input");
            TextBox t = new TextBox();
            panel1.Controls.Add(t);
            t.Text = s1;
        }

  

        private void btnIOLib_Click(object sender, EventArgs e)
        {
 frmIO_LIB f = new Demo.frmIO_LIB();
            f.ShowDialog();
        }
        #endregion
        #region Functions
        public static void RefreshGridMaster(ref Grid grdMaster)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] cols = { "IsOk", "Name", "Description" };
            List<Hashtable> lst;
            lst = new List<Hashtable>();
            string[] colTypeName = { "CheckBox", "string", "string" };
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
             Color.DarkBlue, Color.LightBlue, Color.White);

            Cursor.Current = Cursors.Default;
        }

        public static void RefreshGridDetail(ref Grid grdDetail, string loc)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] cols = { "Item", "Value" };
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

