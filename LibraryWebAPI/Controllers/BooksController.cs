using Microsoft.AspNetCore.Mvc;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static readonly List<Books> Books = new()
    {
        new Books { Id = 1, Title = "Dune", Author = "Frank Herbert" },
        new Books { Id = 2, Title = "1984", Author = "George Orwell" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Books>> GetAll() => Ok(Books);

    [HttpGet("{id}")]
    public ActionResult<Books> GetById(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        return book is null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public ActionResult<Books> Create(Books book)
    {
        book.Id = Books.Max(b => b.Id) + 1;
        Books.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }
}