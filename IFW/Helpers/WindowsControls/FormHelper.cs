using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Helpers.WindowsControls
{
    public class FormHelper
    {
        public static int Header_Height = 40;
        public static int Header_FontSize = 16;
        public static int margin = 10;
        public static string FontFamily = "serif";
        public static Color HeaderColor = Color.MintCream;

        public static void AddHeader(ref Form f,string headerText)
        {
            Label lbl = new Label();
            lbl.Font = new System.Drawing.Font(FontFamily, Header_FontSize);
            lbl.Height = Header_Height;
            lbl.Text = headerText;
            lbl.Top = margin;
            lbl.Left =margin;
            lbl.Width = f.Width-4*margin;
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbl.BorderStyle = BorderStyle.Fixed3D;
            lbl.BackColor = HeaderColor;
            f.Controls.Add(lbl);
        }
        public static void MaximizeForm(ref Form f)
        {
            f.AutoSize = false;
            f.MinimumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Rectangle r = GetScreen(ref f);
            f.Height = r.Height;
        }
        public static Rectangle GetScreen(ref Form f)
        {
            return Screen.FromControl(f).Bounds;
        }
        public static DialogResult ShowInputDialog(ref string input,bool isMultiLine=true)
        {
            int formHeight = 400;
            System.Drawing.Size size = new System.Drawing.Size(200, formHeight);
            Form inputBox = new Form();
            inputBox.StartPosition = FormStartPosition.CenterScreen;
            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Input";

            System.Windows.Forms.TextBox textBox = new TextBox();
            if (isMultiLine)
            {
                textBox.Multiline = true;
                textBox.Size = new System.Drawing.Size(size.Width - 10, 160);
            }
            else
            {
                textBox.Multiline = true;
                textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            }
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, inputBox.Height-70);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, inputBox.Height - 70);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }
    }
}
