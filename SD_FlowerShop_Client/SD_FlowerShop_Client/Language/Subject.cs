using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD_FlowerShop_Client
{
    public abstract class Subject
    {
        protected List<Observable> obsList;

        public void Add(Observable obs)
        {
            this.obsList.Insert(0, obs);
            this.Notify();
        }

        public void Delete(Observable obs)
        {
            this.obsList.Remove(obs);
            this.Notify();
        }

        public void Notify()
        {
            foreach (Observable obs in this.obsList)
            {
                obs.Update(this);
            }
        }

        public List<Observable> ObsList
        {
            get { return this.obsList; }
            set { this.obsList = value; }
        }
    }
}
