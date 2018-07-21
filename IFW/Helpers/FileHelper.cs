using IFramework.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Helpers
{
    public class FileHelper
    {
        public static bool IsOk=false;
       
        public static void SaveDlgToFile(string filename, string s)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel csv Files |*.csv";
            saveFileDialog1.FileName = filename;
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                FileHelper.WriteStrToFile(saveFileDialog1.FileName,s);
            }

        }
        public static void WriteStrToFile(string filename,string s)
        {
            using (StreamWriter outputFile = new StreamWriter(filename, false))
            {
                outputFile.Write(s);
                outputFile.Close();
            }

        }
        public static string ReadFile(string filename,out bool IsSuccess)
        {
            IsSuccess = true;
            try
            {
                string[] sa = File.ReadAllLines(filename);
                string s = "";
                for (int i = 0; i < sa.Length; i++)
                    s += sa[i]+"\r\n";
                return s;
            } catch (Exception ex)
            {
                string s = ex.Message;
                IsSuccess = false;
                return "";
            }
        }
        public static void Deletefile(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }
        public static RichTextBox txt = new RichTextBox();
        public static bool ShowTextFile(string file, string buttonMessage,bool FilePassedByContent=false,string message="")
        {
            frmShowTextDialog f = new frmShowTextDialog();
            f.txt.Text = file;
            f.btnOK.Text = buttonMessage;
            f.lblMessages.Text = message;
            f.ShowDialog();
           // f = new Form();
           // f.Size = new System.Drawing.Size(1280,  930);


            // txt.Multiline = true;

            // txt.Font = new Font("Courier New", 14);
            // txt.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top;

            // txt.Location = new Point(10, 10);
            // txt.Size = new Size(f.Width - 40, 590);

            // Label l = new Label();
            // l.Location = new Point(10, 600);
            // l.Text = message;
            // f.Controls.Add(l);
            // f.Text = message;

            // StatusBar stb = new StatusBar();
            // stb.Text = "dgd " + message;
            // f.Controls.Add(stb);
            //bool IsSuccess;
            // if (FilePassedByContent)
            //     txt.Text = file;
            // else
            //     txt.Text = FileHelper.ReadFile(file,out IsSuccess);

            // f.Controls.Add(txt);

            // Button btnSend = new Button();
            // btnSend.Click += btnSend_Click;
            // btnSend.Text = buttonMessage;
            // btnSend.Location = new Point(10, 630);
            // f.Controls.Add(btnSend);

            // Button btn_cancel = new Button();

            // btn_cancel.Text = "Cancel";
            // btn_cancel.Click += btn_cancel_Click;
            // btn_cancel.Location = new Point(100, 630);
            // f.Controls.Add(btn_cancel);

            // Button btn_selectAll = new Button();
            // btn_selectAll.Text = "Select all";
            // btn_selectAll.Location = new Point( 190, 630);
            // btn_selectAll.Click += Btn_selectAll_Click;
            // f.Load += F_Load;
            // f.FormClosing += F_FormClosing;
            // f.ShowDialog();

            return IsOk;
        }

     

        private static void Btn_selectAll_Click(object sender, EventArgs e)
        {
            txt.SelectAll();
        }

        public static void CreateFile(string fileName, string sContent )
        {

            FileHelper.Deletefile(fileName);
            FileHelper.WriteStrToFile(fileName, sContent);
        }
       
    }
}
