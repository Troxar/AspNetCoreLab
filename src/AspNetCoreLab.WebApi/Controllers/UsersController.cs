using AspNetCoreLab.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreLab.WebApi.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private static readonly List<User> Users =
    [
        new() { Id = 1, Name = "John Doe" },
        new() { Id = 2, Name = "Jane Smith" }
    ];

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(Users);
    }

    [HttpGet("{id:int}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        Users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id:int}")]
    public ActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var user = Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
            return NotFound();

        user.Name = updatedUser.Name;
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteUser(int id)
    {
        var user = Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
            return NotFound();

        Users.Remove(user);
        return NoContent();
    }
}