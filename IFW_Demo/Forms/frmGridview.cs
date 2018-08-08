using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace WinControls
{
	/// <summary>
	/// Summary description for frmGridView.
	/// </summary>
	public class frmGridView : System.Windows.Forms.Form
	{
		private GridViewRelease.GridView gridView1 = new GridViewRelease.GridView ();
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem ClearMenu;
		private System.Windows.Forms.MenuItem OpenMenu;
		private System.Windows.Forms.MenuItem ExitMenu;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmGridView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			InitializeGrid();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void InitializeGrid()
		{
			gridView1.SetColumnNames(new string[]
			{
				"FirstName", 
				"LastName",
				"Company",
				"E-mail"
			}
				);
			
			gridView1.SetColumnWidth("FirstName", 10); // sets the width of the column in font units
			gridView1.SetColumnWidth("LastName", 10); // sets the width of the column in font units
			gridView1.SetColumnWidth("Company", 15); // sets the width of the column in font units
			gridView1.SetColumnWidth("E-mail", 20); // sets the width of the column in font units

			gridView1.SizeToFitGrid();
			
			gridView1.SetFullRow(2, new string[]
			{
				"John", "Doe", "Microsoft", "joe@aol.com"
			}
				);

			gridView1.SetCell(4, "E-mail", "bob@hotmail.com");

			// set color of text and cell
			gridView1.SetCellColor(4, "E-mail", Color.Blue);
			gridView1.SetCellTextColor(4, "E-mail", Color.Yellow);

			// set color of text and cell
			gridView1.SetCellColor(2, "Company", Color.BlueViolet);
			gridView1.SetCellTextColor(2, "Company", Color.Coral);

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
			this.gridView1 = new GridViewRelease.GridView();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.ClearMenu = new System.Windows.Forms.MenuItem();
			this.OpenMenu = new System.Windows.Forms.MenuItem();
			this.ExitMenu = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// gridView1
			// 
			this.gridView1.Location = new System.Drawing.Point(64, 32);
			this.gridView1.Name = "gridView1";
			this.gridView1.NumberOfColumns = 4;
			this.gridView1.NumberOfRows = 10;
			this.gridView1.Size = new System.Drawing.Size(352, 248);
			this.gridView1.TabIndex = 0;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.OpenMenu,
																					  this.menuItem2,
																					  this.ClearMenu,
																					  this.ExitMenu});
			this.menuItem1.Text = "File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Save";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// ClearMenu
			// 
			this.ClearMenu.Index = 2;
			this.ClearMenu.Text = "Clear";
			this.ClearMenu.Click += new System.EventHandler(this.ClearMenu_Click);
			// 
			// OpenMenu
			// 
			this.OpenMenu.Index = 0;
			this.OpenMenu.Text = "Open";
			this.OpenMenu.Click += new System.EventHandler(this.OpenMenu_Click);
			// 
			// ExitMenu
			// 
			this.ExitMenu.Index = 3;
			this.ExitMenu.Text = "Exit";
			this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.gridView1});
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Contact List";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			gridView1.Save();			
		}

		private void ClearMenu_Click(object sender, System.EventArgs e)
		{
			gridView1.Clear(true);
		}

		private void ExitMenu_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void OpenMenu_Click(object sender, System.EventArgs e)
		{
			gridView1.Open();
		}
	}
}
