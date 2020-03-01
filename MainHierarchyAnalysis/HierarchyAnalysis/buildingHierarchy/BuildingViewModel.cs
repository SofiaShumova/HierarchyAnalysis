using System;
using System.ComponentModel;


namespace HierarchyAnalysis.buildingHierarchy
{
    using GalaSoft.MvvmLight.Command;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Input;
    public class BuildingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public delegate void BuildingHandler(string name, ObservableCollection<Person> people, ObservableCollection<Criterion> criterions, ObservableCollection<Alternative> alternatives);
        public event BuildingHandler Notify;

        public string Name { set; get; }
        public ObservableCollection<Person> Persons { get; set; }
        public ObservableCollection<Criterion> Criterions { get; set; }
        public ObservableCollection<Alternative> Alternatives { get; set; }

        public ObservableCollection<ItemTabControlModel> Pages { set; get; }
        public int IndexMain { set; get; } = 0;

        public BuildingViewModel()
        {
            Persons = new ObservableCollection<Person>
            {
                new Person(), new Person()
            };
            Criterions = new ObservableCollection<Criterion>
            {
                new Criterion(), new Criterion()
            };
            Alternatives = new ObservableCollection<Alternative>
            {
                new Alternative(), new Alternative()
            };

            Pages = new ObservableCollection<ItemTabControlModel>
            {
                new ItemTabControlModel(new namePage(), true, this),
                new ItemTabControlModel(new personsPage(), false, this),
                new ItemTabControlModel(new criterionsPage(), false, this),
                new ItemTabControlModel(new alternativesPage(), false, this),

            };

            IndexMain = 0;
        }

        public void NextAction()
        {
            Pages[IndexMain + 1].IsEnabledItem = true;
            IndexMain++;
        }
        public void CompleteHierarchy()
        {
            CleanAlternatives();
            CleanCriterions();
            CleanPersons();
            if(Persons.Count<2 || Criterions.Count<2 || Alternatives.Count<2 || String.IsNullOrEmpty(Name))
            {
                MessageBox.Show("Данных недостаточно!");
            }
            else
            {
                Notify(Name,Persons, Criterions,Alternatives);
                IndexMain = 0;
            }
        }

        private void CleanPersons()
        {
            for (int i = 0; i < Persons.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(Persons[i].Name))
                {
                    Persons.Remove(Persons[i]);
                }
            }
        }
        private void CleanCriterions()
        {
            for (int i = 0; i < Criterions.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(Criterions[i].Name))
                {
                    Criterions.Remove(Criterions[i]);
                }
            }
        }
        private void CleanAlternatives()
        {
            for (int i = 0; i < Alternatives.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(Alternatives[i].Name))
                {
                    Alternatives.Remove(Alternatives[i]);
                }
            }
        }

        public ICommand GetName
        {
            get
            {
                return new RelayCommand(() =>getName());
            }
        }
        public ICommand CompletePersons
        {
            get
            {
                return new RelayCommand(() =>completePersons());
            }
        }
        public ICommand CompleteCriterions
        {
            get
            {
                return new RelayCommand(() =>completeCriterions());
            }
        }
        public ICommand CompleteAlternatives
        {
            get
            {
                return new RelayCommand(() =>completeAlternatives());
            }
        }
        public ICommand AddPerson
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Persons.Add(new Person());

                });
            }
        }
        public ICommand AddCriterion
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Criterions.Add(new Criterion());

                });
            }
        }
        public ICommand AddAlternative
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Alternatives.Add(new Alternative());

                });
            }
        }

        public void getName()
        {
            if (String.IsNullOrWhiteSpace(Name))
                MessageBox.Show("Некорректный ввод!");
            else NextAction();
        }
        public void completePersons()
        {
            CleanPersons();
            if (Persons.Count < 2)
                MessageBox.Show("Недостаточно сторон!");
            else NextAction();
        }
        public void completeCriterions()
        {
            CleanCriterions();
            if (Criterions.Count < 2)
                MessageBox.Show("Недостаточно критериев!");
            else NextAction();
        }
        public void completeAlternatives()
        {
            CleanAlternatives();
            if (Alternatives.Count < 2)
                MessageBox.Show("Недостаточно альтернатив!");
            else CompleteHierarchy();
        }

    }
}
