using System.Collections.Generic;
using Cli.Model;

namespace Cli.Cache
{
  public class RoomCache
  {
    private readonly Dictionary<string, string> map = new Dictionary<string, string>();

    public void Push(RoomInfo roomInfo)
    {
      map[Key(roomInfo.Source, roomInfo.HotelCode, roomInfo.RoomCode)] = roomInfo.RoomName;
    }

    public string Get(string source, string hotelCode, string roomCode) =>
      map[Key(source, hotelCode, roomCode)];

    private static string Key(string source, string hotelCode, string roomCode) =>
      $"{source}:${hotelCode}:${roomCode}";
  }
}
