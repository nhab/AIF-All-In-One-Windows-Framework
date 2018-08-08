using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GridViewRelease
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	[GuidAttribute("14547C64-EE88-4e4f-BE81-CBB7AB6BB8C6")]
	public class GridView : System.Windows.Forms.UserControl
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private int NumRows  = 10;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.TextBox textBox1;
		private int NumColumns  = 4;
		private int CurrentRow = 0;
		private int CurrentColumn = 0;
		private System.Collections.Hashtable ColumnMap = new Hashtable();
		private GridPersister GridFiler = null;

		public GridView()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			InitializeGrid();

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
			this.listView1 = new System.Windows.Forms.ListView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.GridLines = true;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(208, 176);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
			this.listView1.SizeChanged += new System.EventHandler(this.listView1_SizeChanged);
			this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.textBox1.Location = new System.Drawing.Point(48, 88);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(64, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// GridView
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.textBox1,
																		  this.listView1});
			this.Name = "GridView";
			this.Size = new System.Drawing.Size(208, 176);
			this.Resize += new System.EventHandler(this.GridView_Resize);
			this.ResumeLayout(false);

		}
		#endregion


		public void InitializeGrid()
		{

			for (int i = 0; i < NumRows; i++)
			{
				ListViewItem anItem = new ListViewItem(" ");
				listView1.Items.Add(anItem);
				for (int j = 0; j < NumColumns; j++)
				{
					anItem.SubItems.Add(" ");
				}
			}

			for (int nCol=0; nCol < NumColumns; nCol++)
			{
				listView1.Columns.Add(" ", 25, HorizontalAlignment.Center);
			}

			PerformCellMoveByRow(CurrentRow, CurrentColumn);
			textBox1.Visible = true;
		

		}
	
	
		public GridView(int numRows, int numColumns)
		{
			NumRows = numRows;
			NumColumns = numColumns;
			InitializeComponent();
			InitializeGrid();
		}

		[DispId(1)]
		public void SetColumnName(int index, string aName)
		{
			if (index > listView1.Columns.Count)
			{
				MessageBox.Show("SetColumnName:Column out of range");
				return; // precondition
			}

			listView1.Columns[index - 1].Text = aName;
			ColumnMap[aName] = index;
		}

		[DispId(2)]
		public void SetColumnWidth(int index, int theWidth)
		{
			if (index - 1 >= listView1.Columns.Count)
			{
				MessageBox.Show("SetColumnWidth:Column out of range");
				return; // precondition
			}
			listView1.Columns[index - 1].Width = theWidth * (int)listView1.Font.SizeInPoints;
			PerformCellMoveByRow(CurrentRow, CurrentColumn);
		}

		public void SetColumnWidthAndIgnoreFont(int index, int theWidth)
		{
			if (index - 1 >= listView1.Columns.Count)
			{
				MessageBox.Show("SetColumnWidth:Column out of range");
				return; // precondition
			}
			listView1.Columns[index - 1].Width = theWidth;
			PerformCellMoveByRow(CurrentRow, CurrentColumn);
		}


		[DispId(3)]
		public void SetColumnNames(string[] columnNames)
		{
			for (int i = 0; i < columnNames.Length ; i++)
			{
				if (i >= listView1.Columns.Count)
				{
					listView1.Columns.Add(columnNames[i], columnNames[i].Length * (int)listView1.Font.SizeInPoints, HorizontalAlignment.Center);
				}
				else
				{
					listView1.Columns[i].Text = columnNames[i];
					listView1.Columns[i].Width = columnNames[i].Length * (int)Font.SizeInPoints;
				}

				ColumnMap[columnNames[i]] = i + 1;
			}	
		}

		[DispId(4)]
		public void SetColumnWidths(int[] columnWidths)
		{
			for (int i = 0; i < columnWidths.Length ; i++)
			{
				if (i >= listView1.Columns.Count)
				{
					listView1.Columns.Add(" ", columnWidths[i] * (int)listView1.Font.SizeInPoints, HorizontalAlignment.Center);
				}
				else
				{
					listView1.Columns[i].Width = columnWidths[i] * (int)Font.SizeInPoints;
				}
			}	

			PerformCellMoveByRow(CurrentRow, CurrentColumn);
		}

		[DispId(5)]
		public void SetCell(int aRow, int aColumn, string text)
		{
			if (aRow > listView1.Items.Count) // precondition
			{
				MessageBox.Show("SetCell:Row out of range");
				return;
			}

			if (aColumn > listView1.Columns.Count) // precondition
			{
				MessageBox.Show("SetCell:Column out of range");
				return;
			}
			if (aColumn - 1 == 0)
			{
				listView1.Items[aRow - 1].Text = text;
			}	
			else
			{
				listView1.Items[aRow - 1].SubItems[aColumn - 1].Text = text;
			}
		}

		[DispId(6)]
		public string GetCell(int aRow, int aColumn)
		{
			try
			{
				if (aColumn == 1)
				{
					return listView1.Items[aRow - 1].Text;
				}	

				return listView1.Items[aRow - 1].SubItems[aColumn - 1].Text;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
				return " ";
			}
		}

		[DispId(7)]
		public void SetFullRow(int nRow, string[] rowData)
		{
			for (int i = 0; i <rowData.Length ; i++)
			{
				SetCell(nRow, i+1, rowData[i]);
			}
		  	
		}

		[DispId(8)]
		public void SetFullColumn(int nColumn, string[] columnData)
		{
			for (int i = 0; i < columnData.Length ; i++)
			{
				SetCell(i, nColumn, columnData[i]);
			}
		  	
		}

		private void listView1_SizeChanged(object sender, System.EventArgs e)
		{
			listView1.Width = this.Width;
			listView1.Height = this.Height; 
		}



		private Rectangle RetrieveCellBounds(int x, int y, ref ListViewItem rowItem, ref int index)
		{
			Rectangle r = new Rectangle(0, 0, 10, 10);
			Point p = new Point(x, y);
//			p = listView1.PointToScreen(p);
			ListViewItem theCellRow = listView1.GetItemAt(5, p.Y);
			rowItem = theCellRow;
			if (theCellRow != null)
			{
				Rectangle rowRect = theCellRow.GetBounds(ItemBoundsPortion.ItemOnly);
				int sum = 0;
				for (int i = 0; i < listView1.Columns.Count; i++)
				{
					ColumnHeader ch = listView1.Columns[i];
					r = new Rectangle(rowRect.Left + sum, rowRect.Top, ch.Width, rowRect.Height);
					if (r.Contains(p))
					{
						index = i;
						return r;
					}
					sum += listView1.Columns[i].Width;
				}
			}

			return r;
		}

		void PopulateTextBox(ListViewItem theRow, int rowNum)
		{
			ListViewItem.ListViewSubItem theCell = theRow.SubItems[rowNum];
			textBox1.Text = theCell.Text;
			textBox1.BackColor = theCell.BackColor;
			textBox1.ForeColor = theCell.ForeColor;
		}

		void PopulateCell(int rowNum, int colNum)
		{
			if ((rowNum > -1) && (colNum > -1))
			{
				ListViewItem theRow = listView1.Items[rowNum];
				ListViewItem.ListViewSubItem theCell = theRow.SubItems[colNum];
				theCell.Text = textBox1.Text;
			}
		}

		private void PerformCellMove(int x, int y)
		{
			textBox1.Visible = true;
			ListViewItem theRow = null;
			int index = 0;
			Rectangle r  = RetrieveCellBounds(x, y, ref theRow, ref index);
			textBox1.SetBounds(r.X + 2, r.Y, r.Width, r.Height - 5);
			if (theRow != null)
			{
				CurrentColumn = index;
				CurrentRow  = theRow.Index;

				PopulateTextBox(theRow, index);
			}
		}

		int GetLeftPosition(int col)
		{
			int sum = 0;
			for (int i = 0; i < col; i++)
			{
				sum += listView1.Columns[i].Width;
			}

			return sum;
		}

		private void PerformCellMoveByRow(int row, int col)
		{
			textBox1.Visible = true;
			listView1.Focus();
			ListViewItem theRow = listView1.Items[row];
			int index = col;
			Rectangle r  = listView1.Items[row].Bounds;
			r.X = GetLeftPosition(col);
			r.Width = listView1.Columns[col].Width;
			textBox1.SetBounds(r.X + 2, r.Y, r.Width, r.Height - 5);
			if (theRow != null)
			{
				CurrentColumn = index;
				CurrentRow  = theRow.Index;
				PopulateTextBox(theRow, index);
			}
		}


		private void listView1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			PerformCellMove(e.X, e.Y);
			
