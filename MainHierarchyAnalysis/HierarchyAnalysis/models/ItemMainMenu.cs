using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HierarchyAnalysis.Models
{
    public class ItemMainMenu: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        private bool isEnabledItem;
        private string imagePath;

        public bool IsEnabledItem
        {
            get
            {
                return isEnabledItem;
            }
            set
            {
                isEnabledItem = value;
                OnPropertyChanged("IsEnabledItem");
            }
        }
        public string ImagePath 
        {
            get
            {
                return imagePath;
            }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            } 
        }

        public ICommand Action { set; get; }

        public ItemMainMenu(String path, bool state, ICommand command)
        {
            ImagePath = path;
            IsEnabledItem = state;
            Action = command;
        }

    }
}
