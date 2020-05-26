namespace DiaryApplication.Core.Model
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public Profile(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }
        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}
