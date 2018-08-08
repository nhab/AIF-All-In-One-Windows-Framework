using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinControls
{
    public partial class frmTestEGrid : Form
    {
        public frmTestEGrid()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            editableGrid1.Dim(5, 5);
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Text =editableGrid1.ReturnPath();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editableGrid1.AppendCurrentCell("$sql" );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editableGrid1.Dim(2, 2);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            editableGrid1.Clear();
        }
    }
}