using System;
using Cli.Cache;
using Cli.Model;

namespace Cli.Filters
{
  internal static class TransformationFilters
  {
    public static OutputRecord ConvertRecord(InputRecord input) =>
      new OutputRecord
      {
        RoomType = input.RoomType,
        Meal = input.Meal,
        RoomCode = input.RoomCode,
        Source = input.Source,
        CityCode = input.CityCode,
        Adults = input.Adults,
        Children = input.Children,
        CheckIn = input.CheckIn,
        Price = input.Price,
        HotelCode = input.HotelCode
      };

    public static Action<OutputRecord> MapHotels(HotelCache cache) => record =>
    {
      var hotel = cache.Get(record.HotelCode);
      record.HotelName = hotel.Name;
      record.HotelCategory = hotel.Category;
      record.CityName = hotel.City;
    };

    public static Action<OutputRecord> MapRoomNames(RoomCache cache) => record =>
    {
      record.RoomName = cache.Get(record.Source, record.HotelCode, record.RoomCode);
    };
  }
}