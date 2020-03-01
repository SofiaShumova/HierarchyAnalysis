using HierarchyAnalysis.buildingHierarchy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyAnalysis.alternativeAssessments.models
{
    public class AlternativeAssessment
    {
        public Alternative firstAlternative { set; get; }
        public Alternative secondAlternative { set; get; }

        public double Assessment { set; get; }

        public AlternativeAssessment(Alternative first, Alternative second)
        {
            firstAlternative = first;
            secondAlternative = second;
        }

    }

    public class CriterionAlternativeAssessment:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Criterion Criterion { set; get; }
        public ObservableCollection<AlternativeAssessment> AlternativeAssessments { set; get; }

        bool _state;

        public bool IsEnabledItem
        {
            set
            {
                _state = value;
                OnPropertyChanged("IsEnabledItem");
            }
            get
            {
                return _state;
            }
        }
        public CriterionAlternativeAssessment(Criterion criterion, ObservableCollection<AlternativeAssessment> assessments)
        {
            Criterion = criterion;
            AlternativeAssessments = assessments;
            IsEnabledItem = false;
        }

    }
}
