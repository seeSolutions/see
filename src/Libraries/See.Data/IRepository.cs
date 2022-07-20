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

    Task<IList<TEntity>> GetByIdsAsync(IList<int>? ids);

    /// <summary>
    /// Insert the entity entry
    /// </summary>
    /// <param name="entity">Entity entry</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task InsertAsync(TEntity entity);

    #endregion
}