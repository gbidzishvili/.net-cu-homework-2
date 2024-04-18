using Microsoft.EntityFrameworkCore;

namespace Reddit.Reposotories
{
    public class PagedLists<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public PagedLists(int pageNumber, int pageSize, int toatlCount, List<T> items, bool hasPreviousPage, bool hasNextPage)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = toatlCount;
            Items = items;
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
        }
        public async static Task<PagedLists<T>> CreateAsync(IQueryable<T> items, int pageNumber, int pageSize)
        {
            var Items = await items.Skip(pageNumber - 1 * pageSize).Take(pageSize).ToListAsync();
            var totalCount = await items.CountAsync();
            var hasPreviousPage = pageNumber > 1;
            var hasNextPage = pageNumber * pageSize < totalCount;

            return new PagedLists<T>(pageNumber, pageSize, totalCount, Items, hasPreviousPage, hasNextPage);
        }
    }
}