//				PopulatePreviousCell(CurrentRow, CurrentColumn);
			
		}

		private void textBox1_TextChanged(object sender, System.EventArgs e)
		{
			PopulateCell(CurrentRow, CurrentColumn);
		}

		private void listView1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
//			textBox1.Focus();
		}

		private void MoveCell(KeyEventArgs result)
		{
			string c = result.KeyData.ToString();
			switch (c)
			{
				case "Left":
					if (CurrentColumn - 1 >= 0)
					{
						PerformCellMoveByRow(CurrentRow, CurrentColumn - 1);
					}
					break;
				case "Right":
					if (CurrentColumn + 1 < listView1.Columns.Count)
					{
						PerformCellMoveByRow(CurrentRow, CurrentColumn + 1);
					}
					break;
				case "Up":
					if (CurrentRow - 1 >= 0)
					{
						PerformCellMoveByRow(CurrentRow - 1, CurrentColumn);
					}
					break;
				case "Down":
					if (CurrentRow + 1 < listView1.Items.Count)
					{
						PerformCellMoveByRow(CurrentRow + 1, CurrentColumn);
					}
					break;
				default:
//					MessageBox.Show(result.KeyValue.ToString());
					if (textBox1.Focused == false)
					{
						if (result.KeyValue >=(int)'A' && result.KeyValue <= (int)'Z')
						{  
							if (result.Shift == false)
							{
								textBox1.Text = ((char) ((int)c[0] - (int)'A' + (int)'a')).ToString();
							}
							else
							{
								textBox1.Text = c;
							}
						}
						textBox1.Focus();
						textBox1.Select(textBox1.Text.Length, 1);
					}
					break;
			}
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
				string result = e.KeyData.ToString();
			    MoveCell(e);
		}

		private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
