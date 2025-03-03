using MovieSiteApi.Models;

namespace MovieSiteApi.Interfaces
{
    public interface ITMDBService
    {
        Task<PopularMoviePaginationResponseModel?> GetPopularMoviesAsync();
    }
}
