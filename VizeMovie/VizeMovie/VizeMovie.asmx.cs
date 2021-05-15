using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Services;
using System.Text.Json;
using System.Xml.Serialization;
using System.Xml;

namespace VizeMovie
{
    /// <summary>
    /// VizeMovie için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://localhost/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class VizeMovie : System.Web.Services.WebService
    {
        //open rest api
        string baseUrl = "http://www.omdbapi.com/?apikey=4cb389c7&";
        MovieItem movie;

        [WebMethod]
        public SearchList SearchMovies(string name)
        {
            //get isteği
            var request = WebRequest.Create(baseUrl + "s="+ name);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            //gelen json yanıtının liste e dönüştürülmesi
            SearchList searchList;
            searchList = JsonSerializer.Deserialize<SearchList>(data);

            return searchList;
        }
        [WebMethod]
        public MovieItem SearchMovieByTitle(string title)
        {
            //get isteği
            var request = WebRequest.Create(baseUrl + "t=" + title);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            //gelen json yanıtının movie class a dönüştürülmesi
            movie = JsonSerializer.Deserialize<MovieItem>(data);
            return movie;
        }

        [WebMethod]
        public MovieItem SearchMovieById(string id)
        {
            //get isteği
            var request = WebRequest.Create(baseUrl + "i=" + id);
            request.Method = "GET";
            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            //gelen json yanıtının movie class a dönüştürülmesi
            movie = JsonSerializer.Deserialize<MovieItem>(data);
            return movie;
        }

        //json için classlar
        public class SearchItem
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string Poster { get; set; }

        }

        //json için classlar
        public class MovieItem
        {
            public string Title { get; set; }
            public string Year { get; set; }
            public string Rated { get; set; }
            public string Released { get; set; }
            public string Runtime { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public string Writer { get; set; }
            public string Actors { get; set; }
            public string Plot { get; set; }
            public string Country { get; set; }
            public string Awards { get; set; }
            public string Poster { get; set; }
            public string Metascore { get; set; }
            public string imdbRating { get; set; }
            public string imdbVotes { get; set; }
            public string imdbID { get; set; }
            public string Type { get; set; }
            public string DVD { get; set; }
            public string BoxOffice { get; set; }
            public string Production { get; set; }
            public string Website { get; set; }
            public string Response { get; set; }
            public List<Ratings> Ratings { get; set; }
        }

        //json için classlar
        public class SearchList
        {
            public List<SearchItem> Search { get; set; }
        }
    }

    //json için classlar
    public class Ratings
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}

