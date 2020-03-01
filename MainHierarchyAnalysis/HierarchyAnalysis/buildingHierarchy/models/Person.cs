using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyAnalysis.buildingHierarchy
{
    public class Person
    {
        public int ID
        {
            private set;
            get;
        }
        public string Name { set; get; }
        public ObservableCollection<MultiCriterion> Criterions { set; get; }
        public Person(string name)
        {
            ID = base.GetHashCode();
            Name = name;
            Criterions = new ObservableCollection<MultiCriterion>();
        }
        public Person()
        {
            Criterions = new ObservableCollection<MultiCriterion>();
            ID = base.GetHashCode();
        }
    }
}
