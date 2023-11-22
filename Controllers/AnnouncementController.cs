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
}
