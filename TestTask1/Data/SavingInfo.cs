using TestTask1.Data.Entitys;
using TestTask1.Models;

namespace TestTask1.Data;

public class SavingInfo : ISavingInfo
{
    private readonly AppDbContext _context;
    
    public string ErrorMessage { get; private set; }

    public SavingInfo(AppDbContext context, AppDbContext logger)
    {
        _context = context;
    }

    public bool SaveInfoIntoDb(CoordinateModel model)
    {
        try
        {
            var entity = new CoordinateEntity()
            {
                Time = model.Time,
                X = model.X,
                Y = model.Y,
            };
            _context.JsonData.Add(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            ErrorMessage = ex.Message;
            return false;
        }

        return true;
    }
}