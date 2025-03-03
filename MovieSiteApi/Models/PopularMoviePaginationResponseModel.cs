using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieSiteApi.Models
{
    public class PopularMoviePaginationResponseModel
    {
        // Naming convention is snake_case, we should make it PascalCase for good practice in our app.
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")] 
        public IEnumerable<PopularMovie> Results { get; set; } = []; // Default to empty array instead of null

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
