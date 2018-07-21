using IFramework.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Controls
{
    public partial class frmShowTextDialog : Form
    {
        public frmShowTextDialog()
        {
            InitializeComponent();
        }
        bool IsOk = true;
        public  bool ShowTextFile(string file, string buttonMessage, bool FilePassedByContent = false, string message = "")
        {
           
            this.Size = new System.Drawing.Size(1280, 930);
            //f.WindowState = FormWindowState.Maximized;


            txt.Multiline = true;
            //txt.AcceptsReturn = true;
            txt.Font = new Font("Courier New", 14);
            txt.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;

            txt.Location = new Point(10, 10);
            txt.Size = new Size(this.Width - 40, 590);

            Label l = new Label();
            l.Location = new Point(10, 600);
            l.Text = message;
            this.Controls.Add(l);
            this.Text = message;

            StatusBar stb = new StatusBar();
            stb.Text = "dgd " + message;
            Controls.Add(stb);
            //txt.ScrollBars = ScrollBars.Vertical;
            bool IsSuccess;
            if (FilePassedByContent)
                txt.Text = file;
            else
                txt.Text = FileHelper.ReadFile(file, out IsSuccess);

            Controls.Add(txt);

            Button btnSend = new Button();
            btnSend.Click += btnSend_Click;
            btnSend.Text = buttonMessage;
            btnSend.Location = new Point(10, 630);
            Controls.Add(btnSend);

            Button btn_cancel = new Button();

            btn_cancel.Text = "Cancel";
            btn_cancel.Click += btn_cancel_Click;
            btn_cancel.Location = new Point(100, 630);
            Controls.Add(btn_cancel);

            Button btn_selectAll = new Button();
            btn_selectAll.Text = "Select all";
            btn_selectAll.Location = new Point(190, 630);
            btn_selectAll.Click += Btn_selectAll_Click;
            Load += F_Load;
            FormClosing += F_FormClosing;
            ShowDialog();
            //f.Show();
            return IsOk;
        }
        private  void F_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private  void F_Load(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Visible = true;
        }
        private  void Btn_selectAll_Click(object sender, EventArgs e)
        {
            txt.SelectAll();
        }
        private  void btn_cancel_Click(object sender, EventArgs e)
        {
            IsOk = false;
            Close();
        }
        private  void btnSend_Click(object sender, EventArgs e)
        {
            IsOk = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
