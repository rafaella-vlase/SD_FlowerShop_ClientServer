using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_FlowerShop_Server.Domain;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.Office.Core;
using System.IO;

namespace SD_FlowerShop_Client.Service
{
    public class ExcelSaveService: FileSaveService
    {
        public ExcelSaveService()
        {
            this.extension = ".xlsx";
            this.fileType = "Excel files (*.xlsx)|*.xlsx";
        }

        protected override void save(List<Flower> flowerList, string figureTitle, string fileName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = false;
                object misValue = System.Reflection.Missing.Value;
                _Workbook workbook = app.Workbooks.Add(misValue);
                _Worksheet worksheet = workbook.Worksheets[1];
                worksheet.Name = "Company";
                worksheet.EnableSelection = XlEnableSelection.xlNoSelection;

                Range xlRange;
                xlRange = worksheet.Cells[1, 3];
                xlRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                xlRange.Interior.Color = Color.LightBlue;
                worksheet.Cells[1, 3] = "Flower List";
                worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[1, 5]].Merge();

                worksheet.Cells[3, 2] = "FlowerID";
                worksheet.Columns[2].ColumnWidth = 5;
                worksheet.Cells[3, 3] = "ShopID";
                worksheet.Columns[3].ColumnWidth = 30;
                worksheet.Cells[3, 4] = "FlowerName";
                worksheet.Columns[4].ColumnWidth = 15;
                worksheet.Cells[3, 5] = "Color";
                worksheet.Columns[5].ColumnWidth = 15;
                worksheet.Cells[3, 6] = "Price";
                worksheet.Columns[6].ColumnWidth = 20;
                worksheet.Cells[3, 7] = "Stock";
                worksheet.Columns[6].ColumnWidth = 20;
                
                for (int j = 1; j <= 6; j++)
                {
                    xlRange = worksheet.Cells[3, j + 1];
                    xlRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    xlRange.Borders.Color = Color.DarkBlue;
                    xlRange.Font.Size = 12;
                    xlRange.Font.FontStyle = FontStyle.Bold;
                }

                int rowsNumber = flowerList.Count;
                for (int i = 1; i <= rowsNumber; i++)
                {
                    worksheet.Cells[3 + i, 2] = flowerList[i - 1].FlowerID.ToString();
                    worksheet.Cells[3 + i, 3] = flowerList[i - 1].ShopID.ToString();
                    worksheet.Cells[3 + i, 4] = flowerList[i - 1].FlowerName;
                    worksheet.Cells[3 + i, 5] = flowerList[i - 1].Color;
                    worksheet.Cells[3 + i, 6] = flowerList[i - 1].Price.ToString();
                    worksheet.Cells[3 + i, 7] = flowerList[i - 1].Stock.ToString();
                    for (int j = 1; j <= 6; j++)
                    {
                        xlRange = worksheet.Cells[3 + i, j + 1];
                        xlRange.Font.Size = 12;
                        xlRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                        xlRange.Borders.Color = Color.DarkBlue;
                        xlRange.Font.Size = 12;
                        if (i % 2 == 0)
                            xlRange.Interior.Color = Color.LightBlue;
                        else
                            xlRange.Interior.Color = Color.White;
                    }
                }
                //string target = this.createImage(chartImage);
                //if (target != null && target != "")
                //{
                //    worksheet.Cells[rowsNumber + 5, 2] = "Adding picture in Excel File";
                //    worksheet.Range[worksheet.Cells[rowsNumber + 6, 2], worksheet.Cells[rowsNumber + 15, 5]].Merge();
                //    xlRange = worksheet.Cells[rowsNumber + 6, 2];
                //    float left = (float)((double)xlRange.Left);
                //    float top = (float)((double)xlRange.Top);
                //    worksheet.Shapes.AddPicture(target, MsoTriState.msoFalse, MsoTriState.msoCTrue, left, top, xlRange.Width * 10, xlRange.Height * 15);
                //    this.deleteFile(target);
                //}
                workbook.SaveAs(fileName, misValue, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                this.objectRelease(worksheet);
                workbook.Close(true, misValue, misValue);
                app.Quit();
                this.objectRelease(workbook);
                this.objectRelease(app);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error writing in Excel file!  " + exception.ToString());
            }
        }


        protected override void openFile(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Workbook wb = excel.Workbooks.Open(fileName);
        }

        private void objectRelease(object obj)
        {
            try
            {
                Marshal.FinalReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
