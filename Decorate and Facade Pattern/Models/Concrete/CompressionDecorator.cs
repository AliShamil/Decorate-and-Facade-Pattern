using Decorate_and_Facade_Pattern.Models.Abstract;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorate_and_Facade_Pattern.Models.Concrete;

static class CompressionDecorator 
{
    public static void CompressFile(string filepath)
    {
        
        using FileStream originalFileStream = File.Open(filepath, FileMode.Open);
        using FileStream compressedFileStream = File.Create($"{filepath}Compressed.gz");
        using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
        originalFileStream.CopyTo(compressor);
    }
    public static void DecompressFile(string compressedFilePath)
    {
        using FileStream compressedFileStream = File.Open(compressedFilePath, FileMode.Open);
        using FileStream outputFileStream = File.Create($"{compressedFilePath}Decompressed.txt");
        using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
        decompressor.CopyTo(outputFileStream);
    }
}
