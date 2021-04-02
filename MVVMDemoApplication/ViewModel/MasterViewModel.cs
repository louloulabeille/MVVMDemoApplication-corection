using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using MVVMDemoApplication.Model;

namespace MVVMDemoApplication.ViewModel
{
    public class MasterViewModel : ViewModelBase
    {
        #region fields
        private readonly Database db;
        private readonly ObservableCollection<PersonViewModel> persons;
        private readonly ICollectionView collectionView;
        private ICommand addCommand;
        private ICommand removeCommand;
        private ICommand previousCommand;
        private ICommand nextCommand;
        #endregion

        public MasterViewModel(Database db)
        {
            this.db = db;
            this.persons = new ObservableCollection<PersonViewModel>();

            foreach (Person person in this.db.Persons)
            {
                this.persons.Add(new PersonViewModel(person));
            }

            this.collectionView = CollectionViewSource.GetDefaultView(this.persons);
            if(this.collectionView == null)
                throw new NullReferenceException("collectionView");

            this.collectionView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChanged);
        }

        #region properties
        public ObservableCollection<PersonViewModel> Persons
        {
            get { return this.persons; }
        }

        public PersonViewModel SelectedPerson
        {
            get { return this.collectionView.CurrentItem as PersonViewModel; }
        }

        public string SearchText
        {
            set
            {
                this.collectionView.Filter = (item) =>
                 {
                     if (item as PersonViewModel == null)
                         return false;

                     PersonViewModel personViewModel = (PersonViewModel) item;
                     if (personViewModel.FirstName.Contains(value) ||
                         personViewModel.LastName.Contains(value))
                         return true;

                     return false;
                 };

                this.OnPropertyChanged("SearchContainsNoMatch");
            }
        }

        public bool SearchContainsNoMatch
        {
            get
            {
                return this.collectionView.IsEmpty;
            }
        }

        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand == null)
                    this.addCommand = new RelayCommand(() => this.AddPerson(), () => this.CanAddPerson());

                return this.addCommand;
            }
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (this.removeCommand == null)
                    this.removeCommand = new RelayCommand(() => this.RemovePerson(),() => this.CanRemovePerson());

                return this.removeCommand;
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                if (this.previousCommand == null)
                    this.previousCommand = new RelayCommand(() => this.GoPrevious(), () => this.CanGoPrevious());

                return this.previousCommand;
            }
        }

        public ICommand NextCommand
        {
            get
            {
                if (this.nextCommand == null)
                    this.nextCommand = new RelayCommand(() => this.GoNext(), () => this.CanGoNext());

                return this.nextCommand;
            }            
        }

        #endregion

        private bool CanAddPerson()
        {
            return this.persons.Count < 5;
        }

        private void AddPerson()
        {
            Person newPerson = this.db.AddPerson("firstName", "lastName", 25, Gender.Female);
            this.persons.Add(new PersonViewModel(newPerson));
        }

        private bool CanRemovePerson()
        {
            return this.SelectedPerson != null;
        }

        private void RemovePerson()
        {
            this.db.RemovePerson(this.SelectedPerson.Person);
            this.persons.Remove(this.SelectedPerson);
        }

        private bool CanGoPrevious()
        {
            return this.collectionView.CurrentPosition >= 1;
        }

        private void GoPrevious()
        {
            this.collectionView.MoveCurrentToPrevious();
        }

        private bool CanGoNext()
        {
            return this.collectionView.CurrentPosition < this.persons.Count - 1;
        }

        private void GoNext()
        {
            this.collectionView.MoveCurrentToNext();
        }

        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SelectedPerson");
        }
    }
}
