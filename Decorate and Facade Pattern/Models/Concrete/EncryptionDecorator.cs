using Decorate_and_Facade_Pattern.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Decorate_and_Facade_Pattern.Models.Concrete;

public class EncryptionDecorator : DataSourceDecorator
{
    private const string _securityKey = "Ali Bomba Oglandi";
    public EncryptionDecorator(IDataSource wrappee) : base(wrappee) { }

    public override void WriteData(string data)
    {
        var encryptData = EncryptPlainTextToCipherText(data);
        base.WriteData(encryptData);
    }

    public override string? ReadData()
    {
        if (base.ReadData() == null)
            throw new FileNotFoundException();

        return DecryptCipherTextToPlainText(base.ReadData()!);
    }

    // Md 5 in microsoft dokumentasiyasindan ferqli asan yol tapdim
    //https://qawithexperts.com/article/c-sharp/encrypt-password-decrypt-it-c-console-application-example/169
    public static string EncryptPlainTextToCipherText(string PlainText)
    {
        
        byte[] toEncryptedArray = UTF8Encoding.UTF8.GetBytes(PlainText);

        MD5CryptoServiceProvider objMD5CryptoService = new();
        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));
        
        objMD5CryptoService.Clear();

        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
        
        objTripleDESCryptoService.Key = securityKeyArray;
        
        objTripleDESCryptoService.Mode = CipherMode.ECB;
        
        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;


        var objCrytpoTransform = objTripleDESCryptoService.CreateEncryptor();
        
        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptedArray, 0, toEncryptedArray.Length);
        objTripleDESCryptoService.Clear();
        return Convert.ToBase64String(resultArray, 0, resultArray.Length);
    }

    public static string DecryptCipherTextToPlainText(string CipherText)
    {
        byte[] toEncryptArray = Convert.FromBase64String(CipherText);
        MD5CryptoServiceProvider objMD5CryptoService = new MD5CryptoServiceProvider();

       
        byte[] securityKeyArray = objMD5CryptoService.ComputeHash(UTF8Encoding.UTF8.GetBytes(_securityKey));
        objMD5CryptoService.Clear();

        var objTripleDESCryptoService = new TripleDESCryptoServiceProvider();
        
        objTripleDESCryptoService.Key = securityKeyArray;
        
        objTripleDESCryptoService.Mode = CipherMode.ECB;
        
        objTripleDESCryptoService.Padding = PaddingMode.PKCS7;

        var objCrytpoTransform = objTripleDESCryptoService.CreateDecryptor();
        
        byte[] resultArray = objCrytpoTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        objTripleDESCryptoService.Clear();

        return Encoding.UTF8.GetString(resultArray);
    }

}
