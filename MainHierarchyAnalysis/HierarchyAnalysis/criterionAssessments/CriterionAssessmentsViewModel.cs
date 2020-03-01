using GalaSoft.MvvmLight.Command;
using HierarchyAnalysis.buildingHierarchy;
using HierarchyAnalysis.criterionAssessments.models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace HierarchyAnalysis.criterionAssessments
{
   
    public class CriterionAssessmentsViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public int IndexMain { set; get; }
        public ObservableCollection<Person> People { set; get; }
        public ObservableCollection<AssessmentPeopleCriterion> PeopleCriteria { set; get; }
       
        public delegate void CriterionHandler(ObservableCollection<AssessmentPeopleCriterion> peopleCriteria);
        public event CriterionHandler Notify;

        public CriterionAssessmentsViewModel(ObservableCollection<Person> people)
        {
            People = people;
            PeopleCriteria = assessments(People);
            IndexMain = 0;
        }
        private ObservableCollection<AssessmentCriterion> criteria(Person person)
        {
            ObservableCollection<AssessmentCriterion> criteria = new ObservableCollection<AssessmentCriterion>();
            int countCriterionsTrue = 0;
            for (int j = 0; j < person.Criterions.Count; j++)
            {
                if (person.Criterions[j].State == true) countCriterionsTrue++;
            }
            if (countCriterionsTrue == 1)
            {
                return criteria;
            }

            bool state;
            for(int i =0; i<person.Criterions.Count; i++)
            {
                for (int j = 0; j < person.Criterions.Count; j++)
                {
                    if (i == j) break;
                    state = true;
                    if (person.Criterions[i].State == false || person.Criterions[j].State == false) state = false ;
                    
                    if (state) criteria.Add(new AssessmentCriterion(person.Criterions[i], person.Criterions[j])); ;

                }
            }
            return criteria;
        }
        private ObservableCollection<AssessmentPeopleCriterion> assessments(ObservableCollection<Person> people)
        {
            ObservableCollection<AssessmentPeopleCriterion> assessments = new ObservableCollection<AssessmentPeopleCriterion>();
            foreach(Person i in people)
            {
                assessments.Add(new AssessmentPeopleCriterion(i, criteria(i), false)); ;
            }
            assessments[0].IsEnabledItem = true;
            return assessments;
        }

        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(() =>{
                    if (IndexMain == People.Count - 1)
                    {
                        Notify(PeopleCriteria);
                        IndexMain = 0;
                        OnPropertyChanged("IndexMain");
                    }
                    else
                    {
                        
                        IndexMain++;
                        PeopleCriteria[IndexMain].IsEnabledItem = true;

                        OnPropertyChanged("IndexMain");
                    }
                    
                });
            }
        }
        private void CleanCriterion()
        {
            foreach (Person i in People)
            {
                for (int j = 0; j < i.Criterions.Count; j++)
                {
                    if (!i.Criterions[j].State)
                    {
                        i.Criterions.Remove(i.Criterions[j]);
                    }
                }
            }
        }


    }
}
