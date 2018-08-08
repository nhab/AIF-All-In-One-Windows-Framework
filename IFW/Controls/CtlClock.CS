using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinControls
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class ctlClock : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lblDisplay;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		public ctlClock()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.lblDisplay = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// lblDisplay
			// 
			this.lblDisplay.BackColor = System.Drawing.Color.PaleGreen;
			this.lblDisplay.Font = new System.Drawing.Font("Traditional Arabic Backslanted", 12F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(178)));
			this.lblDisplay.Location = new System.Drawing.Point(16, 8);
			this.lblDisplay.Name = "lblDisplay";
			this.lblDisplay.Size = new System.Drawing.Size(128, 40);
			this.lblDisplay.TabIndex = 0;
			this.lblDisplay.Click += new System.EventHandler(this.lblDisplay_Click);
			// 
			// ctlClock
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblDisplay});
			this.Name = "ctlClock";
			this.Size = new System.Drawing.Size(216, 104);
			this.Load += new System.EventHandler(this.ctlClock_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			lblDisplay.Text= (System.DateTime.Now.GetDateTimeFormats('T'))[0];
		}

		private void lblDisplay_Click(object sender, System.EventArgs e)
		{

		}

		private void ctlClock_Load(object sender, System.EventArgs e)
		{

		}
	}
}
