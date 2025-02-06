using TestTask1.Core.Entitys;
using TestTask1.Data;

namespace TestTask1.Services;

public class CoordinateService
{
    private readonly ICoordinateSaving _coordinateSaving;

    public CoordinateService(ICoordinateSaving coordinateSaving)
    {
        _coordinateSaving = coordinateSaving;
    }

    public async Task<bool> SaveCoordinateAsync(Coordinate coordinate)
    {
        Console.WriteLine($"Saving coordinate: {coordinate}");
        return await _coordinateSaving.SaveAsync(coordinate);
    }
}