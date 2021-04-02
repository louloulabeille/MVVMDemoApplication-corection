using System;
using MVVMDemoApplication.Model;

namespace MVVMDemoApplication.ViewModel
{
    public class PersonViewModel : ViewModelBase
    {
        private readonly Person person;
        
        public string FirstName
        {
            get
            {
                return this.person.FirstName;
            }
            set
            {
                this.person.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return this.person.LastName;
            }
            set
            {
                this.person.LastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public bool IsMale
        {
            get
            {
                return this.person.Gender == Gender.Male;
            }
            set
            {
                if (value)
                    this.person.Gender = Gender.Male;
                else
                    this.person.Gender = Gender.Female;

                OnPropertyChanged("IsMale");
                OnPropertyChanged("IsFemale");
            }
        }

        public bool IsFemale
        {
            get
            {
                return this.person.Gender == Gender.Female;
            }
            set
            {
                if (value)
                    this.person.Gender = Gender.Female;
                else
                    this.person.Gender = Gender.Male;

                OnPropertyChanged("IsFemale");
                OnPropertyChanged("IsMale");
            }
        }

        public int Age
        {
            get
            {
                return this.person.Age;
            }
            set
            {
                this.person.Age = value;
                OnPropertyChanged("FirstName");
            }
        }

        public Person Person
        {
            get
            {
                return this.person;
            }
        }

        public PersonViewModel(Person person)
        {
            if(person == null)
                throw new NullReferenceException("person");

            this.person = person;
        }
    }
}
