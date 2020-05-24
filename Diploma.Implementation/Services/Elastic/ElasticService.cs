using Diploma.Interfaces.Services.Elastic;
using Diploma.Interfaces.Services.Elastic.Dto;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Implementation.Services.Elastic
{
    public class ElasticService : IElasticService
    {
        private readonly string crewAvailabilityIndex = "crew";

        public ElasticService(ElasticClient elasticClient)
        {
            this.ElasticClient = elasticClient;
        }

        public ElasticClient ElasticClient { get; set; }

        public async Task<List<CrewAvailability>> SearchCrews()
        {
            var searchRequest = new SearchRequest<CrewAvailability>(Indices.Parse(crewAvailabilityIndex))
            {
                Query = new MatchAllQuery()
            };

            var response = await this.ElasticClient.SearchAsync<CrewAvailability>(searchRequest);

            return response.Documents.ToList();
        }

        public async Task<CrewAvailability> SearchCrew(int id)
        {
            var searchRequest = new SearchRequest<CrewAvailability>(Indices.Parse(crewAvailabilityIndex))
            {
                Query = new MatchQuery
                {
                    Field = Infer.Field<CrewAvailability>(f => f.CrewId),
                    Query = id.ToString()
                }
            };

            var response = await this.ElasticClient.SearchAsync<CrewAvailability>(searchRequest);

            return response.Documents.First();
        }

        public async Task<bool> CreateOrUpdateCrewAvailability(CrewAvailability crewAvailability)
        {
            var index = await this.ElasticClient.IndexAsync(crewAvailability, idx => idx.Index<CrewAvailability>().Refresh(Elasticsearch.Net.Refresh.True));

            return index.IsValid;
        }
    }
}
