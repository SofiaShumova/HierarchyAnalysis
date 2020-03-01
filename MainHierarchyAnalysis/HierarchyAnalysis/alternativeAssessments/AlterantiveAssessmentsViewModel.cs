using GalaSoft.MvvmLight.Command;
using HierarchyAnalysis.alternativeAssessments.models;
using HierarchyAnalysis.buildingHierarchy;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HierarchyAnalysis.alternativeAssessments
{
    public class AlterantiveAssessmentsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public delegate void AlternativeHandler(ObservableCollection<CriterionAlternativeAssessment> assessments);
        public event AlternativeHandler Notify;

        public ObservableCollection<CriterionAlternativeAssessment> Assessments { set; get; }

        public int IndexMain { set; get; }

        public AlterantiveAssessmentsViewModel(ObservableCollection<Criterion> criteria, ObservableCollection<Alternative> alternatives)
        {
            Assessments = assessments(criteria, alternatives);
        }

        private ObservableCollection<CriterionAlternativeAssessment> assessments(ObservableCollection<Criterion> criteria, ObservableCollection<Alternative> alternatives)
        {
            ObservableCollection<CriterionAlternativeAssessment> assessments = new ObservableCollection<CriterionAlternativeAssessment>();
            foreach (Criterion i in criteria)
            {
                assessments.Add(new CriterionAlternativeAssessment(i, assessmentAlternative(alternatives)));
            }
            assessments[0].IsEnabledItem = true;
            return assessments;          
        }
        private ObservableCollection<AlternativeAssessment> assessmentAlternative(ObservableCollection<Alternative> alternatives)
        {
            ObservableCollection<AlternativeAssessment> assessments = new ObservableCollection<AlternativeAssessment>();
            assessments.Add(new AlternativeAssessment(alternatives[0], alternatives[1]));
            bool state;
            for (int i = 0; i < alternatives.Count; i++)
            {
                for (int j = 0; j < alternatives.Count; j++)
                {
                    if (i == j) break;
                    state = false;
                    for (int k = 0; k < assessments.Count; k++)
                    {
                        if (!(((assessments[k].firstAlternative.ID == alternatives[i].ID) && (assessments[k].secondAlternative.ID == alternatives[j].ID)) ||
                                ((assessments[k].firstAlternative.ID == alternatives[j].ID) && (assessments[k].secondAlternative.ID == alternatives[i].ID))))
                        {
                            state = true;
                        }
                    }
                    if (state) assessments.Add(new AlternativeAssessment(alternatives[i], alternatives[j])); ;
                }
            }
            return assessments;
        }

        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(() => {
                    if (IndexMain == Assessments.Count - 1)
                    {
                        Notify(Assessments);
                        IndexMain = 0;
                        OnPropertyChanged("IndexMain");
                    }
                    else
                    {
                        IndexMain++;
                        Assessments[IndexMain].IsEnabledItem = true;
                        OnPropertyChanged("IndexMain");
                    }

                });
            }
        }

    }
}
