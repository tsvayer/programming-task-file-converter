using System;
using System.Globalization;
using Cli.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cli.Filters
{
  internal static class SerializerFilters
  {
    public static HotelInfo DeserializeHotel(string input) =>
      JsonConvert.DeserializeObject<HotelInfo>(input, DeserializerSettings);

    public static RoomInfo DeserializeRooms(string data)
    {
      var fields = data.Split('|');
      return new RoomInfo
      {
        HotelCode = fields[0],
        Source = fields[1],
        RoomName = fields[2],
        RoomCode = fields[3]
      };
    }

    public static InputRecord DeserializeRecord(string data)
    {
      var fields = data.Split('|');
      return new InputRecord
      {
        CityCode = fields[0],
        HotelCode = fields[1],
        RoomType = fields[2],
        RoomCode = fields[3],
        Meal = fields[4],
        CheckIn = DateTimeOffset.ParseExact(fields[5], "yyyyMMdd", CultureInfo.InvariantCulture),
        Adults = uint.Parse(fields[6], CultureInfo.InvariantCulture),
        Children = uint.Parse(fields[7], CultureInfo.InvariantCulture),
        Price = decimal.Parse(fields[8], CultureInfo.InvariantCulture),
        Source = fields[9]
      };
    }

    public static string SerializeRecord(OutputRecord record) =>
      string.Join(";",
        $"{record.RoomType} {record.Meal}",
        record.RoomCode,
        record.Source,
        record.HotelName,
        record.CityName,
        record.CityCode,
        record.HotelCategory,
        record.Pax,
        record.Adults,
        record.Children,
        record.RoomName,
        record.CheckIn.ToString("yyyy-MM-dd"),
        record.CheckOut.ToString("yyyy-MM-dd"),
        record.Price);

    private static readonly JsonSerializerSettings DeserializerSettings =
      new JsonSerializerSettings
      {
        ContractResolver = new DefaultContractResolver
        {
          NamingStrategy = new SnakeCaseNamingStrategy()
        }
      };
  }
}
