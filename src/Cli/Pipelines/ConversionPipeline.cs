using System.Collections.Generic;
using System.IO;
using Cli.Cache;
using Cli.Model;
using static Cli.Filters.SerializerFilters;
using static Cli.Filters.TransformationFilters;
using static Cli.Filters.IOFilters;

namespace Cli.Pipelines
{
  public class ConversionPipeline
  {
    private readonly IEnumerable<string> records;
    private readonly TextWriter output;
    private readonly HotelCache hotelCache;
    private readonly RoomCache roomCache;

    public ConversionPipeline(
      IEnumerable<string> records,
      TextWriter output,
      HotelCache hotelCache,
      RoomCache roomCache)
    {
      this.records = records;
      this.output = output;
      this.hotelCache = hotelCache;
      this.roomCache = roomCache;
    }

    public void Run(int degreeOfParallelism)
    {
      output.WriteLine(OutputRecord.Header); 
      records
        .Pipe(ProcessRecord, degreeOfParallelism)
        .Pipe(WriteRecord(output))
        .Run();
    }

    private string ProcessRecord(string record) => record
      .Pipe(DeserializeRecord)
      .Pipe(ConvertRecord)
      .Pipe(MapHotels(hotelCache))
      .Pipe(MapRoomNames(roomCache))
      .Pipe(SerializeRecord);
  }
}
