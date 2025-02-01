using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestTask1.Data;
using TestTask1.Models;

namespace TestTask1.Controllers;

public class CoordinateController : Controller
{
    private readonly ISavingInfo _savingInfo;

    public CoordinateController(ISavingInfo savingInfo)
    {
        _savingInfo = savingInfo;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddIntoDb([FromBody] List<CoordinateModel> coordinates)
    {
        if (coordinates == null || coordinates.Count == 0)
        {
            return BadRequest();
        }
        else
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (_savingInfo.SaveInfoIntoDb(coordinates[i]))
                {
                    TempData["SuccessMessage"] = "Данные успешно сохранены и отправлены!";
                }
                else
                {
                    TempData["ErrorMessage"] = "Произошла ошибка при сохранении данных в базу.";
                    Console.WriteLine(_savingInfo.ErrorMessage);
                }
            }
        }
        return Ok(new {message = "It is OK"});
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}