using System.Collections.Generic;
using Cli.Model;

namespace Cli.Cache
{
  //TODO: Is HotelCode unique globally?
  public class HotelCache
  {
    private readonly Dictionary<string, HotelInfo> map = new Dictionary<string, HotelInfo>();

    public void Push(HotelInfo hotelInfo)
    {
      map[hotelInfo.Id] = hotelInfo;
    }

    public HotelInfo Get(string hotelCode) => map[hotelCode];
  }
}
