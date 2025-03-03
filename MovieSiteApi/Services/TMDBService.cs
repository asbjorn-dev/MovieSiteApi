using System.Net.Http.Json;
using MovieSiteApi.Interfaces;
using MovieSiteApi.Models;

namespace MovieSiteApi.Services
{
    public class TMDBService : ITMDBService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        // DI for our HttpClient. Has BaseAddress, Accept header(json response), and Authorization header(api key)
        // NOTE for future: In the future, consider putting BaseAddress in program.cs to avoid redundancy with multiple services
        public TMDBService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://api.themoviedb.org/3/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new("application/json"));

            _apiKey = config["TMDB:ApiKey"] ?? throw new Exception("ApiKey is null/not found");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public Task<PopularMoviePaginationResponseModel?> GetPopularMoviesAsync()
        {
            return _httpClient.GetFromJsonAsync<PopularMoviePaginationResponseModel>("movie/popular");
        }

    }
}
