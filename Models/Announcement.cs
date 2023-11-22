using Microsoft.EntityFrameworkCore;

namespace GalacticAnnouncementsApi.Models;

[Index(nameof(ID))]
public class Announcement
{
    public int ID { get; set; }
    public DateOnly Date { get; set; }

    public string? Author { get; set; }

    public string? Subject { get; set;}

    public string? Body { get; set; }

    public Announcement(string? author, string? subject, string? body, DateOnly date)
    {
        this.Date = date;
        this.Author = author;
        this.Subject = subject;
        this.Body = body;
    }
}