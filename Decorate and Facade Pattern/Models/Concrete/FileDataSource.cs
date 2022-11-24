using Decorate_and_Facade_Pattern.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorate_and_Facade_Pattern.Models.Concrete;

public class FileDataSource : IDataSource
{
    private string _filePath;

    public FileDataSource(string filePath)
    {
        _filePath = filePath;
    }

    public void WriteData(string data)
    {
        File.WriteAllText(_filePath, data);
    }

    public string? ReadData()
    {

        if (File.Exists(_filePath))
            return File.ReadAllText(_filePath);
        return null;
    }
    public string? GetFileName() => _filePath;


}
