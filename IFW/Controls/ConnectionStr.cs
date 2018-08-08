using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace GeneralLib.Controls
{
    public partial class ConnectionStr : TextBox 
    {
        string m_connectionString;
        public ConnectionStr()
        {
            InitializeComponent();
            this.Visible = false;
            this.Multiline = true;
        }
        //_____________________________________________

        public ConnectionStr(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public string ConnectionString
        { 
           get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString=value;
            }
        }
    }
}
