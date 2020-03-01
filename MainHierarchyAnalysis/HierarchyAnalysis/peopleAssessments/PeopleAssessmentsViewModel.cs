
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using HierarchyAnalysis.buildingHierarchy;
using HierarchyAnalysis.peopleAssessments.pages;
using HierarchyAnalysis.peopleAssessments.models;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using HierarchyAnalysis.mathPart;

namespace HierarchyAnalysis.peopleAssessments
{
    public class PeopleAssessmentsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ItemTabControlModel> Pages { set; get; }
        public ObservableCollection<AssessmentPeople> Assessments { set; get; }
        public ObservableCollection<Person> People { set; get; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public delegate void PeopleHandler(ObservableCollection<AssessmentPeople> assessments);
        public event PeopleHandler Notify;
        public Person CurrentPerson { set; get; }
        public int IndexPerson { set; get; }

        public bool EnabledPrevious { set; get; }
        public bool EnabledNext { set; get; }
        public int IndexMain { set; get; } 

        public PeopleAssessmentsViewModel(ObservableCollection<Person> people)
        {
            People = people;
            Pages = new ObservableCollection<ItemTabControlModel>
            {
                new ItemTabControlModel(new assessmentsPage(),true,this),
                new ItemTabControlModel(new selectCriterionForPerson(), false, this)
            };
            Assessments = GenerateArrayAssessments(people);
            
            IndexMain = 0;
            IndexPerson = 0;

            SpotCurrentPerson(IndexPerson);
            SpotEnabled();

            

        }
        private void SpotCurrentPerson(int index)
        {
            CurrentPerson = People[index];
        }
        private void SpotEnabled()
        {
            if (IndexPerson == 0)
            {
                EnabledPrevious = false;
                EnabledNext = true;
            }
            else if (IndexPerson == People.Count - 1)
            {
                EnabledNext = false;
                EnabledPrevious = true;
            }
            else
            {
                EnabledNext = true;
                EnabledPrevious = true;
            }
        }
        public ICommand NextPerson
        {
            get
            {
                return new RelayCommand(() =>
                {
                    IndexPerson++;
                    SpotEnabled();
                    SpotCurrentPerson(IndexPerson);
                });
            }
        }
        public ICommand PreviousPerson
        {
            get
            {
                return new RelayCommand(() =>
                {
                    IndexPerson--;
                    SpotEnabled();
                    SpotCurrentPerson(IndexPerson);
                });
            }
        }
        public ICommand CompleteAssessment
        {
            get
            {
                return new RelayCommand(() => 
                {
                    IndexMain++;
                    Pages[1].IsEnabledItem = true;
                });
            }
        }
        public ICommand CompletePeopleCheck
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Notify(Assessments);
                });
            }
        }
        private ObservableCollection<AssessmentPeople> GenerateArrayAssessments(ObservableCollection<Person> people)
        {
            ObservableCollection<AssessmentPeople> assessments = new ObservableCollection<AssessmentPeople>();
            assessments.Add(new AssessmentPeople(people[0], people[1]));
            bool state;
            for(int i =0; i<people.Count; i++)
            {
                for(int j=0; j<people.Count; j++)
                {
                    if (i == j) break;
                    state = false;
                    for (int k = 0; k < assessments.Count; k++)
                    {
                        if(!(((assessments[k].firstPerson.ID==people[i].ID) &&(assessments[k].secondPerson.ID == people[j].ID)) ||
                                ((assessments[k].firstPerson.ID == people[j].ID) && (assessments[k].secondPerson.ID == people[i].ID))))
                        {
                            state = true;
                        }
                    }
                    if(state) assessments.Add(new AssessmentPeople(people[i], people[j])); ;
                }
            }
            return assessments;
        }
       
    }
}
