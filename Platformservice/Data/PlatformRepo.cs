using Platformservice.Models;

namespace Platformservice.Data;
public class PlatformRepo : IPlatformRepo
{
    private AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }
    public void CreatePlatform(Platform plat)
    {
        if(plat is null)
        {
            throw new ArgumentNullException(nameof(plat));
        }
        _context.Platforms.Add(plat);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        Platform plat = _context.Platforms.FirstOrDefault(p => p.Id == id);
        if(plat is null)
        {
            throw new ArgumentNullException(nameof(plat));
        }
        return plat;
    }
    public bool SaveChanges()
    {
        return (_context.SaveChanges()>=0);
    }
}
