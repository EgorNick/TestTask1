using TestTask1.Data.Entitys;
using TestTask1.Models;

namespace TestTask1.Data;

public interface ISavingInfo
{
    public bool SaveInfoIntoDb(CoordinateModel entity);
    
    public string ErrorMessage { get;}

}