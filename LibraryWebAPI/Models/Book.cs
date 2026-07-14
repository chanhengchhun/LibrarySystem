namespace LibraryWebAPI.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public bool IsAvailable { get; set; } = true;
    public int? CheckoutByUserId { get; set; } // null if not checked out.
    
}