using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

/*******************************************************************************
 * Free ASP.net IMDb Scraper API for the new IMDb Template.
 * Author: Abhinay Rathore
 * Website: http://www.AbhinayRathore.com
 * Blog: http://web3o.blogspot.com
 * More Info: http://web3o.blogspot.com/2010/11/aspnetc-imdb-scraping-api.html
 * Last Updated: Feb 20, 2013
 *******************************************************************************/

namespace TestScraper
{
    public class IMDb
    {
        public bool status { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public string Year { get; set; }
        public string Rating { get; set; }
        public ArrayList Genres { get; set; }
        public ArrayList Directors { get; set; }
        public ArrayList Writers { get; set; }
        public ArrayList Cast { get; set; }
        public ArrayList Producers { get; set; }
        public ArrayList Musicians { get; set; }
        public ArrayList Cinematographers { get; set; }
        public ArrayList Editors { get; set; }
        public string MpaaRating { get; set; }
        public string ReleaseDate { get; set; }
        public string Plot { get; set; }
        public ArrayList PlotKeywords { get; set; }
        public string Poster { get; set; }
        public string PosterLarge { get; set; }
        public string PosterFull { get; set; }
        public string Runtime { get; set; }
        public string Top250 { get; set; }
        public string Oscars { get; set; }
        public string Awards { get; set; }
        public string Nominations { get; set; }
        public string Storyline { get; set; }
        public string Tagline { get; set; }
        public string Votes { get; set; }
        public ArrayList Languages { get; set; }
        public ArrayList Countries { get; set; }
        public ArrayList ReleaseDates { get; set; }
        public ArrayList MediaImages { get; set; }
        public ArrayList RecommendedTitles { get; set; }
        public string ImdbURL { get; set; }

        //Search Engine URLs
        private string GoogleSearch = "http://www.google.com/search?q=imdb+";
        private string BingSearch = "http://www.bing.com/search?q=imdb+";
        private string AskSearch = "http://www.ask.com/web?q=imdb+";

        //Constructor
        public IMDb(string MovieName, bool GetExtraInfo = true)
        {
            string imdbUrl = this.getIMDbUrl(System.Uri.EscapeUriString(MovieName));
            this.status = false;
            if (!string.IsNullOrEmpty(imdbUrl))
            {
                this.parseIMDbPage(imdbUrl, GetExtraInfo);
            }
        }

        //Get IMDb URL from search results
        private string getIMDbUrl(string MovieName, string searchEngine = "google")
        {
            string url = this.GoogleSearch + MovieName; //default to Google search
            if (searchEngine.ToLower().Equals("bing")) url = this.BingSearch + MovieName;
            if (searchEngine.ToLower().Equals("ask")) url = this.AskSearch + MovieName;
            string html = this.getUrlData(url);
            ArrayList imdbUrls = this.matchAll(@"<a href=""(http://www.imdb.com/title/tt\d{7}/)"".*?>.*?</a>", html);
            if (imdbUrls.Count > 0)
                return (string)imdbUrls[0]; //return first IMDb result
            else if (searchEngine.ToLower().Equals("google")) //if Google search fails
                return this.getIMDbUrl(MovieName, "bing"); //search using Bing
            else if (searchEngine.ToLower().Equals("bing")) //if Bing search fails
                return this.getIMDbUrl(MovieName, "ask"); //search using Ask
            else //search fails
                return string.Empty;
        }

        //Parse IMDb page data
        private void parseIMDbPage(string imdbUrl, bool GetExtraInfo)
        {
            string html = this.getUrlData(imdbUrl + "combined");
            this.Id = this.match(@"<link rel=""canonical"" href=""http://www.imdb.com/title/(tt\d{7})/combined"" />", html);
            if (!string.IsNullOrEmpty(this.Id))
            {
                this.status = true;
                this.Title = this.match(@"<title>(IMDb \- )*(.*?) \(.*?</title>", html, 2);
                this.OriginalTitle = this.match(@"title-extra"">(.*?)<", html);
                this.Year = this.match(@"<title>.*?\(.*?(\d{4}).*?\).*?</title>", html);
                this.Rating = this.match(@"<b>(\d.\d)/10</b>", html);
                this.Genres = this.matchAll(@"<a.*?>(.*?)</a>", this.match(@"Genre.?:(.*?)(</div>|See more)", html));
                this.Directors = this.matchAll(@"<td valign=""top""><a.*?href=""/name/.*?/"">(.*?)</a>", this.match(@"Directed by</a></h5>(.*?)</table>", html));
                this.Writers = this.matchAll(@"<td valign=""top""><a.*?href=""/name/.*?/"">(.*?)</a>", this.match(@"Writing credits</a></h5>(.*?)</table>", html));
                this.Producers = this.matchAll(@"<td valign=""top""><a.*?href=""/name/.*?/"">(.*?)</a>", this.match(@"Produced by</a></h5>(.*?)</table>", html));
                this.Musicians = this.matchAll(@"<td valign=""top""><a.*?href=""/name/.*?/"">(.*?)</a>", this.match(@"Original Music by</a></h5>(.*?)</table>", html));
                this.Cinematographers = this.matchAll(@"<td valign=""top""><a.*?href=""/name/.*?/"">(.*?)</a>", this.match(@"Cinematography by</a></h5>(.*?)</table>", html));
                this.Editors = this.matchAll(@"<td valign=""top""><a.*?href=""/name/.*?/"">(.*?)</a>", this.match(@"Film Editing by</a></h5>(.*?)</table>", html));
                this.Cast = this.matchAll(@"<td class=""nm""><a.*?href=""/name/.*?/"".*?>(.*?)</a>", this.match(@"<h3>Cast</h3>(.*?)</table>", html));
                this.Plot = this.match(@"Plot:</h5>.*?<div class=""info-content"">(.*?)(<a|</div)", html);
                this.PlotKeywords = this.matchAll(@"<a.*?>(.*?)</a>", this.match(@"Plot Keywords:</h5>.*?<div class=""info-content"">(.*?)</div", html));
                this.ReleaseDate = this.match(@"Release Date:</h5>.*?<div class=""info-content"">.*?(\d{1,2} (January|February|March|April|May|June|July|August|September|October|November|December) (19|20)\d{2})", html);
                this.Runtime = this.match(@"Runtime:</h5><div class=""info-content"">(\d{1,4}) min[\s]*.*?</div>", html);
                this.Top250 = this.match(@"Top 250: #(\d{1,3})<", html);
                this.Oscars = this.match(@"Won (\d+) Oscars?\.", html);
                if (string.IsNullOrEmpty(this.Oscars) && "Won Oscar.".Equals(this.match(@"(Won Oscar\.)", html))) this.Oscars = "1";
                this.Awards = this.match(@"(\d{1,4}) wins", html);
                this.Nominations = this.match(@"(\d{1,4}) nominations", html);
                this.Tagline = this.match(@"Tagline:</h5>.*?<div class=""info-content"">(.*?)(<a|</div)", html);
                this.MpaaRating = this.match(@"MPAA</a>:</h5><div class=""info-content"">Rated (G|PG|PG-13|PG-14|R|NC-17|X) ", html);
                this.Votes = this.match(@">(\d+,?\d*) votes<", html);
                this.Languages = this.matchAll(@"<a.*?>(.*?)</a>", this.match(@"Language.?:(.*?)(</div>|>.?and )", html));
                this.Countries = this.matchAll(@"<a.*?>(.*?)</a>", this.match(@"Country:(.*?)(</div>|>.?and )", html));
                this.Poster = this.match(@"<div class=""photo"">.*?<a name=""poster"".*?><img.*?src=""(.*?)"".*?</div>", html);
                if (!string.IsNullOrEmpty(this.Poster) && this.Poster.IndexOf("media-imdb.com") > 0)
                {
                    this.Poster = Regex.Replace(this.Poster, @"_V1.*?.jpg", "_V1._SY200.jpg");
                    this.PosterLarge = Regex.Replace(this.Poster, @"_V1.*?.jpg", "_V1._SY500.jpg");
                    this.PosterFull = Regex.Replace(this.Poster, @"_V1.*?.jpg", "_V1._SY0.jpg");
                }
                else
                {
                    this.Poster = string.Empty;
                    this.PosterLarge = string.Empty;
                    this.PosterFull = string.Empty;
                }
                this.ImdbURL = "http://www.imdb.com/title/" + this.Id + "/";
                if (GetExtraInfo)
                {
                    string plotHtml = this.getUrlData(imdbUrl + "plotsummary");
                    this.Storyline = this.match(@"<p class=""plotpar"">(.*?)(<i>|</p>)", plotHtml);
                    this.ReleaseDates = this.getReleaseDates();
                    this.MediaImages = this.getMediaImages();
                    this.RecommendedTitles = this.getRecommendedTitles();
                }
            }

        }

        //Get all release dates
        private ArrayList getReleaseDates()
        {
            ArrayList list = new ArrayList();
            string releasehtml = this.getUrlData("http://www.imdb.com/title/" + this.Id + "/releaseinfo");
            foreach (string r in this.matchAll(@"<tr>(.*?)</tr>", this.match(@"Date</th></tr>\n*?(.*?)</table>", releasehtml)))
            {
                Match rd = new Regex(@"<td>(.*?)</td>\n*?.*?<td align=""right"">(.*?)</td>", RegexOptions.Multiline).Match(r);
                list.Add(StripHTML(rd.Groups[1].Value.Trim()) + " = " + StripHTML(rd.Groups[2].Value.Trim()));
            }
            return list;
        }

        //Get all media images
        private ArrayList getMediaImages()
        {
            ArrayList list = new ArrayList();
            string mediaurl = "http://www.imdb.com/title/" + this.Id + "/mediaindex";
            string mediahtml = this.getUrlData(mediaurl);
            int pagecount = this.matchAll(@"<a href=""\?page=(.*?)"">", this.match(@"<span style=""padding: 0 1em;"">(.*?)</span>", mediahtml)).Count;
            for (int p = 1; p <= pagecount + 1; p++)
            {
                mediahtml = this.getUrlData(mediaurl + "?page=" + p);
                foreach (Match m in new Regex(@"src=""(.*?)""", RegexOptions.Multiline).Matches(this.match(@"<div class=""thumb_list"" style=""font-size: 0px;"">(.*?)</div>", mediahtml)))
                {
                    String image = m.Groups[1].Value;
                    list.Add(Regex.Replace(image, @"_V1\..*?.jpg", "_V1._SY0.jpg"));
                }
            }
            return list;
        }

        //Get Recommended Titles
        private ArrayList getRecommendedTitles()
        {
            ArrayList list = new ArrayList();
            string recUrl = "http://www.imdb.com/widget/recommendations/_ajax/get_more_recs?specs=p13nsims%3A" + this.Id;
            string json = this.getUrlData(recUrl);
            list = this.matchAll(@"title=\\""(.*?)\\""", json);
            HashSet<String> set = new HashSet<string>();
            foreach (String rec in list) set.Add(rec);
            return new ArrayList(set.ToList());
        }

        /*******************************[ Helper Methods ]********************************/

        //Match single instance
        private string match(string regex, string html, int i = 1)
        {
            return new Regex(regex, RegexOptions.Multiline).Match(html).Groups[i].Value.Trim();
        }

        //Match all instances and return as ArrayList
        private ArrayList matchAll(string regex, string html, int i = 1)
        {
            ArrayList list = new ArrayList();
            foreach (Match m in new Regex(regex, RegexOptions.Multiline).Matches(html))
                list.Add(m.Groups[i].Value.Trim());
            return list;
        }

        //Strip HTML Tags
        static string StripHTML(string inputString)
        {
            return Regex.Replace(inputString, @"<.*?>", string.Empty);
        }

        //Get URL Data
        private string getUrlData(string url)
        {
            WebClient client = new WebClient();
            Random r = new Random();
            //Random IP Address
            client.Headers["X-Forwarded-For"] = r.Next(0, 255) + "." + r.Next(0, 255) + "." + r.Next(0, 255) + "." + r.Next(0, 255);
            //Random User-Agent
            client.Headers["User-Agent"] = "Mozilla/" + r.Next(3, 5) + ".0 (Windows NT " + r.Next(3, 5) + "." + r.Next(0, 2) + "; rv:2.0.1) Gecko/20100101 Firefox/" + r.Next(3, 5) + "." + r.Next(0, 5) + "." + r.Next(0, 5);
            Stream datastream = client.OpenRead(url);
            StreamReader reader = new StreamReader(datastream);
            StringBuilder sb = new StringBuilder();
            while (!reader.EndOfStream)
                sb.Append(reader.ReadLine());
            return sb.ToString();
        }
    }
}