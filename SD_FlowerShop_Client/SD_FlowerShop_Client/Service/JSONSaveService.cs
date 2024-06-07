using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SD_FlowerShop_Server.Domain;
using System.Drawing;
using System.Xml;


namespace SD_FlowerShop_Client.Service
{
    public class JSONSaveService: FileSaveService
    {
        public JSONSaveService()
        {
            this.extension = ".json";
            this.fileType = "JSON files (*.json)|*.json";
        }

        protected override void save(List<Flower> flowerList, string figureTitle, string fileName)
        {
            try
            {
                // Serialize the car list to JSON
                string json = JsonConvert.SerializeObject(flowerList, Newtonsoft.Json.Formatting.Indented);

                // Write the JSON to a file
                File.WriteAllText(fileName, json);

                // Optionally, handle the chart image if needed (e.g., save it alongside the JSON file)
                //string imagePath = Path.ChangeExtension(fileName, ".jpg");
                //SaveChartImage(chartImage, imagePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error writing in the JSON file! " + exception.ToString());
            }
        }

        protected override void openFile(string fileName)
        {
            try
            {
                // Open the JSON file with the default application
                Process.Start(new ProcessStartInfo
                {
                    FileName = fileName,
                    UseShellExecute = true
                });
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error opening the JSON file! " + exception.ToString());
            }
        }

        //private void SaveChartImage(MemoryStream chartImage, string imagePath)
        //{
        //    try
        //    {
        //        // Save the chart image as a JPEG file
        //        using (Image image = Image.FromStream(chartImage))
        //        {
        //            image.Save(imagePath, ImageFormat.Jpeg);
        //        }
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show("Error saving the chart image! " + exception.ToString());
        //    }
        //}
    }
}

