namespace Database
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Login { get; set; }
        public required string FullName { get; set; }
        public required string PasswordHash { get; set; }
    }
}
