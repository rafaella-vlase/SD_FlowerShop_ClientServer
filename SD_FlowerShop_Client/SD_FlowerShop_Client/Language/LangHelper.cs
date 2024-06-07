using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Client.Language
{
    public class LangHelper : Subject
    {
        private static ResourceManager rm;

        public LangHelper()
        {
            this.obsList = new List<Observable>();
            rm = new ResourceManager("SD_FlowerShop_Client.Language.string", Assembly.GetExecutingAssembly());
        }

        public string GetString(string name)
        {
            return rm.GetString(name);
        }

        public void ChangeLanguage(string language)
        {
            var cultureInfo = new CultureInfo(language);

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            this.Notify();
        }
    }
}
