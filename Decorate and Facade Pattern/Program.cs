using Decorate_and_Facade_Pattern.Models.Abstract;
using Decorate_and_Facade_Pattern.Models.Concrete;

namespace Decorate_and_Facade_Pattern;

public class Program
{
    static void Main()
    {
        IDataSource dataSource = new FileDataSource($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/EncryptFile.txt");

        dataSource = new EncryptionDecorator(dataSource);
        dataSource.WriteData("Salam Aleykum");



        var data = dataSource.ReadData();
        Console.WriteLine(data);
    }
}
