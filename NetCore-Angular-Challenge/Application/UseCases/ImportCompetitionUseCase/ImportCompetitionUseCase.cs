using Application.UoW;
using Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.ImportCompetitionUseCase
{
    public class ImportCompetitionUseCase : IImportCompetitionUseCase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly Header _header = new Header();
        public ImportCompetitionUseCase(IUnitOfWork unitOfWork, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ApiCompleteResponse> Execute(int idCompetition)
        {
            var client = _clientFactory.CreateClient();
            ApiResponseCompetition competition = new ApiResponseCompetition();
            ApiResponseTeams teams = new ApiResponseTeams();

            HttpRequestMessage competitionRequest = GenerateHttpGetRequest($"https://api.football-data.org/v2/competitions/{idCompetition}");
            HttpResponseMessage competitionResponse = await client.SendAsync(competitionRequest);

            if (competitionResponse.IsSuccessStatusCode)
            {
                competition = JsonConvert.DeserializeObject<ApiResponseCompetition>(await competitionResponse.Content.ReadAsStringAsync());

                HttpRequestMessage teamsRequest = GenerateHttpGetRequest($"https://api.football-data.org/v2/competitions/{idCompetition}/teams");
                HttpResponseMessage teamsResponse = await client.SendAsync(teamsRequest);

                if(teamsResponse.IsSuccessStatusCode)
                {
                    teams = JsonConvert.DeserializeObject<ApiResponseTeams>(await teamsResponse.Content.ReadAsStringAsync());

                    foreach(TeamAux team in teams.teams)
                    {
                        HttpRequestMessage playersRequest = GenerateHttpGetRequest($"http://api.football-data.org/v2/teams/{team.Id}");
                        HttpResponseMessage playersResponse = await client.SendAsync(playersRequest);

                        if(playersResponse.IsSuccessStatusCode)
                        {
                            ApiResponsePlayers players = JsonConvert.DeserializeObject<ApiResponsePlayers>(await playersResponse.Content.ReadAsStringAsync());

                            team.Players = players.squad;
                        }
                        else
                        {
                            throw new Exception($"Sorry, something went wrong while requesting players");

                        }
                    }
                }
                else
                {
                    throw new Exception($"Sorry, something went wrong while requesting teams.");
                }
            }
            else
            {
                throw new Exception($"Sorry, something went wrong while requesting competition");
            }

            ApiCompleteResponse response = new ApiCompleteResponse { Competition = competition, Teams = teams.teams };

            return response;
            
        }

        private HttpRequestMessage GenerateHttpGetRequest(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add(_header.name, _header.value);

            return request;
        }
    }
}
