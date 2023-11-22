using GalacticAnnouncementsApi.Models;
using GalacticAnnouncementsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace GalacticAnnouncementsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnouncementController : ControllerBase
{
    protected AnnouncementService _announcementService;
    public AnnouncementController(AnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [HttpGet(Name = "GetAnnouncements")]
    public async Task<List<Announcement>> Get()
    {
        return await _announcementService.GetAnnouncementsAsync();
    }


    [HttpGet("{id}")]
    public async Task<Announcement> Get(int id)
    {
        return await _announcementService.GetAnnouncementAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Post(string? author, string? subject, string? body, int year, int month, int day)
    {
        Announcement announcement = new Announcement(author, subject, body, new DateOnly(year, month, day));
        await _announcementService.CreateAnnouncementAsync(announcement);
        return CreatedAtAction(nameof(Get), new { id = announcement.ID}, announcement);
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
