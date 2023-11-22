using GalacticAnnouncementsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalacticAnnouncementsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementController : ControllerBase
{

    public AnnouncementController()
    {
    }

    [HttpGet(Name = "GetAnnouncements")]
    public IEnumerable<Announcement> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Announcement("Test", "Test", "Test", DateOnly.FromDateTime(DateTime.Now.AddDays(index - 5)))).ToArray();
    }


    [HttpGet("{id}")]
    public Announcement Get(int id)
    {
        return new Announcement ("Test", "Test", "Test", DateOnly.FromDateTime(DateTime.Now));
    }

    [HttpPost]
    public async Task<IActionResult> Post(string? author, string? subject, string? body, int year, int month, int day)
    {
        Announcement announcement = new Announcement(author, subject, body, new DateOnly(year, month, day));
        return CreatedAtAction(nameof(Get), new { id = 1}, announcement);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Announcement>> Update(int id, string? author, string? subject, string? body, int year, int month, int day)
    {

        return NoContent();
    }
}
