using LinqToDB;
using See.Core;
using See.Data.Extensions;

namespace See.Data;

public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    #region Fields

    private readonly ISeeDataProvider _dataProvider;

    #endregion

    #region Ctor

    public EntityRepository(ISeeDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Get the entity entry
    /// </summary>
    /// <param name="id">Entity entry identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entry
    /// </returns>
    public virtual async Task<TEntity?> GetByIdAsync(int? id)
    {
        if (id is null or 0)
            return null;

        return await Table.FirstOrDefaultAsync(entity => entity.Id == Convert.ToInt32(id));
    }

    /// <summary>
    /// Get entity entries by identifiers
    /// </summary>
    /// <param name="ids">Entity entry identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entries
    /// </returns>
    public virtual async Task<IList<TEntity>> GetByIdsAsync(IList<int>? ids)
    {
        if (!ids?.Any() ?? true)
            return new List<TEntity>();

        return await Table.Where(entity => ids.Contains(entity.Id)).ToListAsync();
    }

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entries
    /// </returns>
    public virtual async Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func = null)
    {
        var query = Table;
        if (func != null)
        {
            query = func(query);
        }

        return await query.ToListAsync();
    }

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entries
    /// </returns>
    public virtual async Task<IList<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>>? func = null)
    {
        var query = Table;
        if (func != null)
        {
            query = await func(query);
        }

        return await query.ToListAsync();
    }

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <returns>Entity entries</returns>
    public virtual IList<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func = null)
    {
        var query = Table;
        if (func != null)
        {
            query = func(query);
        }

        return query.ToList();
    }

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="getOnlyTotalCount">Whether to get only the total number of entries without actually loading data</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the paged list of entity entries 
    /// </returns>
    public virtual async Task<IPagedList<TEntity>> GetAllPagedAsync(
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? func = null,
        int pageIndex = 0, int pageSize = Int32.MaxValue,
        bool getOnlyTotalCount = false)
    {
        var query = Table;
        if (func != null)
        {
            query = func(query);
        }

        return await query.ToPagedListAsync(pageIndex, pageSize, getOnlyTotalCount);
    }

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="getOnlyTotalCount">Whether to get only the total number of entries without actually loading data</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the paged list of entity entries 
    /// </returns>
    public virtual async Task<IPagedList<TEntity>> GetAllPagedAsync(
        Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>>? func = null,
        int pageIndex = 0, int pageSize = Int32.MaxValue,
        bool getOnlyTotalCount = false)
    {
        var query = Table;
        if (func != null)
        {
            query = await func(query);
        }

        return await query.ToPagedListAsync(pageIndex, pageSize, getOnlyTotalCount);
    }

    /// <summary>
    /// Insert the entity entry
    /// </summary>
    /// <param name="entity">Entity entry</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dataProvider.InsertEntityAsync(entity);
    }

    #endregion

    #region Properties

    public virtual IQueryable<TEntity> Table => _dataProvider.GetTable<TEntity>();

    #endregion
}