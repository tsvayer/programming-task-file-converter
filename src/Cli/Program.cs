using System.IO;
using Cli.Cache;
using Cli.Pipelines;
using static Cli.Filters.IOFilters;
using static Cli.FileExtensions;

namespace Cli
{
  class Program
  {
    private const int DegreeOfParallelism = 4;

    static void Main()
    {
      //TODO: read as arguments
      var inputFile = new FileInfo("../../input.csv");
      var hotelsFile = new FileInfo("../../hotels.json");
      var roomsFile = new FileInfo("../../room_names.csv");
      var outputFile = new FileInfo("./bin/output.csv");

      Run(inputFile, outputFile, hotelsFile, roomsFile);
    }

    private static void Run(
      FileInfo inputFile,
      FileInfo outputFile,
      FileInfo hotelsFile,
      FileInfo roomsFile)
    {
      var hotelCache = new HotelCache();
      var roomCache = new RoomCache();

      new HotelCachePipeline(ReadHotelsFrom(hotelsFile), hotelCache)
        .Run(DegreeOfParallelism);

      new RoomCachePipeline(ReadRoomsFrom(roomsFile), roomCache)
        .Run(DegreeOfParallelism);

      UsingFileWriter(outputFile, writer =>
        new ConversionPipeline(ReadInputFrom(inputFile), writer, hotelCache, roomCache)
          .Run(DegreeOfParallelism)
      );
    }
  }
}
