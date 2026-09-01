using System.ComponentModel.DataAnnotations;

namespace LibraryWebAPI.Models;

public class Book
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; } = String.Empty;
    
    [MaxLength(100)]
    public string Author { get; set; } = String.Empty;
    public bool IsCheckedOut { get; set; }
}