using Reddit.Models;

namespace Reddit.Reposotories
{
    public interface ICommunitiesRepository
    {
        public Task<PagedLists<Community>> getCommunities(int pageNumber, int pageSize,string? searchKey);
    }
}
