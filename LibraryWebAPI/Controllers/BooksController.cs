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
    
    // CRUD Operations.
    
    // Post (Create)
    [HttpPost]
    public ActionResult<Book> Create(Book book)
    {
        int newId;
        if (Books.Count == 0)
        {
            newId = 1;
        }
        else
        {
            newId = Books.Max(b => b.Id) + 1;
        }
        book.Id = newId;
        Books.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    // Get (Read)
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAll() => Ok(Books);

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        return book is null ? NotFound() : Ok(book);
    }
    
    // Put (Update)
    [HttpPut("{id}")]
    public ActionResult<Book> Update(int id, Book updatedBook)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book is null) return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        return NoContent();
    }

    // Delete (Delete)
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var book = Books.FirstOrDefault(b => b.Id == id);
        if (book is null) return NotFound();
        
        Books.Remove(book);
        return NoContent();
    }

}