namespace MVVMDemoApplication.Model
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        private string firstname;
        private string lastname;
        private int age;
        private Gender gender;

        public string FirstName
        {
            get { return this.firstname; }
            set { this.firstname = value; }
        }

        public string LastName
        {
            get { return this.lastname; }
            set { this.lastname = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public Gender Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }
    }
}
