using LinqToDB;
using See;

namespace See.Data.Extensions;

public static class AsyncIQueryableExtensions
{
    /// <summary>
    /// To paged list
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records</param>
    /// <typeparam name="T">Type</typeparam>
    /// <returns>A task that represents the asynchronous operation</returns>
    public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageIndex, int pageSize,
        bool getOnlyTotalCount = false)
    {
        // min allowed page size is 1
        pageSize = Math.Max(pageSize, 1);

        var count = await source.CountAsync();

        var data = new List<T>();

        if (!getOnlyTotalCount)
        {
            data.AddRange(await source.Skip(pageIndex * pageSize).Take(pageSize).ToListAsync());
        }

        return new PagedList<T>(data, pageIndex, pageSize, count);
    }
}