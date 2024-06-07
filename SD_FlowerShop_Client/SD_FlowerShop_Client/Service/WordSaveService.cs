using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SD_FlowerShop_Server.Domain;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace SD_FlowerShop_Client.Service
{
    public class WordSaveService: FileSaveService
    {
        public WordSaveService()
        {
            this.extension = ".docx";
            this.fileType = "Word File (.docx ,.doc)|*.docx";
        }
        protected override void save(List<Flower> flowerList, string figureTitle, string fileName)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
                application.Visible = false;
                Document document = application.Documents.Add();
                document.PageSetup.TopMargin = (float)50;
                document.PageSetup.BottomMargin = (float)50;
                document.PageSetup.RightMargin = (float)50;
                document.PageSetup.LeftMargin = (float)50;
                foreach (Section wordSection in document.Sections)
                {
                    HeaderFooter ftr = wordSection.Footers[WdHeaderFooterIndex.wdHeaderFooterPrimary];
                    ftr.PageNumbers.RestartNumberingAtSection = false;
                    ftr.PageNumbers.StartingNumber = 1;
                    Range footerRange = ftr.Range;
                    footerRange.Font.ColorIndex = WdColorIndex.wdDarkRed;
                    footerRange.Font.Size = 10;
                    object CurrentPage = WdFieldType.wdFieldPage;
                    string additionalFooter = " / " + DateTime.Today.Day;
                    additionalFooter += ":" + DateTime.Today.Month + ":" + DateTime.Today.Year;
                    footerRange.Fields.Add(footerRange, ref CurrentPage);
                    footerRange.InsertAfter(additionalFooter);
                    footerRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                }
                object missing = System.Reflection.Missing.Value;
                Paragraph paragraph = document.Content.Paragraphs.Add(ref missing);
                paragraph.Range.Font.Size = 40;
                paragraph.Range.Text = "Employees List" + Environment.NewLine;
                paragraph.Range.InsertParagraphAfter();
                paragraph.Range.Font.Size = 14;
                int rowsNumber = flowerList.Count + 1;
                Table table = document.Tables.Add(paragraph.Range, rowsNumber, 5, missing, missing);
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Columns[1].PreferredWidth = 70;
                table.Columns[2].PreferredWidth = 150;
                table.Columns[3].PreferredWidth = 60;
                table.Columns[4].PreferredWidth = 80;
                table.Columns[5].PreferredWidth = 110;
                for (int j = 1; j <= 5; j++)
                {
                    table.Cell(1, j).Range.Font.Bold = 1;
                    table.Cell(1, j).Range.Font.Size = 12;
                }
                table.Cell(1, 1).Range.Text = "FlowerID";
                table.Cell(1, 2).Range.Text = "ShopID";
                table.Cell(1, 3).Range.Text = "FlowerName";
                table.Cell(1, 4).Range.Text = "Color";
                table.Cell(1, 5).Range.Text = "Price";
                table.Cell(1, 6).Range.Text = "Stock";
                table.Rows.SetHeight(14, WdRowHeightRule.wdRowHeightExactly);
                table.Rows[1].HeadingFormat = -1;
                for (int i = 2; i <= rowsNumber; i++)
                {
                    for (int j = 1; j <= 5; j++)
                    {
                        table.Cell(i, j).Range.Font.Size = 12;
                        table.Cell(i, j).Range.Font.Name = "Calibri";
                    }
                    table.Cell(i, 1).Range.Text = flowerList[i - 2].FlowerID.ToString();
                    table.Cell(i, 2).Range.Text = flowerList[i - 2].ShopID.ToString();
                    table.Cell(i, 3).Range.Text = flowerList[i - 2].FlowerName;
                    table.Cell(i, 4).Range.Text = flowerList[i - 2].Color;
                    table.Cell(i, 5).Range.Text = flowerList[i - 2].Price.ToString();
                    table.Cell(i, 6).Range.Text = flowerList[i - 2].Stock.ToString();
                }
                paragraph.Range.Text = Environment.NewLine;
                paragraph.Range.Text = Environment.NewLine;
                paragraph.Range.InlineShapes.AddHorizontalLineStandard();
                //string target = this.createImage(chartImage);
                //if (target != null && target != "")
                //{
                //    paragraph.Range.InlineShapes.AddPicture(target);
                //    paragraph.Range.InsertParagraphAfter();
                //    paragraph.Range.Text = "Figure: " + figureTitle;
                //    paragraph.Range.Font.Size = 14;
                //    paragraph.Range.InsertParagraphAfter();
                //    this.deleteFile(target);
                //}
                paragraph.Range.InlineShapes.AddHorizontalLineStandard();
                document.SaveAs2(fileName);
                document.Close();
                application.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
                //
                //if (target != null && target != "")
                //File.Delete(target);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error writing in Word file!  " + exception.ToString());
            }
        }

        protected override void openFile(string fileName)
        {
            System.Diagnostics.Process.Start(fileName);
        }
    }
}
