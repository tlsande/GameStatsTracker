using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game_Stats_Tracker.api_calls.steam
{
    [JsonObject(MemberSerialization.OptIn)]
    public class achievement
    {
        [JsonProperty("apiname")]
        public string apiname { get; set; }

        [JsonProperty("achieved")]
        public bool achieved { get; set; }

        [JsonProperty("unlocktime")]
        public int unlockedTime { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("description")]
        public string description { get; set; }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class gameAchievements
    {
        [JsonProperty("steamID")]
        public string steamID { get; set; }

        [JsonProperty("gameName")]
        public string game { get; set; }

        [JsonProperty("achievements")]
        public IList<achievement> achievements { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class player
    {
        [JsonProperty("playerstats")]
        public gameAchievements playertsats { get; set; }
    }

    public static class playerAchievements
    {
        public static player getPlayerAchievements(string apiKey, string steamID, string appID, string language)
        {
            var client = new RestClient("http://api.steampowered.com");
            var request = new RestRequest("ISteamUserStats/GetPlayerAchievements/v1/");
            request.AddParameter("key", apiKey, ParameterType.QueryString);
            request.AddParameter("steamid", steamID, ParameterType.QueryString);
            request.AddParameter("appid", appID, ParameterType.QueryString);
            request.AddParameter("l", language, ParameterType.QueryString);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<player>(response.Content);
        }
    }
}