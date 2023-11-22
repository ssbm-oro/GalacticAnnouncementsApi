using GalacticAnnouncementsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalacticAnnouncementsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnouncementController : ControllerBase
{

    public AnnouncementController()
    {
    }

    [HttpGet(Name = "GetAnnouncements")]
    public IEnumerable<Announcement> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Announcement
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index - 5)),
            Author = "Test",
            Subject = "Test",
            Body = "Test"
        })
        .ToArray();
    }
}
