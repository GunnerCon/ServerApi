namespace ServerApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // Admin or User
        public string Status { get; set; } = "Active"; //Active or NonActive
    }
}