using System.Collections.Generic;
using Cli.Cache;
using static Cli.Filters.SerializerFilters;

namespace Cli.Pipelines
{
  public class HotelCachePipeline
  {
    private readonly IEnumerable<string> hotels;
    private readonly HotelCache hotelCache;

    public HotelCachePipeline(IEnumerable<string> hotels, HotelCache hotelCache)
    {
      this.hotels = hotels;
      this.hotelCache = hotelCache;
    }

    public void Run(int degreeOfParallelism) =>
      hotels
        .Pipe(_ => _.Pipe(DeserializeHotel), degreeOfParallelism)
        .Pipe(hotelCache.Push)
        .Run();
  }
}
