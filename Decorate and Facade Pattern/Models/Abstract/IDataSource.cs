using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorate_and_Facade_Pattern.Models.Abstract;

public interface IDataSource
{
    void WriteData(string data);
    string? ReadData();
    string? GetFileName();
}
