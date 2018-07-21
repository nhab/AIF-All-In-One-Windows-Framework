//using SourceGrid2;
using SourceGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFramework.Helpers
{
    public class SourceGridHelper
    {
        public static Grid Create(ref Form form, Point p, Size size)
        {
            Grid grid1 = new Grid();

            grid1.Location = p;
            grid1.Size = size;
            grid1.SelectionMode = GridSelectionMode.Row;
            grid1.EnableSort = true;
            grid1.OptimizeMode = CellOptimizeMode.ForRows;
            grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            grid1.TabIndex = 0;
            grid1.TabStop = true;
            grid1.ToolTipText = "";

            form.Controls.Add(grid1);
            //grid1.Redim(2, 2);
            return grid1;
        }

        public static void CreateSample(ref Grid grid1)
        {
            //Border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            //Views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.Khaki, Color.DarkKhaki);
            viewNormal.Border = cellBorder;
            CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(Color.Khaki, Color.DarkKhaki);
            viewCheckBox.Border = cellBorder;

            //ColumnHeader view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.Maroon;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.White;
            viewColumnHeader.Font = new Font("Comic Sans MS", 10, FontStyle.Underline);

            //Editors
            SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));


            //Create the grid
            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = 3;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);

            SourceGrid.Cells.ColumnHeader columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("String");
            columnHeader.View = viewColumnHeader;
            grid1[0, 0] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("DateTime");
            columnHeader.View = viewColumnHeader;
            grid1[0, 1] = columnHeader;

            columnHeader = new SourceGrid.Cells.ColumnHeader("CheckBox");
            columnHeader.View = viewColumnHeader;
            grid1[0, 2] = columnHeader;

            for (int r = 1; r < 10; r++)
            {
                grid1.Rows.Insert(r);

                grid1[r, 0] = new SourceGrid.Cells.Cell("Hello " + r.ToString());
                grid1[r, 0].Editor = editorString;

                grid1[r, 1] = new SourceGrid.Cells.Cell(DateTime.Today);
                grid1[r, 1].Editor = editorDateTime;

                grid1[r, 2] = new SourceGrid.Cells.CheckBox(null, true);

                grid1[r, 0].View = viewNormal;
                grid1[r, 1].View = viewNormal;
                grid1[r, 2].View = viewCheckBox;
            }

            grid1.AutoSizeCells();
        }
        public static void Populate(ref Grid grid1, string[] cols, string[] colTyeNames, List<Hashtable> htList_WithKey
            , Color HeaderBackColor,Color cellBackColor,Color cellBackColorAlternate)
        {
            //Border
            DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.DarkKhaki, 1);
            DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);

            //Views
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(cellBackColor, cellBackColorAlternate);
            viewNormal.Border = cellBorder;
            CheckBoxBackColorAlternate viewCheckBox = new CheckBoxBackColorAlternate(cellBackColor, cellBackColorAlternate);
            viewCheckBox.Border = cellBorder;

            //ColumnHeader view
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();

            backHeader.BackColor = HeaderBackColor;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.White;
            viewColumnHeader.Font = new Font("Comic Sans MS", 10, FontStyle.Underline);

            //Editors
            SourceGrid.Cells.Editors.TextBox editorString = new SourceGrid.Cells.Editors.TextBox(typeof(string));
            SourceGrid.Cells.Editors.TextBoxUITypeEditor editorDateTime = new SourceGrid.Cells.Editors.TextBoxUITypeEditor(typeof(DateTime));
            int colsLen = cols.Count();
            int rowsLen = htList_WithKey.Count;

            //Create the grid
            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.ColumnsCount = colsLen;
            grid1.FixedRows = 1;
            grid1.Rows.Clear();
            grid1.Rows.Insert(0);
           
            SourceGrid.Cells.ColumnHeader columnHeader;
            //header:
            for (int i = 0; i < colsLen; i++)
            {
                columnHeader = new SourceGrid.Cells.ColumnHeader(cols[i]);
                columnHeader.View = viewColumnHeader;
                grid1[0, i] = columnHeader;
            }
            //rows:
            for (int r = 1; r <= rowsLen; r++)
            {
                grid1.Rows.Insert(r);
                
                for (int c = 0; c < colsLen; c++)
                {
                   switch (colTyeNames[c])
                    {
                        case "CheckBox":
                            if (htList_WithKey[r - 1][cols[c]] != null)
                            {
                                if (htList_WithKey[r - 1][cols[c]].ToString() != "")
                                {
                                    bool b = bool.Parse(htList_WithKey[r - 1][cols[c]].ToString());
                                    grid1[r, c] = new SourceGrid.Cells.CheckBox( null, b);
                               
                                    grid1[r, c].View = viewCheckBox;
                                }
                            }
                             break;
                        case "CheckBoxVirtual":
                            if (htList_WithKey[r - 1][cols[c]] != null)
                            {
                                if (htList_WithKey[r - 1][cols[c]].ToString() != "")
                                {

                                    bool b=false;
                                    if (htList_WithKey[r - 1][cols[c]].ToString() == "11")
                                        b = true;

                                    grid1[r, c] = new SourceGrid.Cells.CheckBox(null, b);

                                    grid1[r, c].View = viewCheckBox;
                                }
                            }
                            break;
                         default:
                            if (htList_WithKey[r-1][cols[c]] != null)
                                grid1[r, c] = new SourceGrid.Cells.Cell(htList_WithKey[r-1][cols[c]].ToString());
                            else
                                grid1[r, c] = new SourceGrid.Cells.Cell("");

                            grid1[r, c].View = viewNormal;
                            break;
                    }
                }
            }
            grid1.AutoSizeCells();
        }
        public static int GetColIndex(Grid grid1, string colName)
        {
            int l = grid1.Columns.Count;
            for (int i = 0; i < l; i++)
            {
                if (grid1[0, i].ToString().ToLower() == colName.Trim().ToLower())
                    return i;
            }
            return -1;
        }
        public static void HideColumn(ref Grid grid1,string colName)
        {
            int colindex = SourceGridHelper.GetColIndex(grid1, colName);
            grid1.Columns[0].Width = 0;
        }
        public static int getSelectedRow( Grid grid1) {
            grid1.Focus();
            if (grid1.Selection.ActivePosition.IsEmpty()) return -1;
            return grid1.Selection.ActivePosition.Row;
        }
        public static void SetCheckBoxCell(ref Grid grid1,int row, int col, bool b)
        {
                    grid1[row, col] = new SourceGrid.Cells.CheckBox(null, b);
        }
        public static bool GetCheckBoxCell(Grid grid1, int row, int col)
        {
            return bool.Parse(grid1[row, col].Value.ToString()) ;
        }
        public static string GetCheckedCellCount(Grid grid1,int col)
        {
            int c = 0;
            for (int i = 1; i < grid1.Rows.Count; i++)
                if (grid1[i, col].Value.ToString() == "True")
                    c++;
            return c.ToString();
        }
    }
    public class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
    {
        public CellBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }

        private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        {
            get { return mFirstBackground; }
            set { mFirstBackground = value; }
        }

        private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        {
            get { return mSecondBackground; }
            set { mSecondBackground = value; }
        }

        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);

            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }
    }
    public class CheckBoxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
    {
        public CheckBoxBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }

        private DevAge.Drawing.VisualElements.IVisualElement mFirstBackground;
        public DevAge.Drawing.VisualElements.IVisualElement FirstBackground
        {
            get { return mFirstBackground; }
            set { mFirstBackground = value; }
        }

        private DevAge.Drawing.VisualElements.IVisualElement mSecondBackground;
        public DevAge.Drawing.VisualElements.IVisualElement SecondBackground
        {
            get { return mSecondBackground; }
            set { mSecondBackground = value; }
        }

        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);

            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }

    }
    
}
