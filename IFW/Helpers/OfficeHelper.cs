using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Helpers
{
    public class OfficeHelper
    {
        public static void saveToExcel(string filepath,string[]headers,string[][] values)
        {
            Microsoft.Office.Interop.Excel.Application oXL;
            Microsoft.Office.Interop.Excel._Workbook oWB;
            Microsoft.Office.Interop.Excel._Worksheet oSheet;
            Microsoft.Office.Interop.Excel.Range oRng;
            object misvalue = System.Reflection.Missing.Value;
            try
            {
                //Start Excel and get Application object.
                oXL = new Microsoft.Office.Interop.Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = (Microsoft.Office.Interop.Excel._Workbook)(oXL.Workbooks.Add(""));
                oSheet = (Microsoft.Office.Interop.Excel._Worksheet)oWB.ActiveSheet;

                //Add table headers going cell by cell.
                for (int i = 0; i < headers.GetLength(0); i++)
                   oSheet.Cells[1,i+1] = headers[i];

                //Format A1:D1 as bold, vertical alignment = center.
                oSheet.get_Range("A1", "N1").Font.Bold = true;
                oSheet.get_Range("A1", "N1").VerticalAlignment =
                    Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                // Create an array to multiple values at once.
                int cols, rows;
                rows = values.GetLength(0);
                cols = values[0].Length;
                string[,] sOFs = new string[rows, cols];

                for (int r = 0; r < rows; r++)
                   for (int c = 0; c < cols; c++)
                      sOFs[r, c] = values[r][c];

                //Fill A2:B6 with an array of values (First and Last Names).
                oSheet.get_Range("A2", "N"+(rows+1).ToString()).Value2 = sOFs;

                //Fill C2:C6 with a relative formula (=A2 & " " & B2).
                //oRng = oSheet.get_Range("C2", "C6");
                //oRng.Formula = "=A2 & \" \" & B2";

                //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                //oRng = oSheet.get_Range("D2", "D6");
                //oRng.Formula = "=RAND()*100000";
                //oRng.NumberFormat = "$0.00";

                //AutoFit columns A:D.
                oRng = oSheet.get_Range("A1", "N1");
                oRng.EntireColumn.AutoFit();

                oXL.Visible = false;
                oXL.UserControl = false;
                oWB.SaveAs(filepath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                    false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                oWB.Close();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
    }
}
