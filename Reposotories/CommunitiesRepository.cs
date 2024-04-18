using Reddit.Models;

namespace Reddit.Reposotories
{
    public class CommunitiesRepository :ICommunitiesRepository
    {
        private readonly ApplicationDbContext _context;

        public CommunitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedLists<Community>> getCommunities(int pageNumber, int pageSize,string? searchKey)
        {
            var communities = _context.Communities.AsQueryable();
            if(!string.IsNullOrEmpty(searchKey))
            {
                communities = communities.Where(communities => communities.Name == searchKey || communities.Description == searchKey);
            }
            return await PagedLists<Community>.CreateAsync(communities, pageNumber, pageSize);
        }
    }
}
