using HierarchyAnalysis.buildingHierarchy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HierarchyAnalysis.criterionAssessments.models
{
    public class AssessmentCriterion
    {
        public Criterion firstCriterion { set; get; }
        public Criterion secondCriterion { set; get; }
        public double Assessment { set; get; }
        public AssessmentCriterion(Criterion criterion1, Criterion criterion2)
        {
            firstCriterion = criterion1;
            secondCriterion = criterion2;
        }
    }

    public class AssessmentPeopleCriterion: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public Person Person{set;get;}
        public ObservableCollection<AssessmentCriterion> assessmentCriteria { set; get; }
        bool _state;
        public bool IsEnabledItem {
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
        public AssessmentPeopleCriterion(Person p, ObservableCollection<AssessmentCriterion> assessment, bool state)
        {
            Person = p;
            assessmentCriteria = assessment;
            IsEnabledItem = state;

        }
    }
}
