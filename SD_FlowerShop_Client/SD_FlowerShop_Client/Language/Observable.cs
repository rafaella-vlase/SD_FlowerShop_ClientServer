using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_FlowerShop.Model
{
    public interface Observable
    {
        void Update(Subject obs);
    }
}
