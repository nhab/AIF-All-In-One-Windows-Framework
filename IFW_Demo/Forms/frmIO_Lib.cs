using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using csIOLib;
using System.IO;
using System.Threading;

namespace Demo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmIO_LIB: System.Windows.Forms.Form
	{
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.FolderBrowserDialog dlgFolder;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnFileCancel;
		private System.Windows.Forms.Button btnFileSource;
		private System.Windows.Forms.Button btnFileTarget;
		private System.Windows.Forms.TextBox txtFileTarget;
		private System.Windows.Forms.TextBox txtFileSource;
		private System.Windows.Forms.Button btnFileCopy;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ProgressBar prgFile;
		private System.Windows.Forms.Button btnFolderCopy;
		private System.Windows.Forms.Button btnFolderCancel;
		private System.Windows.Forms.TextBox txtFolderTarget;
		private System.Windows.Forms.TextBox txtFolderSource;
		private System.Windows.Forms.Label lblFileDetails;
		private System.Windows.Forms.OpenFileDialog dlgSource;
		private System.Windows.Forms.SaveFileDialog dlgTarget;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label lblFolderTargetFile;
		private System.Windows.Forms.Label lblFolderSourceFile;
		private System.Windows.Forms.Button btnFolderSource;
		private System.Windows.Forms.Button btnFolderTarget;
		private System.Windows.Forms.ProgressBar prgFolderFile;
		private System.Windows.Forms.ProgressBar prgFolderTotal;
		private System.Windows.Forms.Label lblFolderFileDetails;
		private System.Windows.Forms.Label lblFolderTotalDetails;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIO_LIB()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.prgFolderFile = new System.Windows.Forms.ProgressBar();
            this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnFolderCopy = new System.Windows.Forms.Button();
            this.prgFolderTotal = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblFolderFileDetails = new System.Windows.Forms.Label();
            this.lblFolderTotalDetails = new System.Windows.Forms.Label();
            this.lblFolderSourceFile = new System.Windows.Forms.Label();
            this.lblFolderTargetFile = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFolderCancel = new System.Windows.Forms.Button();
            this.btnFolderSource = new System.Windows.Forms.Button();
            this.btnFolderTarget = new System.Windows.Forms.Button();
            this.txtFolderTarget = new System.Windows.Forms.TextBox();
            this.txtFolderSource = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblFileDetails = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFileCancel = new System.Windows.Forms.Button();
            this.btnFileSource = new System.Windows.Forms.Button();
            this.btnFileTarget = new System.Windows.Forms.Button();
            this.txtFileTarget = new System.Windows.Forms.TextBox();
            this.txtFileSource = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.prgFile = new System.Windows.Forms.ProgressBar();
            this.btnFileCopy = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.dlgSource = new System.Windows.Forms.OpenFileDialog();
            this.dlgTarget = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgFolderFile
            // 
            this.prgFolderFile.Location = new System.Drawing.Point(154, 240);
            this.prgFolderFile.Name = "prgFolderFile";
            this.prgFolderFile.Size = new System.Drawing.Size(742, 23);
            this.prgFolderFile.TabIndex = 1;
            // 
            // btnFolderCopy
            // 
            this.btnFolderCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFolderCopy.Location = new System.Drawing.Point(622, 94);
            this.btnFolderCopy.Name = "btnFolderCopy";
            this.btnFolderCopy.Size = new System.Drawing.Size(146, 33);
            this.btnFolderCopy.TabIndex = 8;
            this.btnFolderCopy.Text = "Copy Folder";
            this.btnFolderCopy.Click += new System.EventHandler(this.btnFolderCopy_Click);
            // 
            // prgFolderTotal
            // 
            this.prgFolderTotal.Location = new System.Drawing.Point(154, 304);
            this.prgFolderTotal.Name = "prgFolderTotal";
            this.prgFolderTotal.Size = new System.Drawing.Size(742, 23);
            this.prgFolderTotal.TabIndex = 12;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(998, 392);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage2.Controls.Add(this.lblFolderFileDetails);
            this.tabPage2.Controls.Add(this.lblFolderTotalDetails);
            this.tabPage2.Controls.Add(this.lblFolderSourceFile);
            this.tabPage2.Controls.Add(this.lblFolderTargetFile);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.btnFolderCancel);
            this.tabPage2.Controls.Add(this.btnFolderSource);
            this.tabPage2.Controls.Add(this.btnFolderTarget);
            this.tabPage2.Controls.Add(this.txtFolderTarget);
            this.tabPage2.Controls.Add(this.txtFolderSource);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.prgFolderFile);
            this.tabPage2.Controls.Add(this.prgFolderTotal);
            this.tabPage2.Controls.Add(this.btnFolderCopy);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(990, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Folder Copying";
            // 
            // lblFolderFileDetails
            // 
            this.lblFolderFileDetails.AutoSize = true;
            this.lblFolderFileDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFolderFileDetails.Location = new System.Drawing.Point(154, 216);
            this.lblFolderFileDetails.Name = "lblFolderFileDetails";
            this.lblFolderFileDetails.Size = new System.Drawing.Size(75, 20);
            this.lblFolderFileDetails.TabIndex = 28;
            this.lblFolderFileDetails.Text = "0% Done";
            this.lblFolderFileDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFolderTotalDetails
            // 
            this.lblFolderTotalDetails.AutoSize = true;
            this.lblFolderTotalDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFolderTotalDetails.Location = new System.Drawing.Point(154, 281);
            this.lblFolderTotalDetails.Name = "lblFolderTotalDetails";
            this.lblFolderTotalDetails.Size = new System.Drawing.Size(75, 20);
            this.lblFolderTotalDetails.TabIndex = 27;
            this.lblFolderTotalDetails.Text = "0% Done";
            this.lblFolderTotalDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFolderSourceFile
            // 
            this.lblFolderSourceFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFolderSourceFile.Location = new System.Drawing.Point(141, 143);
            this.lblFolderSourceFile.Name = "lblFolderSourceFile";
            this.lblFolderSourceFile.Size = new System.Drawing.Size(755, 24);
            this.lblFolderSourceFile.TabIndex = 26;
            // 
            // lblFolderTargetFile
            // 
            this.lblFolderTargetFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFolderTargetFile.Location = new System.Drawing.Point(141, 177);
            this.lblFolderTargetFile.Name = "lblFolderTargetFile";
            this.lblFolderTargetFile.Size = new System.Drawing.Size(755, 23);
            this.lblFolderTargetFile.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Location = new System.Drawing.Point(64, 180);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Target";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Location = new System.Drawing.Point(26, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Current File";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnFolderCancel
            // 
            this.btnFolderCancel.Enabled = false;
            this.btnFolderCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFolderCancel.Location = new System.Drawing.Point(781, 94);
            this.btnFolderCancel.Name = "btnFolderCancel";
            this.btnFolderCancel.Size = new System.Drawing.Size(115, 33);
            this.btnFolderCancel.TabIndex = 21;
            this.btnFolderCancel.Text = "Cancel";
            this.btnFolderCancel.Click += new System.EventHandler(this.btnFolderCancel_Click);
            // 
            // btnFolderSource
            // 
            this.btnFolderSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFolderSource.Location = new System.Drawing.Point(864, 19);
            this.btnFolderSource.Name = "btnFolderSource";
            this.btnFolderSource.Size = new System.Drawing.Size(38, 23);
            this.btnFolderSource.TabIndex = 20;
            this.btnFolderSource.Text = "...";
            this.btnFolderSource.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFolderSource.Click += new System.EventHandler(this.btnFolderSource_Click);
            // 
            // btnFolderTarget
            // 
            this.btnFolderTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFolderTarget.Location = new System.Drawing.Point(864, 54);
            this.btnFolderTarget.Name = "btnFolderTarget";
            this.btnFolderTarget.Size = new System.Drawing.Size(38, 23);
            this.btnFolderTarget.TabIndex = 19;
            this.btnFolderTarget.Text = "...";
            this.btnFolderTarget.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFolderTarget.Click += new System.EventHandler(this.btnFolderTarget_Click);
            // 
            // txtFolderTarget
            // 
            this.txtFolderTarget.Location = new System.Drawing.Point(154, 47);
            this.txtFolderTarget.Name = "txtFolderTarget";
            this.txtFolderTarget.Size = new System.Drawing.Size(704, 26);
            this.txtFolderTarget.TabIndex = 18;
            // 
            // txtFolderSource
            // 
            this.txtFolderSource.Location = new System.Drawing.Point(154, 12);
            this.txtFolderSource.Name = "txtFolderSource";
            this.txtFolderSource.Size = new System.Drawing.Size(704, 26);
            this.txtFolderSource.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(16, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Target Folder";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(11, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Source Folder";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(13, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Total Progress";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(24, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "File Progress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabPage1.Controls.Add(this.lblFileDetails);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btnFileCancel);
            this.tabPage1.Controls.Add(this.btnFileSource);
            this.tabPage1.Controls.Add(this.btnFileTarget);
            this.tabPage1.Controls.Add(this.txtFileTarget);
            this.tabPage1.Controls.Add(this.txtFileSource);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.prgFile);
            this.tabPage1.Controls.Add(this.btnFileCopy);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(913, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Copying";
            // 
            // lblFileDetails
            // 
            this.lblFileDetails.AutoSize = true;
            this.lblFileDetails.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFileDetails.Location = new System.Drawing.Point(810, 267);
            this.lblFileDetails.Name = "lblFileDetails";
            this.lblFileDetails.Size = new System.Drawing.Size(75, 20);
            this.lblFileDetails.TabIndex = 33;
            this.lblFileDetails.Text = "0% Done";
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(26, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(345, 24);
            this.label8.TabIndex = 32;
            this.label8.Text = "This demo will show copying of a file in units";
            // 
            // btnFileCancel
            // 
            this.btnFileCancel.Enabled = false;
            this.btnFileCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFileCancel.Location = new System.Drawing.Point(781, 175);
            this.btnFileCancel.Name = "btnFileCancel";
            this.btnFileCancel.Size = new System.Drawing.Size(115, 34);
            this.btnFileCancel.TabIndex = 31;
            this.btnFileCancel.Text = "Cancel";
            this.btnFileCancel.Click += new System.EventHandler(this.btnFileCancel_Click);
            // 
            // btnFileSource
            // 
            this.btnFileSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFileSource.Location = new System.Drawing.Point(853, 101);
            this.btnFileSource.Name = "btnFileSource";
            this.btnFileSource.Size = new System.Drawing.Size(38, 23);
            this.btnFileSource.TabIndex = 30;
            this.btnFileSource.Text = "...";
            this.btnFileSource.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFileSource.Click += new System.EventHandler(this.btnFileSource_Click);
            // 
            // btnFileTarget
            // 
            this.btnFileTarget.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFileTarget.Location = new System.Drawing.Point(853, 136);
            this.btnFileTarget.Name = "btnFileTarget";
            this.btnFileTarget.Size = new System.Drawing.Size(38, 23);
            this.btnFileTarget.TabIndex = 29;
            this.btnFileTarget.Text = "...";
            this.btnFileTarget.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFileTarget.Click += new System.EventHandler(this.btnFileTarget_Click);
            // 
            // txtFileTarget
            // 
            this.txtFileTarget.Location = new System.Drawing.Point(115, 129);
            this.txtFileTarget.Name = "txtFileTarget";
            this.txtFileTarget.Size = new System.Drawing.Size(730, 26);
            this.txtFileTarget.TabIndex = 28;
            // 
            // txtFileSource
            // 
            this.txtFileSource.Location = new System.Drawing.Point(115, 94);
            this.txtFileSource.Name = "txtFileSource";
            this.txtFileSource.Size = new System.Drawing.Size(730, 26);
            this.txtFileSource.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(18, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Target File";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(13, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Source File";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Location = new System.Drawing.Point(13, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 20);
            this.label7.TabIndex = 24;
            this.label7.Text = "Copy Progress";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prgFile
            // 
            this.prgFile.Location = new System.Drawing.Point(13, 234);
            this.prgFile.Name = "prgFile";
            this.prgFile.Size = new System.Drawing.Size(883, 23);
            this.prgFile.TabIndex = 22;
            // 
            // btnFileCopy
            // 
            this.btnFileCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFileCopy.Location = new System.Drawing.Point(653, 175);
            this.btnFileCopy.Name = "btnFileCopy";
            this.btnFileCopy.Size = new System.Drawing.Size(115, 34);
            this.btnFileCopy.TabIndex = 23;
            this.btnFileCopy.Text = "Copy";
            this.btnFileCopy.Click += new System.EventHandler(this.btnFileCopy_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Location = new System.Drawing.Point(13, 416);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(998, 128);
            this.txtOutput.TabIndex = 14;
            // 
            // dlgSource
            // 
            this.dlgSource.Filter = "All Files(*.*)|*.*";
            // 
            // dlgTarget
            // 
            this.dlgTarget.Filter = "All Files(*.*)|*.*";
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(1024, 553);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "File Coping with pause capability)";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		

		#region File

		Thread fileThread;
		csIOLib.File fileCopier;

		private void btnFileCopy_Click(object sender, System.EventArgs e)
		{
			btnFileCopy.Enabled = false;
			btnFileCancel.Enabled = true;
			fileThread = null;
			fileThread = new Thread(new ThreadStart(this.Copy));
			fileThread.Name = "File Copier";
			fileThread.Start();
		}

		private void Copy()
		{
			fileCopier = null;
			fileCopier = new csIOLib.File();
			fileCopier.UnitCopy += new UnitCopyEventHandler(fileCopier_UnitCopy);
			fileCopier.AfterStop +=new AfterStopEventHandler(fileCopier_AfterStop);
			fileCopier.Copy(txtFileSource.Text,txtFileTarget.Text,0,true);
		}

		private void fileCopier_UnitCopy(object sender, UnitCopyEventArgs e)
		{
			prgFile.Maximum = (int)e.FileSize;
			prgFile.Value += (int)e.BytesCopied;

			lblFileDetails.Text = e.Percent.ToString() + "% Done";

			if (prgFile.Value == prgFile.Maximum)
			{
				prgFile.Maximum = 0;
				prgFile.Value = 0;
				btnFileCancel.Enabled = false;
				btnFileCopy.Enabled = true;
				MessageBox.Show("Done!","Demo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void btnFileCancel_Click(object sender, System.EventArgs e)
		{
			btnFileCancel.Enabled = false;
			btnFileCopy.Enabled = true;
			prgFile.Value = 0;
			fileCopier.Stop();
		}

		private void btnFileSource_Click(object sender, System.EventArgs e)
		{
			if (dlgSource.ShowDialog() == DialogResult.OK){
				this.txtFileSource.Text = dlgSource.FileName;
			}
		}

		private void btnFileTarget_Click(object sender, System.EventArgs e)
		{
			dlgTarget.FileName = csIOLib.File.GetFileName(txtFileSource.Text);
			if (dlgTarget.ShowDialog() == DialogResult.OK){
				this.txtFileTarget.Text = dlgTarget.FileName;
			}
		}

		private void fileCopier_AfterStop(object sender)
		{
			txtOutput.Text += "Copying was aborted...\r\nPartly Copied File was deleted...\r\n";
			txtOutput.SelectionStart = txtOutput.Text.Length;
			txtOutput.ScrollToCaret();
			fileThread.Abort();
			txtOutput.Text += "Thread was aborted...\r\n";
			MessageBox.Show("Copying was cancelled","Demo",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		#endregion

		#region Folder

		Thread folderThread;
		csIOLib.File folderCopier;

		private void btnFolderSource_Click(object sender, System.EventArgs e)
		{
			if (dlgFolder.ShowDialog() == DialogResult.OK){
				txtFolderSource.Text = dlgFolder.SelectedPath;
			}
		}

		private void btnFolderTarget_Click(object sender, System.EventArgs e)
		{
			if (dlgFolder.ShowDialog() == DialogResult.OK){
				txtFolderTarget.Text = dlgFolder.SelectedPath;
			}
		}

		private void btnFolderCopy_Click(object sender, System.EventArgs e)
		{
			lblFolderSourceFile.Text = "Calculating time to complete...";
			txtOutput.Text += "Calculating time to complete...\r\n";
			btnFolderCopy.Enabled = false;
			btnFolderCancel.Enabled = true;
			folderThread = null;
			folderThread = new Thread(new ThreadStart(this.CopyFolder));
			folderThread.Start();
		}

		private void btnFolderCancel_Click(object sender, System.EventArgs e)
		{
			folderCopier.Stop();
		}

		private void CopyFolder()
		{
			folderCopier = null;
			folderCopier = new csIOLib.File();
			folderCopier.UnitCopy += new UnitCopyEventHandler(folderCopier_UnitCopy);
			folderCopier.BeforeFileCopy += new BeforeFileCopyEventHandler(folderCopier_BeforeFileCopy);
			folderCopier.AfterStop +=new AfterStopEventHandler(folderCopier_AfterStop);
			folderCopier.CopyFolder(txtFolderSource.Text, txtFolderTarget.Text, 0, true, true);	
		}

	
		private void folderCopier_UnitCopy(object sender, UnitCopyEventArgs e)
		{
			prgFolderFile.Maximum = (int)e.FileSize;
			prgFolderFile.Value += (int)e.BytesCopied;

			prgFolderTotal.Value += (int)e.BytesCopied;
			
			lblFolderFileDetails.Text = e.Percent.ToString() + "% Done";

			if (prgFolderFile.Value == prgFolderFile.Maximum){
				prgFolderFile.Value = 0;
				prgFolderFile.Maximum = 0;
			}

			if (prgFolderTotal.Value == prgFolderTotal.Maximum){
				prgFolderTotal.Value = 0;
				prgFolderTotal.Maximum = 0;
				lblFolderTotalDetails.Text = "0% Done";
				btnFolderCancel.Enabled = false;
				btnFolderCopy.Enabled = true;
				txtOutput.Text += "Done copying...\r\n";
				MessageBox.Show("Done!","Demo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void folderCopier_BeforeFileCopy(object sender, FileCopyEventArgs e)
		{
			prgFolderTotal.Maximum = (int)e.TotalBytes;
			lblFolderTotalDetails.Text = e.Percent.ToString() + "% Done";
			lblFolderSourceFile.Text = e.SourceFile;
			lblFolderTargetFile.Text = e.TargetFile;
		}

		private void folderCopier_AfterStop(object sender)
		{
			txtOutput.Text += "Copying was aborted...\r\nPartly Copied File was deleted...\r\n";
			txtOutput.SelectionStart = txtOutput.Text.Length;
			txtOutput.ScrollToCaret();
			txtOutput.Text += "Thread was aborted...\r\n";
			MessageBox.Show("Copying was cancelled","Demo",MessageBoxButtons.OK,MessageBoxIcon.Information);
			folderThread.Abort();
		}

		#endregion

	}
}
