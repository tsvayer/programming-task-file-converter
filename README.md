# Task

Write a program CLI which should convert files from INPUT format in to OUTPUT format. You can find details below.

Please don’t modify files in attached task.
Please note that file ‘input.csv’ could have tens of GB size. File ‘hotels.json’ could have hundreds of MB size.

## Format INPUT:

```
city_code|hotel_code|room_type|room_code|meal|checkin|adults|children|price|source
```

```
city_code  - three letters city code
hotel_code – hotel code
room_type  - type of room code
room_code  - room code
meal       - meal code
checkin    - arrival date
adults     - number of adults
children   - number of children
price      - price for stay
source     - source of price name
```

## Format OUTPUT:

```
room_type meal;room_code;source;hotel_name;city_name;city_code;hotel_category;pax;adults;children;room_name;checkin;checkout;price
```

```
room_type meal -  type of the room and meal code, separated with space
room_code      - room code
source         - name of price source
hotel_name     - name of hotel
city_name      - name of the city
city_code      - three letters city code
hotel_category – hotel category
pax            - number of travelers  (sum of adults and children)
adults         - number of adults
children       - number of children
room_name      - name of the room
checkin        - date of arrival
checkout       - date of departure (please accept that checkout = checkin + 1 day)
price          - price for stay for one person
```

## Format hotels.json:

Note: there is a right object (in JSON format) in every line of this file but the whole file is not the right JSON file!

```
{
  "id": "BER00003",                // hotel code
  "city_code": "BER",              // three letters city code
  "name": "Berlin Marriott Hotel", // name of the hotel
  "category": 5.0,                 // hotel category
  "country_code": "DE",            // two letters state code
  "city": "Berlin"                 // city name
}
```

Format room_names.csv

```
hotel_code|source|room_name|room_code
```

```
hotel_code – hotel code
source     - price source name
room_name  - room name
room_code  - room code
```

## input.csv

```
city_code|hotel_code|room_type|room_code|meal|checkin|adults|children|price|source
BER|BER00002|EZ|BER898|F|20180721|1|0|85.50|IHG
BER|BER00002|EZ|BER898|F|20180722|1|0|78.00|IHG
BER|BER00002|EZ|BER898|F|20180723|1|0|85.50|IHG
BER|BER00003|DZ|BER848|U|20180721|2|0|101.59|MARR
BER|BER00003|DZ|BER848|U|20180722|2|0|109.46|MARR
BER|BER00003|DZ|BER848|U|20180723|2|1|176.01|MARR
```

## expected.csv

```
room_type meal;room_code;source;hotel_name;city_name;city_code;hotel_category;pax;adults;children;room_name;checkin;checkout;price
EZ F;BER898;IHG;Crowne Plaza Berlin City Centre;Berlin;BER;4.0;1;1;0;Einzelzimmer;2018-07-21;2018-07-22;85.50
EZ F;BER898;IHG;Crowne Plaza Berlin City Centre;Berlin;BER;4.0;1;1;0;Einzelzimmer;2018-07-22;2018-07-23;78.00
EZ F;BER898;IHG;Crowne Plaza Berlin City Centre;Berlin;BER;4.0;1;1;0;Einzelzimmer;2018-07-23;2018-07-24;85.50
DZ U;BER848;MARR;Berlin Marriott Hotel;Berlin;BER;5.0;2;2;0;Deluxe King;2018-07-21;2018-07-22;50.80
DZ U;BER848;MARR;Berlin Marriott Hotel;Berlin;BER;5.0;2;2;0;Deluxe King;2018-07-22;2018-07-23;54.73
DZ U;BER848;MARR;Berlin Marriott Hotel;Berlin;BER;5.0;3;2;1;Deluxe King;2018-07-23;2018-07-24;58.67
```

## hotels.json

```
{"id": "BER00002", "city_code": "BER", "name": "Crowne Plaza Berlin City Centre", "category": 4.0, "country_code": "DE", "city": "Berlin" }
{"id": "BER00003", "city_code": "BER", "name": "Berlin Marriott Hotel", "category": 5.0, "country_code": "DE", "city": "Berlin" }
```

## room_names.csv

```
BER00003|MARR|Single Standard|BER849
BER00003|MARR|Deluxe King|BER848
BER00003|DOTW|SINGLE DELUXE|BER848
BER00002|GTA|Standard|BER898
BER00002|IHG|Einzelzimmer|BER898
BER00002|MARR|Deluxe King Extra|BER848
```
