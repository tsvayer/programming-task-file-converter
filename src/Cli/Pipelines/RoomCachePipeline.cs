using System.Collections.Generic;
using Cli.Cache;
using static Cli.Filters.SerializerFilters;

namespace Cli.Pipelines
{
  public class RoomCachePipeline
  {
    private readonly IEnumerable<string> rooms;
    private readonly RoomCache roomCache;

    public RoomCachePipeline(IEnumerable<string> rooms, RoomCache roomCache)
    {
      this.rooms = rooms;
      this.roomCache = roomCache;
    }

    public void Run(int degreeOfParallelism) =>
      rooms
        .Pipe(_ => _.Pipe(DeserializeRooms), degreeOfParallelism)
        .Pipe(roomCache.Push)
        .Run();
  }
}