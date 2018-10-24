using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cli.Filters
{
  internal static class IOFilters
  {
    public static IEnumerable<string> ReadInputFrom(FileSystemInfo file) => ReadFrom(file, 1);

    public static IEnumerable<string> ReadHotelsFrom(FileSystemInfo file) => ReadFrom(file);

    public static IEnumerable<string> ReadRoomsFrom(FileSystemInfo file) => ReadFrom(file);
    
    public static Action<string> WriteRecord(TextWriter writer) => writer.WriteLine;

    private static IEnumerable<string> ReadFrom(FileSystemInfo file, int skip = 0) =>
      File.ReadLines(file.FullName).Skip(skip);

  }
}
