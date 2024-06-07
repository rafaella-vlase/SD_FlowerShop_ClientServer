using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Client.Service
{
    public static class FileSaveServiceFactory
    {
        public enum FileType
        {
            Excel,
            Word,
            JSON,
            XML
        }

        public static FileSaveService CreateFileSaveService(FileType fileType)
        {
            switch (fileType)
            {
                case FileType.Excel:
                    return new ExcelSaveService();
                case FileType.Word:
                    return new WordSaveService();
                case FileType.JSON:
                    return new JSONSaveService();
                case FileType.XML:
                    return new XMLSaveService();
                default:
                    throw new NotSupportedException("File type not supported");
            }
        }
    }
}
