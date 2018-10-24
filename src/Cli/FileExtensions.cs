using System;
using System.IO;

namespace Cli
{
  public static class FileExtensions
  {
    public static void UsingFileWriter(FileInfo file, Action<StreamWriter> block)
    {
      using (var outputStream = file.OpenWrite())
      using (var outputWrite = new StreamWriter(outputStream))
      {
        block(outputWrite);
      }
    }
  }
}
