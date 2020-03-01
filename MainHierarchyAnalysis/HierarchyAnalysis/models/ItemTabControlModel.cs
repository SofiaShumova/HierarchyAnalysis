using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HierarchyAnalysis.buildingHierarchy
{
    public class ItemTabControlModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private bool isEnabledItem;
        public UserControl Page { set; get; }
        public bool IsEnabledItem 
        {
            set
            {
                isEnabledItem = value;
                OnPropertyChanged("IsEnabledItem");
            }
            get
            {
                return isEnabledItem;
            } 
        }

        public ItemTabControlModel(UserControl page, bool state, object sender)
        {
            Page = page;
            IsEnabledItem = state;
            Page.DataContext = sender;
        }
        public ItemTabControlModel()
        {

        }
    }
}
