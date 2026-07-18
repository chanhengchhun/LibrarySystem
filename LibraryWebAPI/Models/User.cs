namespace LibraryWebAPI.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty; // Only for testing purposes now.
}