////		  listView1_KeyDown(sender, e);
///       
		  MoveCell(e);
		}

		private void GridView_Resize(object sender, System.EventArgs e)
		{
			listView1.SetBounds(0, 0, ClientRectangle.Width, ClientRectangle.Height);
		}

		public int NumberOfRows
		{
			get
			{
				return NumRows;
			}
			set
			{
				NumRows = value;
			}
			
		}


		[DispId(9)]
		public void SetCell(int aRow, string strColumn, string text)
		{
			if (ColumnMap[strColumn] == null)
				return;

			int aColumn = (int)ColumnMap[strColumn];
			SetCell(aRow, aColumn, text);
		}

		[DispId(10)]
		public string GetCell(int aRow, string strColumn)
		{
			if (ColumnMap[strColumn] == null)
				return "";

			int aColumn = (int)ColumnMap[strColumn];
			return GetCell(aRow, aColumn);

		}

		[DispId(11)]
		public void SetCellColor(int rowNum, int colNum, Color aColor)
		{
			ListViewItem theRow = listView1.Items[rowNum - 1];
			theRow.UseItemStyleForSubItems = false;
			ListViewItem.ListViewSubItem theCell = theRow.SubItems[colNum - 1];
			theCell.BackColor = aColor;
		}

		[DispId(12)]
		public void SetCellTextColor(int rowNum, int colNum, Color aColor)
		{
			ListViewItem theRow = listView1.Items[rowNum - 1];
			theRow.UseItemStyleForSubItems = false;
			ListViewItem.ListViewSubItem theCell = theRow.SubItems[colNum - 1];
			theCell.ForeColor = aColor;
		}

		[DispId(13)]
		public void SetColumnWidth(string strColumn, int theWidth)
		{
			if (ColumnMap[strColumn] == null)
				return;

			int index = (int)ColumnMap[strColumn];
			SetColumnWidth(index, theWidth);
		}

		[DispId(14)]
		public void SetCellColor(int rowNum, string strColumn, Color aColor)
		{
			if (ColumnMap[strColumn] == null)
				return;

			int colNum = (int)ColumnMap[strColumn];
			SetCellColor(rowNum, colNum, aColor);
		}

		[DispId(15)]
		public void SetCellTextColor(int rowNum, string strColumn, Color aColor)
		{
			if (ColumnMap[strColumn] == null)
				return;

			int colNum = (int)ColumnMap[strColumn];
			SetCellTextColor(rowNum, colNum, aColor);
		}

		private int SumColumnWidths()
		{
			int sum = 0;
			for (int i = 0; i < listView1.Columns.Count; i++)
			{
				sum += listView1.Columns[i].Width;
			}

			return sum;

		}

		[DispId(16)]
		public void SizeToFitGrid()
		{
			Rectangle rtList = listView1.Bounds;
			Rectangle rect = listView1.Items[0].GetBounds(ItemBoundsPortion.Entire );
			rect.Width = SumColumnWidths() + 20;
			rect.Height = (listView1.Items.Count * rect.Height) + rect.Height + 10;
			SetBounds(this.Bounds.X, this.Bounds.Y, rect.Width, rect.Height);
			listView1.SetBounds(0, 0, rect.Width, rect.Height);
		}

		[DispId(17)]
		public void Save()
		{
			GridFiler = new GridPersister(this);
			GridFiler.Write();
		}


		[DispId(18)]
		public Color GetCellTextColor(int rowNum, int colNum)
		{
			ListViewItem theRow = listView1.Items[rowNum - 1];
			ListViewItem.ListViewSubItem theCell = theRow.SubItems[colNum - 1];
			return theCell.ForeColor;
		}

		[DispId(19)]
		public Color GetCellColor(int rowNum, int colNum)
		{
			ListViewItem theRow = listView1.Items[rowNum - 1];
			ListViewItem.ListViewSubItem theCell = theRow.SubItems[colNum - 1];
			return theCell.BackColor;
		}

		[DispId(20)]
		public void Clear(bool bIncludeColumns)
		{
			if (bIncludeColumns)
			{
				for (int j = 0; j < this.NumberOfColumns; j++)
				{
					listView1.Columns[j].Text = "";
					listView1.Columns[j].Width = 20;
				}
			}

			for (int i = 0; i < this.NumberOfRows; i++)
			{
				ListViewItem theRow = listView1.Items[i];
				for (int j = 0; j < this.NumberOfColumns; j++)
				{
					ListViewItem.ListViewSubItem theCell = theRow.SubItems[j];
					theCell.Text = "";
					theCell.BackColor = Color.White;
					theCell.ForeColor = Color.Black;
				}
			}
		}


		[DispId(21)]
		public void Open()
		{
			GridFiler = new GridPersister(this);
			GridFiler.Read();
		}

		public string GetColumnName(int index)
		{
		 return listView1.Columns[index - 1].Text;
		}

		public int GetColumnWidth(int index)
		{
			return listView1.Columns[index - 1].Width;
		}


		public int NumberOfColumns
		{
			get
			{
				return NumColumns;
			}
			set
			{
				NumColumns = value;
			}
			
		}

	}
}
