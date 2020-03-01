using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyAnalysis.buildingHierarchy
{
    public class Criterion
    {
        public int ID
        {
            private set;
            get;
        }
        public String Name { set; get; }
        
        public Criterion(string name)
        {
            ID = base.GetHashCode();
            Name = name;
            //State = true;
        }
        public Criterion()
        {
            ID = base.GetHashCode();
            //State = true;
        }
        protected Criterion(Criterion criterion)
        {
            this.ID = criterion.ID;
            this.Name = criterion.Name;
        }
    }
    public class MultiCriterion : Criterion
    {
        public bool State { set; get; }
        public MultiCriterion(Criterion criterion):base(criterion)
        {
            State = true;
        }
    }
}
