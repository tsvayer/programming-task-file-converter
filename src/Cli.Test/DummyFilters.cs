using System.Collections.Generic;
using System.Linq;

namespace Cli.Test
{
  internal static class DummyFilters
  {
    public static IEnumerable<string> Records() => new[]
    {
      "city_code|hotel_code|room_type|room_code|meal|checkin|adults|children|price|source",
      "BER|BER00002|EZ|BER898|F|20180721|1|0|85.50|IHG",
      "BER|BER00002|EZ|BER898|F|20180722|1|0|78.00|IHG",
      "BER|BER00002|EZ|BER898|F|20180723|1|0|85.50|IHG",
      "BER|BER00003|DZ|BER848|U|20180721|2|0|101.59|MARR",
      "BER|BER00003|DZ|BER848|U|20180722|2|0|109.46|MARR",
      "BER|BER00003|DZ|BER848|U|20180723|2|1|176.01|MARR"
    }.Skip(1);

    public static IEnumerable<string> Hotels() => new[]
    {
      "{\"id\": \"BER00002\", \"city_code\": \"BER\", \"name\": \"Crowne Plaza Berlin City Centre\", \"category\": 4.0, \"country_code\": \"DE\", \"city\": \"Berlin\" }",
      "{\"id\": \"BER00003\", \"city_code\": \"BER\", \"name\": \"Berlin Marriott Hotel\", \"category\": 5.0, \"country_code\": \"DE\", \"city\": \"Berlin\" }"
    };

    public static IEnumerable<string> Rooms() => new[]
    {
      "BER00003|MARR|Single Standard|BER849",
      "BER00003|MARR|Deluxe King|BER848",
      "BER00003|DOTW|SINGLE DELUXE|BER848",
      "BER00002|GTA|Standard|BER898",
      "BER00002|IHG|Einzelzimmer|BER898",
      "BER00002|MARR|Deluxe King Extra|BER848"
    };
  }
}
