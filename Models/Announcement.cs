namespace GalacticAnnouncementsApi.Models;

public class Announcement
{
    public int ID { get; set; }
    public DateOnly Date { get; set; }

    public string? Author { get; set; }

    public string? Subject { get; set;}

    public string? Body { get; set; }
}