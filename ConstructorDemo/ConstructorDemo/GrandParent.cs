using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorDemo
{
    internal class GrandParent
    {
        private string surName;

        public string SurName {  get { return surName; } }

        public GrandParent(string surName)
        {
            this.surName = surName;
        }
    }
}
