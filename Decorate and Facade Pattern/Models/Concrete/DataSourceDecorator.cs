using Decorate_and_Facade_Pattern.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorate_and_Facade_Pattern.Models.Concrete;

public class DataSourceDecorator : IDataSource
{
    protected IDataSource _wrappee { get; set; }
    public DataSourceDecorator(IDataSource wrappee)
    {
        _wrappee = wrappee;
        
    }

    public virtual string? ReadData()
    {
       return _wrappee.ReadData();
    }

    public virtual void WriteData(string data)
    {
        _wrappee.WriteData(data);
    }

    public string? GetFileName()
    {
        return _wrappee.GetFileName();
    }
}
