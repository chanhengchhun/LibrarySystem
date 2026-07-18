using Microsoft.AspNetCore.Mvc;
using LibraryWebAPI.Models;

namespace LibraryWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersControllers : ControllerBase
{
    public bool IsAvailable { get; set; } = true;
    public int? CheckedOutByUserId { get; set; }
    
    public static readonly List<User> Users = new()
    {
        new User { Id = 1, Name = "Alice", Email = "alice@example.com", PasswordHash = "hashedpassword1" },
        new User { Id = 2, Name = "Bob", Email = "bob@example.com", PasswordHash = "hashedpassword2" }
    };
    
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAll() => Ok(Users);
    
    [HttpGet("{id}")]
    public ActionResult<User> GetById(int id)
    {
        var user = Users.FirstOrDefault(u => u.Id == id);
        return user is null ? NotFound() : Ok(user);
    }
}