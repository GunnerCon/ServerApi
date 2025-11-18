namespace ServerApi.DTOs
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status {  get; set; } = string.Empty;
    }

    public class CreateAccountDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class UpdateAccountDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}