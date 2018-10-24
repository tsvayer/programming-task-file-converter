using System;

namespace Cli.Model
{
  internal class OutputRecord
  {
    //TODO: find a better place
    public const string Header = "room_type meal;" +
                                 "room_code;source;" +
                                 "hotel_name;" +
                                 "city_name;city_code;" +
                                 "hotel_category;" +
                                 "pax;adults;" +
                                 "children;" +
                                 "room_name;checkin;" +
                                 "checkout;" +
                                 "price";

    public string RoomType { get; set; }
    public string Meal { get; set; }
    public string RoomCode { get; set; }
    public string Source { get; set; }
    public string HotelName { get; set; }
    public string CityName { get; set; }
    public string CityCode { get; set; }
    public decimal HotelCategory { get; set; }
    public uint Pax => Adults + Children;
    public uint Adults { get; set; }
    public uint Children { get; set; }
    public string RoomName { get; set; }
    public DateTimeOffset CheckIn { get; set; }
    public DateTimeOffset CheckOut => CheckIn.AddDays(1);
    public decimal Price { get; set; }
    public string HotelCode { get; set; }
  }
}
