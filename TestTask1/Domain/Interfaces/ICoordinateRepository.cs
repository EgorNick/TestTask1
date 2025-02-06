namespace TestTask1.Core.Entitys;

public interface ICoordinateRepository
{
    Task<bool> SaveAsync(Coordinate coordinate);
}