namespace TestTask1.Core.Entitys;

public interface ICoordinateSaving
{
    Task<bool> SaveAsync(Coordinate coordinate);
}