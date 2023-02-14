using System;
using System.Globalization;
using System.Net;
using System.Linq;

internal class Program {
    private const string addressUrl = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";


    private static async Task<Stream> StreamAsync () {
        var client = new HttpClient();
        var response = await client.GetAsync ( addressUrl, HttpCompletionOption.ResponseHeadersRead );
        return await response.Content.ReadAsStreamAsync ();
    }

    private static IEnumerable<string> GetDataLines () {
        using var dataStream = StreamAsync().Result;
        using var reader = new StreamReader ( dataStream );

        while ( !reader.EndOfStream ) {
         var line = reader.ReadLine ();
            if ( string.IsNullOrWhiteSpace(line) )
                continue;
            
            yield return line;
        }
    }

    private static DateTime[] GetDates () => GetDataLines ()
        .First ()
        .Split ( "," )
        .Skip ( 4 )
        .Select ( s => DateTime.Parse ( s, CultureInfo.InvariantCulture ) )
        .ToArray ();


     private static IEnumerable<(string Country, string Province, int[] Counts)> GetData () {
          var lines = GetDataLines ()
            .Skip(1)
            .Select(lines => lines.Split(","));

        foreach(var row in lines) {
            var province = row[0].Trim();
            var country = row[1].Trim(' ', '"');
            var counts = row.Skip(5).Select(int.Parse).ToArray();

            yield return (country, province, counts);
        }

    }

    private static void Main ( string[] args ) {

        // var webClient = new WebClient ();

       // var client = new HttpClient();
       // var response = client.GetAsync ( addressUrl ).Result;
       // var str_data = response.Content.ReadAsStringAsync ().Result;
      // foreach ( var line in GetDataLines () ) {
      //      Console.WriteLine ( line );
      //  }
     // var date = GetDates();

        var russia_data = GetData()
            .First(v => v.Country.Equals("Russia", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine (string.Join("\r\n", GetDates().Zip(russia_data.Counts, (data, counts) => $"{ data:dd:MM:yyyy} --- { counts }")));
    }
}