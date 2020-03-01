
using System.ComponentModel;
using HierarchyAnalysis.Models;
using System.Windows.Controls;
using HierarchyAnalysis.buildingHierarchy;

namespace HierarchyAnalysis
{
    using GalaSoft.MvvmLight.Command;
    using HierarchyAnalysis.alternativeAssessments;
    using HierarchyAnalysis.alternativeAssessments.models;
    using HierarchyAnalysis.criterionAssessments;
    using HierarchyAnalysis.criterionAssessments.models;
    using HierarchyAnalysis.mathPart;
    using HierarchyAnalysis.peopleAssessments;
    using HierarchyAnalysis.peopleAssessments.models;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public ObservableCollection<ItemMainMenu> items { get; set; }

        private BuildingViewModel buildingVM { set; get; }
        private PeopleAssessmentsViewModel peopleVM { set; get; }
        private CriterionAssessmentsViewModel criterionVM { set; get; }
        private AlterantiveAssessmentsViewModel alternativeVM { set; get; }
        MathResult mathResult;

        private UserControl currentPage;

        private UserControl buildingPage;
        private UserControl peoplePage;
        private UserControl criterionPage;
        private UserControl alternativePage;

        private UserControl homePage;
        private bool enabledMenu;
        private int selectedIndexMenu;


