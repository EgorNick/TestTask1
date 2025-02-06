using TestTask1.Core.Entitys;
using TestTask1.Data;

namespace TestTask1.Infrastructure;

public class CoordinateRepository : ICoordinateRepository
{
    private readonly AppDbContext _context;
    
    public string ErrorMessage { get; private set; }

    public CoordinateRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> SaveAsync(Coordinate coordinate)
    {
        try
        {
            await _context.JsonData.AddAsync(coordinate); 
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            ErrorMessage = e.Message;
            return false;
        }
    }
}