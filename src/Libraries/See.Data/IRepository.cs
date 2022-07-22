using See.Core;

namespace See.Data;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    #region Methods

    /// <summary>
    /// Get the entity entry
    /// </summary>
    /// <param name="id">Entity entry identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the entity entry
    /// </returns>
    Task<TEntity?> GetByIdAsync(int? id);

    /// <summary>
    /// Get entity entries by identifiers
    /// </summary>
    /// <param name="ids">Entity entry identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task contains the entity entries
    /// </returns>
    Task<IList<TEntity>> GetByIdsAsync(IList<int>? ids);

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task contains the entity entries
    /// </returns>
    Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func = null);

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task contains the entity entries
    /// </returns>
    Task<IList<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, Task<IQueryable<TEntity>>>? func = null);

    /// <summary>
    /// Get all entity entries
    /// </summary>
    /// <param name="func">Func to select entries</param>
    /// <returns>Entity entries</returns>
    IList<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>>? func = null);

    /// <summary>
    /// Insert the entity entry
    /// </summary>
    /// <param name="entity">Entity entry</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task InsertAsync(TEntity entity);

    #endregion
}