using Application.Repositories;
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
        private readonly ICompetitionRepository _competitionRepository;
        private readonly Header _header = new Header();
        public ImportCompetitionUseCase(ICompetitionRepository competitionRepository, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _competitionRepository = competitionRepository;
        }

        public async Task<ApiCompleteResponse> Execute(int idCompetition)
        {
            if (CheckIfCompetitionExists(idCompetition))
            {
                return new ApiCompleteResponse
                {
                    Status = new Status
                    {
                        StatusCode = 409,
                        Message = "Competition already imported"
                    }
                };
            }
            else
            {
                try
                {
                    Status status = new Status
                    {
                        StatusCode = 201,
                        Message = "Successfully imported"
                    };
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

                        if (teamsResponse.IsSuccessStatusCode)
                        {
                            teams = JsonConvert.DeserializeObject<ApiResponseTeams>(await teamsResponse.Content.ReadAsStringAsync());
                            int counter = 0;

                            foreach (TeamAux team in teams.teams)
                            {
                                //CURRENTLY COMPLETING ONLY THE FIRST 5 TEAMS, IN ORDER TO AVOID A "MULTIPLE REQUESTS MADE" ON FOOTBALL-API
                                if (counter == 5) break;
                                HttpRequestMessage playersRequest = GenerateHttpGetRequest($"http://api.football-data.org/v2/teams/{team.Id}");
                                HttpResponseMessage playersResponse = await client.SendAsync(playersRequest);

                                if (playersResponse.IsSuccessStatusCode)
                                {
                                    ApiResponsePlayers players = JsonConvert.DeserializeObject<ApiResponsePlayers>(await playersResponse.Content.ReadAsStringAsync());

                                    team.Players = players.squad;
                                    counter++;
                                }
                                else
                                {
                                    status.StatusCode = (int)playersResponse.StatusCode;
                                    status.Message = playersResponse.StatusCode.ToString();
                                    break;
                                }
                            }
                        }
                        else
                        {
                            status.StatusCode = (int)teamsResponse.StatusCode;
                            status.Message = teamsResponse.StatusCode.ToString();
                        }
                    }
                    else
                    {
                        status.StatusCode = (int)competitionResponse.StatusCode;
                        status.Message = competitionResponse.StatusCode.ToString();
                    }

                    ApiCompleteResponse response = new ApiCompleteResponse
                    {
                        Status = status,
                        Data = new CompetitionData
                        {
                            Competition = competition,
                            Teams = teams.teams
                        }
                    };

                    return response;

                }
                catch (Exception e)
                {
                    throw new Exception("Server error");
                }
            }
        }

        private bool CheckIfCompetitionExists(int idCompetition)
        {
            Competition competition = _competitionRepository.GetByID(idCompetition);
            return competition != null ? true : false;
        }

        private HttpRequestMessage GenerateHttpGetRequest(string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add(_header.name, _header.value);

            return request;
        }
    }
}
