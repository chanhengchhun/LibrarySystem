using Microsoft.AspNetCore.Mvc;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    
    // hard-coded books
    private static readonly List<Book> Books = new()
    {
        new Book { Id = 1, Title = "Dune", Author = "Frank Herbert" },
        new Book { Id = 2, Title = "1984", Author = "George Orwell" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll() => Ok(Books);

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        // create a new book with a unique Id (auto-increment)
        book.Id = Books.Max(b => b.Id) + 1;
        Books.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }
}