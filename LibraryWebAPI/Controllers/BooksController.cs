using LibraryWebAPI.Data;
using Microsoft.AspNetCore.Mvc;
using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly LibraryDbContext _dbContext;

    public BooksController(LibraryDbContext dbContext)
    {
        _dbContext = dbContext; // connection to the database
    }
    
    
    // CRUD Operations.
    
    // Post (Create)
    [HttpPost]
    public async Task<ActionResult<Book>> Create (Book book)
    {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);

    }

    // checkout
    [HttpPost("{id}/checkout")]
    public async Task<ActionResult<Book>> Checkout(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book is null) return NotFound("Book not found.");
        if (book.IsCheckedOut) return BadRequest("Book is already checked out.");

        book.IsCheckedOut = true; // mark as checkout (true) if book.IsCheckedOut == false.
        await _dbContext.SaveChangesAsync();
        return Ok(book);
    }

    // return
    [HttpPost("{id}/return")]
    public async Task<ActionResult<Book>> Return(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book is null) return NotFound("Book not found.");
        if (!book.IsCheckedOut) return BadRequest("Book is not checked out.");

        book.IsCheckedOut = false;
        await _dbContext.SaveChangesAsync();
        return Ok(book);
    }

    // Get (Read)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAll() =>
        Ok(await _dbContext.Books.ToListAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        return book is null ? NotFound("Book not found.") : Ok(book);
    }
    
    // Put (Update)
    [HttpPut("{id}")]
    public async Task<ActionResult<Book>> Update(int id, Book updatedBook)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book is null) return NotFound();

        book.Title = updatedBook.Title;
        book.Author = updatedBook.Author;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    // Delete (Delete)
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book is null) return NotFound();
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return NoContent();
        
    }

}