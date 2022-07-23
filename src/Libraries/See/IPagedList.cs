namespace See;

/// <summary>
/// Represents a collection of objects that can be individually accessed by index, plus pagination information.  
/// </summary>
/// <typeparam name="T">The type of elements in the paged list.</typeparam>
public interface IPagedList<T> : IList<T>
{
    /// <summary>
    /// Page index
    /// </summary>
    public int PageIndex { get; }
    
    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; }
    
    /// <summary>
    /// Total count
    /// </summary>
    public int TotalCount { get; }
    
    /// <summary>
    /// Total pages
    /// </summary>
    public int TotalPages { get; }
    
    /// <summary>
    /// Has previous page
    /// </summary>
    public bool HasPreviousPage { get; }
    
    /// <summary>
    /// Has next page
    /// </summary>
    public bool HasNextPage { get; }
}