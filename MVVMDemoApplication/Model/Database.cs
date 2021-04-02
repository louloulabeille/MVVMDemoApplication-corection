using System.Collections.Generic;

namespace MVVMDemoApplication.Model
{
    public class Database
    {
        private readonly List<Person> persons;

        public Database()
        {
            this.persons = new List<Person>();

            this.persons.Add(new Person
             {
                 FirstName = "Jeremy",
                 LastName = "Alles",
                 Age = 23,
                 Gender = Gender.Male
             });

            this.persons.Add(new Person
            {
                FirstName = "Karine",
                LastName = "Martin",
                Age = 22,
                Gender = Gender.Female
            });

            this.persons.Add(new Person
            {
                FirstName = "Adam",
                LastName = "Phesa",
                Age = 38,
                Gender = Gender.Female
            });
        }

        public List<Person> Persons
        {
            get { return this.persons; }
        }

        public Person AddPerson(string firstname, string lastname, int age, Gender gender)
        {
            Person newPerson = new Person
                                 {
                                     FirstName = firstname,
                                     LastName = lastname,
                                     Age = age,
                                     Gender = gender
                                 };

            this.persons.Add(newPerson);
            return newPerson;
        }

        public void RemovePerson(Person person)
        {
            this.persons.Remove(person);
        }
    }
}
