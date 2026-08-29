using Microsoft.EntityFrameworkCore;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.Data;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) {}
    public DbSet<Book> Books => Set<Book>();
}