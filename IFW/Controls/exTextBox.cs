using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GeneralLib.Controls
{
    public partial class exTextBox : UserControl
    {
        private bool m_r2l=true ;
      
        public exTextBox()
        {
            InitializeComponent();
            m_r2l = true;
           
        }
        public bool R2l
        {
            get 
            {
                return m_r2l;
            }
            set 
            {
                if (m_r2l)
                {
                    label1.Left = 0;
                    textBox1.Left = label1.Width + 5;
                    label1.Anchor = AnchorStyles.Left;
                }
                else
                {
                    textBox1.Left = 0;
                    label1.Left = textBox1.Width + 5;
                    label1.Anchor = AnchorStyles.Right;
                }
                m_r2l = value;
            }
        }
        public string Label
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public new string Text
        {
            get { return textBox1.Text; }
            set { textBox1.Text=value ; }        
        }
    }
}
