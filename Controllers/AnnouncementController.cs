using GalacticAnnouncementsApi.Models;
using GalacticAnnouncementsApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AnnouncementController : ControllerBase
{
    private readonly AnnouncementService _announcementService;
    public AnnouncementController(AnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    [HttpGet]
    public async Task<List<Announcement>> Get() 
    {
        return await _announcementService.GetAnnouncementsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Announcement>> Get(int id)
    {
        Announcement? announcement = await _announcementService.GetAnnouncementAsync(id);

        if (announcement is null) 
        {
            return NotFound();
        }

        return announcement;
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
        Announcement announcement = await _announcementService.GetAnnouncementAsync(id);

        if (announcement is null)
        {
            return NotFound();
        }

        await _announcementService.DeleteAnnouncementAsync(announcement);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Announcement>> Update(int id, string? author, string? subject, string? body, int year, int month, int day)
    {
        Announcement announcement = await _announcementService.GetAnnouncementAsync(id);

        if (announcement is null)
        {
            return NotFound();
        }

        announcement.Author = author;
        announcement.Subject = subject;
        announcement.Body = body;
        announcement.Date = new DateOnly(year, month, day);

        await _announcementService.UpdateAnnouncementAsync(announcement);

        return NoContent();
    }
}