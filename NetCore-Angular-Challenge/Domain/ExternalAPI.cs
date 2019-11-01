using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Header
    {
        public string name { get; set; }
        public string value { get; set; }

        public Header()
        {
            name = "X-Auth-Token";
            value = "86aebf1fe1ad42d8b41ad1af52dc8f53";
        }
    }
    public class Status
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class ApiCompleteResponse
    {
        public Status Status { get; set; }
        public CompetitionData Data { get; set; }
    }
    public class CompetitionData
    {
        public ApiResponseCompetition Competition { get; set; }
        public List<TeamAux> Teams { get; set; }
    }
    public class ApiResponseCompetition
    {
        public int id { get; set; }
        public Area area { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }

    public class ApiResponseTeams
    {
        public int count { get; set; }
        public List<TeamAux> teams { get; set; }
    }

    public class ApiResponsePlayers
    {
        public List<Player> squad { get; set; }
    }
    public class TeamAux : Team
    {
        public Area area { get; set; }
    }

    public class Area
    {
        public int id { get; set; }
        public string name { get; set; }
    }

}
