using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyAnalysis.buildingHierarchy
{
    public class Alternative
    {
        public int ID
        {
            private set;
            get;
        }
        public String Name { set; get; }
        public Alternative(string name)
        {
            ID = base.GetHashCode();
            Name = name;
        }
        public Alternative()
        {
            ID = base.GetHashCode();
        }
    }
}
