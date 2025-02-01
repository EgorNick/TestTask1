using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask1.Data.Entitys;

public class CoordinateEntity
{
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public DateTime Time { get; set; }
}