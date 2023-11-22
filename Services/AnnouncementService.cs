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

    public async Task<List<Announcement>> GetAnnouncementsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Announcement> GetAnnouncementAsync(int id) 
    {
        throw new NotImplementedException();
    }

    public async Task CreateAnnouncementAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAnnouncementAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAnnouncementAsync(Announcement announcement)
    {
        throw new NotImplementedException();
    }
}