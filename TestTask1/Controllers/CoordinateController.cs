using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTask1.Core.Entitys;
using TestTask1.Data;
using TestTask1.Services;

namespace TestTask1.Controllers;

public class CoordinateController : Controller
{
    private readonly CoordinateService _coordinateService;

    public CoordinateController(CoordinateService coordinateService)
    {
        _coordinateService = coordinateService;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpPost("Coordinate/AddIntoDb")]
    public async Task<IActionResult> AddIntoDb([FromBody] List<Coordinate>? coordinates)
    {
        if (coordinates == null || coordinates.Count == 0)
        {
            return BadRequest();
        }

        foreach (var coordinate in coordinates)
        {
            await _coordinateService.SaveCoordinateAsync(coordinate);
        }
        return Ok(new {message = "Данные сохранены"});
    }
    
}