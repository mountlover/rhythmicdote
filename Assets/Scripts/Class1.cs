using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class TileMap
    {
        public TileMap(string json)
        {
            JObject jObject = JObject.Parse(json);
            height = (int)jObject["height"];
            tileheight = (int)jObject["tileheight"];
            width = (int)jObject["width"];
            layers = (TileLayer[])jObject["layers"].ToArray();
        }

        public int height { get; set; }
        public int width { get; set; }
        public int tileheight { get; set; }
        public Array layers { get; set; }
    }

    public class TileLayer
    {
        public TileLayer(string json)
        {
            JObject jObject = JObject.Parse(json);
            data = (int)jObject["data"];

        }
    }

    // Use
    private void Run()
    {
        string json = @"{""user"":{""name"":""asdf"",""teamname"":""b"",""email"":""c"",""players"":[""1"",""2""]}}";
        User user = new User(json);

        Console.WriteLine("Name : " + user.name);
        Console.WriteLine("Teamname : " + user.teamname);
        Console.WriteLine("Email : " + user.email);
        Console.WriteLine("Players:");

        foreach (var player in user.players)
            Console.WriteLine(player);
    }
}
