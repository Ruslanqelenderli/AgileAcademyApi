namespace Lesson_4.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public double Balance { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
