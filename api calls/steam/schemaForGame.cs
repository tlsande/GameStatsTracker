using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Stats_Tracker.api_calls.steam
{
    [JsonObject(MemberSerialization.OptIn)]
    public class achievementInfo
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("defaultvalue")]
        public string defaultvalue { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("hidden")]
        public bool hidden { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }

        [JsonProperty("icon")]
        public string iconURL { get; set; }

        [JsonProperty("icongray")]
        public string icongreyURL { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class stats
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("defaultvalue")]
        public string defaultValue { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class gameStats
    {
        [JsonProperty("achievements")]
        public IList<achievementInfo> achievements { get; set; }

        [JsonProperty("stats")]
        public IList<stats> stats { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class game
    {
        [JsonProperty("gameName")]
        public string gameName { get; set; }

        [JsonProperty("gameVersion")]
        public string version { get; set; }

        [JsonProperty("availableGameStats")]
        public gameStats gameStats { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class gameInfo
    {
        [JsonProperty("game")]
        public game game { get; set; }
    }
    class schemaForGame
    {
        public static gameInfo getSchemaForGame(string apiKey, string appID, string language)
        //public static string getSchemaForGame(string apiKey, string appID, string language)
        {
            var client = new RestClient("http://api.steampowered.com");
            var request = new RestRequest("ISteamUserStats/GetSchemaForGame/v2/");
            request.AddParameter("key", apiKey, ParameterType.QueryString);
            request.AddParameter("appid", appID, ParameterType.QueryString);
            request.AddParameter("l", language, ParameterType.QueryString);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<gameInfo>(response.Content);
            //return response.Content;
        }
    }
}
