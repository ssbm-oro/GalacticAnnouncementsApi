using GalacticAnnouncementsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace GalacticAnnouncementsApi.Services;

public class AnnouncementContext : DbContext
{
    public DbSet<Announcement> Announcements { get; set; }

    public string DbPath { get; set; }

    public AnnouncementContext(IOptions<AnnouncementDatabaseSettings> options)
    {
        DbPath = options.Value.FileName;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class AnnouncementService
{
    protected AnnouncementContext databaseContext;

    public AnnouncementService(IOptions<AnnouncementDatabaseSettings> options) 
    {
        databaseContext = new AnnouncementContext(options);
    }

    public async Task<List<Announcement>> GetAnnouncementsAsync(int lastId, int perPage)
    {
        return await databaseContext.Announcements
            .OrderBy(a => a.ID)
            .Where(a => a.ID > lastId)
            .Take(perPage)
            .ToListAsync();
    }

    public async Task<Announcement?> GetAnnouncementAsync(int id) 
    {
        Announcement? announcement = null;
        try 
        {
            announcement = await databaseContext.Announcements
            .Where(a => a.ID == id)
            .FirstAsync();
        }
        catch
        {
        }

        return announcement; 
    }

    public async Task CreateAnnouncementAsync(Announcement announcement)
    {
        await databaseContext.Announcements.AddAsync(announcement);
        await databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAnnouncementAsync(Announcement announcement)
    {
        databaseContext.Announcements.Update(announcement);
        await databaseContext.SaveChangesAsync();
    }

    public async Task DeleteAnnouncementAsync(Announcement announcement)
    {
        databaseContext.Remove(announcement);
        await databaseContext.SaveChangesAsync();
    }
}