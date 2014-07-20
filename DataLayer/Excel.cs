using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace DataLayer {
    public class Excel {
        public Excel(DataTable dt, string path = @"C:\Excel\exercise7.xls") {
            var app = new Application();
            Workbook workbook = null;
            Worksheet worksheet = null;
            Range workSheetDate = null;
            workbook = app.Workbooks.Add(1);
            worksheet = (Worksheet)workbook.Sheets[1];
            
            //set headers
            string[] columnNames = (from dc in dt.Columns.Cast<DataColumn>()
                        select dc.ColumnName).ToArray();

            for (int i = 0; i < columnNames.Length; i++)
            {
                
                worksheet.Cells[1, i+1] = columnNames[i];
            }
            double sum = 0.0;
            // for each row of data...
            int iRow = 0;
            foreach(DataRow r in dt.Rows) {
                iRow++;
                int iCol=0;
                // add each row's cell data...
                foreach(DataColumn c in dt.Columns) {
                    
                    iCol++;
                     
                    if (c.DataType==typeof(DateTime))
                    {
                    worksheet.Columns[1].NumberFormat = "MM/DD/YYYY";  
                    worksheet.Cells[iRow+1, iCol] = r[c.ColumnName];
  
                    }
                    else if (c.DataType==typeof(decimal))
                    {
                    sum += Convert.ToDouble(r[c.ColumnName].ToString());
                    worksheet.Cells[iRow + 1, iCol] = r[c.ColumnName];  
                    }  else
                    {
                    worksheet.Cells[iRow+1, iCol] = r[c.ColumnName];

                    }  
 
                  
                       
                    }
                worksheet.Cells[10,9]=sum;
            }
            workbook.SaveAs(path, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbook.Close();
            }
        }
    }
