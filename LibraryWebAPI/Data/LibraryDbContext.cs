using Microsoft.EntityFrameworkCore;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) {}
    // Books is the collection of Book -- database table for Book.
    public DbSet<Book> Books => Set<Book>();
}