using System;

namespace Cli.Model
{
  internal class InputRecord
  {
    public string CityCode { get; set; }
    public string HotelCode { get; set; }
    public string RoomType { get; set; }
    public string RoomCode { get; set; }
    public string Meal { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public uint Adults { get; set; }
    public uint Children { get; set; }
    public decimal Price { get; set; }
    public string Source { get; set; }
  }
}