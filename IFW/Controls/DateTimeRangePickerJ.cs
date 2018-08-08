using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IFramework.Helpers;
using Helpers;

namespace IFramework.Controls
{
    public partial class DateTimeRangePickerJ : UserControl
    {
        public static System.Windows.Forms.DateTimePicker dtpTo;
        public static System.Windows.Forms.DateTimePicker dtpFrom;
        void InitDateTimePickers()
        {            
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            dtpTo = new System.Windows.Forms.DateTimePicker();
            // 
            // dtpFrom
            // 
            dtpFrom.CustomFormat = "yyyy-MM-dd";
            dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpFrom.Location = new System.Drawing.Point(95, 9);
            dtpFrom.Size = new System.Drawing.Size(110, 26);
            dtpFrom.Name = "dtpFrom";
            // 
            // dtpTo
            // 
            dtpTo.CustomFormat = "yyyy-MM-dd";
            dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            dtpTo.Location = new System.Drawing.Point(lblToDate.Left+lblToDate.Width, 9);
            dtpTo.Size = new System.Drawing.Size(110, 26);
            dtpTo.Name = "dtpTo";  
            dtpTo.TabIndex = 27;
            dtpTo.Value = new System.DateTime(2017, 10, 14, 0, 0, 0, 0);
            dtpTo.ValueChanged += new System.EventHandler(dtpTo_ValueChanged);

            dtpFrom.TabIndex = 27;
            dtpFrom.Value = new System.DateTime(2017, 10, 14, 0, 0, 0, 0);
            dtpFrom.ValueChanged += new System.EventHandler(dtpFrom_ValueChanged);
            Controls.Add(dtpFrom);
            Controls.Add(dtpTo);
        }
        public DateTimeRangePickerJ()
        {
            InitializeComponent();
            InitDateTimePickers();
        }
        public void SyncJalaliToGeorgian()
        {
            if (dtpFrom != null)
                txtFromJalali.Text = PersianHelper.ConvertToJalaliDate(dtpFrom.Value);
            if (dtpTo != null)
                txtToJalali.Text = PersianHelper.ConvertToJalaliDate(dtpTo.Value);
        }
        public DateTimeRangePickerJ(DateTime from,DateTime to)
        {
            if (dtpFrom != null)
                dtpFrom.Value = from;
          
            if (dtpTo != null)
                dtpTo.Value = to;
            
            SyncJalaliToGeorgian();
        }
        public void Set(DateTime from, DateTime to)
        {
            if (dtpFrom != null)
                dtpFrom.Value = from;

            if (dtpTo != null)
                dtpTo.Value = to;

            SyncJalaliToGeorgian();
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            txtFromJalali.Text = PersianHelper.ConvertToJalaliDate((sender as DateTimePicker).Value);
        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            txtToJalali.Text = PersianHelper.ConvertToJalaliDate((sender as DateTimePicker).Value);

        }
        public void HideJaliEquevalents()
        {
            txtFromJalali.Visible = false;
            txtToJalali.Visible = false;
        }
        public void ShowJaliEquevalents()
        {
            txtFromJalali.Visible = true;
            txtToJalali.Visible = true;
        }
        public string GetFromDateJ()
        {
      
            return txtFromJalali.Text;
        }
        public string GetToDateJ()
        {
            return txtToJalali.Text;
        }
        public string GetFromDateGeorgian()
        {

            return dtpFrom.Value.ToString();
        }
        public string GetToDateGeorgian()
        {
            
            return dtpTo.Value.ToString();
        }
        public DateTime GetFromDateGeorgianDate()
        {

            return dtpFrom.Value;
        }
        public DateTime GetToDateGeorgianDate()
        {
            return dtpTo.Value;
        }
        public long GetLongDateFrom()
        {
            return DateTimeHelper.GetLongDate(dtpFrom.Value);
        }
        public long  GetLongDateTO()
        {
            return  DateTimeHelper.GetLongDate(dtpTo.Value);
        }

    }
}
