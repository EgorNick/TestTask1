using TestTask1.Core.Entitys;
using TestTask1.Data;

namespace TestTask1.Services;

public class CoordinateService
{
    private readonly ICoordinateRepository _coordinateRepository;

    public CoordinateService(ICoordinateRepository coordinateRepository)
    {
        _coordinateRepository = coordinateRepository;
    }

    public async Task<bool> SaveCoordinateAsync(Coordinate coordinate)
    {
        Console.WriteLine($"Saving coordinate: {coordinate}");
        return await _coordinateRepository.SaveAsync(coordinate);
    }
}