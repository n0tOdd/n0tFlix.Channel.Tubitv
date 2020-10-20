using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace JsonTester
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            dynamic test = JObject.Parse(new WebClient().DownloadString("https://tubitv.com/oz/containers/action/content?parentId=&cursor=10&limit=500&isKidsModeEnabled=false&expand=0"));

            foreach (dynamic jObject in test.contents)
            {
                try
                {
                    string id = jObject.Value.id;
                    string title = jObject.Value.title;
                    string decription = jObject.Value.description;
                    List<string> Tags = new List<string>();
                    foreach (dynamic jj in jObject.Value.tags)
                        Tags.Add(jj.Value);
                    List<string> Genres = new List<string>();
                    foreach (dynamic jj in jObject.Value.tags)
                        Genres.Add(jj.Value);
                    List<string> Directors = new List<string>();
                    foreach (dynamic director in jObject.Value.directors)
                        Directors.Add(director.Value);
                    List<string> Actors = new List<string>();
                    foreach (dynamic actor in jObject.Value.actors)
                        Actors.Add(actor.Value);
                    List<string> PosterArt = new List<string>();
                    foreach (dynamic art in jObject.Value.posterarts)
                        PosterArt.Add(art.Value);
                    List<string> thumbnails = new List<string>();
                    foreach (dynamic art in jObject.Value.thumbnails)
                        thumbnails.Add(art.Value);
                    string language = jObject.Value.lang;
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}