        public UserControl CurrentPage {
            set
            {
                if (currentPage == value)
                    return;
                currentPage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(currentPage)));
            }
            get
            {
                return currentPage;
            }
        }
        public bool EnabledMenu
        {
            set
            {
                if (enabledMenu == value)
                    return;
                enabledMenu = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(enabledMenu)));
            }
            get
            {
                return enabledMenu;
            }
        }
        public int SelectedIndexMenu
        {
            set
            {
                if (selectedIndexMenu == value)
                    return;
                selectedIndexMenu = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedIndexMenu)));
            }
            get
            {
                return selectedIndexMenu;
            }
        }


        public MainViewModel()
        {
            items = new ObservableCollection<ItemMainMenu> {
                new ItemMainMenu("./img/rect.png", false, DisplayBuildingPage),
                new ItemMainMenu("./img/people.png", false, DisplayPeoplePage),
                new ItemMainMenu("./img/star.png", false, DisplayCriterionPage),
                new ItemMainMenu("./img/note.png", false, DisplayAlternativePage),
                new ItemMainMenu("./img/checkmark.png", false, DisplayPeoplePage),
            };

          

            homePage = new HomePage();
            buildingPage = new BuildingHierarchyPage();
            peoplePage = new PeopleAssessmentsPage();
            criterionPage = new CriterionAssessmentsPage();
            alternativePage = new AlternativeAssessmentsPage();

            buildingVM = new BuildingViewModel();
            buildingPage.DataContext = buildingVM;
            buildingVM.Notify += GetFullInfo;

            mathResult = new MathResult();

            EnabledMenu = false;
            SelectedIndexMenu = -1;
            CurrentPage = homePage;

            
           
        }
        private void AddAllCriterionsForPeople(ref ObservableCollection<Person> people, ObservableCollection<Criterion> criterions)
        {
            foreach(Person i in people)
            {
                foreach(Criterion j in criterions)
                {
                    i.Criterions.Add(new MultiCriterion(j));
                }
            }
        }
        private void GetFullInfo(string name,ObservableCollection<Person> people, ObservableCollection<Criterion> criterions, ObservableCollection<Alternative> alternatives)
        {
            
            items[0].ImagePath = "./img/selected rect.png";
            SelectedIndexMenu++;
            items[1].IsEnabledItem = true;

            AddAllCriterionsForPeople(ref people, criterions);
            peopleVM = new PeopleAssessmentsViewModel(people);
            peoplePage.DataContext = peopleVM;
            peopleVM.Notify += GetPersonAssessments;

            peopleVM.IndexMain = 0;
            CurrentPage = peoplePage;
        }

        private void GetPersonAssessments(ObservableCollection<AssessmentPeople> assessments)
        {
            mathResult.People = buildingVM.Persons;
            mathResult.AssessmentPeople = assessments;
            

            criterionVM = new CriterionAssessmentsViewModel(buildingVM.Persons);
            criterionPage.DataContext = criterionVM;
            criterionVM.Notify += GetCriterionAssessments;

            items[1].ImagePath = "./img/selected people.png";
            SelectedIndexMenu++;
            items[2].IsEnabledItem = true;

            CurrentPage = criterionPage;
        }
        private void GetCriterionAssessments(ObservableCollection<AssessmentPeopleCriterion> peopleCriteria)
        {
            mathResult.PeopleCriteria = peopleCriteria;
            mathResult.Criteria = buildingVM.Criterions;

            alternativeVM = new AlterantiveAssessmentsViewModel(buildingVM.Criterions, buildingVM.Alternatives);
            alternativePage.DataContext = alternativeVM;
            alternativeVM.Notify += GetAlternativesAssessments;

            items[2].ImagePath = "./img/selected star.png";
            SelectedIndexMenu++;
            items[3].IsEnabledItem = true;

            CurrentPage = alternativePage;

        }

        private void GetAlternativesAssessments(ObservableCollection<CriterionAlternativeAssessment> assessments)
        {
            mathResult.CriterionAlternatives = assessments;
            mathResult.Alternatives = buildingVM.Alternatives;

            exampleResult page =  new exampleResult();
            ResultExampleViewModel vm = new ResultExampleViewModel(mathResult.priopityPeople(), mathResult.priorityCriterion(), mathResult.priorityAlternatives());
            page.DataContext = vm;
            CurrentPage = page;




        }
        public ICommand Test
        {
            get
            {
                return new RelayCommand(() =>
                {
                    startAnalysis();
                    buildingVM.Name = "сценарий";
                    buildingVM.getName();
                    buildingVM.Persons =new ObservableCollection<Person>{ new Person("отрасль промышленности"),new Person("отрасли потребители"),new Person("гос органы")};
                    buildingVM.completePersons();
                    buildingVM.Criterions = new ObservableCollection<Criterion> { new Criterion("прибыль"), new Criterion("цена"), new Criterion("сроки"), new Criterion("налог"), new Criterion("рабочие места") };
                    buildingVM.completeCriterions();
                    buildingVM.Alternatives = new ObservableCollection<Alternative> { new Alternative("импорт продукции"), new Alternative("создание производства"), new Alternative("развитие полного цикла пр-ва") };
                    buildingVM.completeAlternatives();

                });
            }
        }
        private void startAnalysis()
        {
            EnabledMenu = true;
            CurrentPage = buildingPage;
            SelectedIndexMenu = 0;
            items[SelectedIndexMenu].IsEnabledItem = true;
        }
        private void displayBuildingPage()
        {
            CurrentPage = buildingPage;
            SelectedIndexMenu = 0;
        }
        private void displayPeoplePage()
        {
            peopleVM.IndexMain = 0;
            CurrentPage = peoplePage;
            SelectedIndexMenu = 1;
        }
        private void displayCriterionPage()
        {
            CurrentPage = criterionPage;
            SelectedIndexMenu = 2;
        }
        private void displayAlternativePage()
        {
            CurrentPage = alternativePage;
            SelectedIndexMenu = 3;
        }

        public ICommand StartAnalysis
        {
            get
            {
                return new RelayCommand(() => startAnalysis());
            }
        }
        public ICommand DisplayCriterionPage
        {
            get
            {
                return new RelayCommand(() => displayCriterionPage());
            }
        }
        public ICommand DisplayBuildingPage
        {
            get
            {
                return new RelayCommand(() => displayBuildingPage());
            }
        }
        public ICommand DisplayPeoplePage
        {
            get
            {
                return new RelayCommand(() => displayPeoplePage());
            }
        }
        public ICommand DisplayAlternativePage
        {
            get
            {
                return new RelayCommand(() => displayAlternativePage());
            }
        }
    }
    
    
}

