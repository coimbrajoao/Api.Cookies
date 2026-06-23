using Cookie.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Cookie.Infra.Data.Helpers;

public class PaginationHelper
{
    public static async Task<PagedList<T>> CreateAsync<T>(
        IQueryable<T> source, int pageNumber, int pageSize)  where T : class
    {
        var count = await source.CountAsync();
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        
        return new PagedList<T>(items,pageNumber, pageSize, count);
    }
}