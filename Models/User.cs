namespace MiniStokTakipAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        
        public void SetPassword(string password)
        {
            
            Password = BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        // Şifre doğrulama metodu
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Password);
        }
    }
}
