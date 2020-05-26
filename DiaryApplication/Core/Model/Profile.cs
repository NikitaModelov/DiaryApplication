namespace DiaryApplication.Core.Model
{
    public class Profile
    {
        public int Id { get; }
        public string FirstName { get; }
        public string SecondName { get; }

        public Profile(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
        }
        public Profile(int id, string firstName, string secondName)
        {
            Id = id;
            FirstName = firstName;
            SecondName = secondName;
        }
        public override string ToString()
        {
            return $"{FirstName} {SecondName}";
        }
    }
}
