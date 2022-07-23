using System.Linq.Expressions;
using LinqToDB.Data;
using See;

namespace See.Data;

public interface ISeeDataProvider
{
    #region Methods

    /// <summary>
    /// Insert a new entity.
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the entity.
    /// </returns>
    Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary>
    /// Insert a new entity.
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Entity</returns>
    TEntity InsertEntity<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary>
    /// Update record in table, using values from entity parameter.
    /// Record to update identified by matching on primary key value from obj value.
    /// </summary>
    /// <param name="entity">Entity with data to update</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary>
    /// Update records in table, using values from entity parameter.
    /// Records to update identified by matching on primary key value from obj value.
    /// </summary>
    /// <param name="entities">Entities with data to update</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task UpdateEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;

    /// <summary>
    /// Delete record in table.
    /// Record to delete identified by matching on primary key value from obj value.
    /// </summary>
    /// <param name="entity">Entity for delete operation</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;

    /// <summary>
    /// Delete records in table.
    /// </summary>
    /// <param name="entities">Entities for delete operation</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task BulkDeleteEntitiesAsync<TEntity>(IList<TEntity> entities) where TEntity : BaseEntity;

    /// <summary>
    /// Delete records in table by condition.
    /// </summary>
    /// <param name="predicate">A function to test each element for a condition</param>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains the number of deleted records.
    /// </returns>
    Task<int> BulkDeleteEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;

    /// <summary>
    /// Performs bulk insert entities operation
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <param name="entities">Collection of Entities</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    Task BulkInsertEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
    
    /// <summary>
    /// Returns queryable source for specified mapping class for current connection,
    /// mapped to database table or view.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <returns>Queryable source</returns>
    IQueryable<TEntity> GetTable<TEntity>() where TEntity : BaseEntity;
    
    /// <summary>
    /// Executes command asynchronously and returns number of affected records
    /// </summary>
    /// <param name="sql">Command text</param>
    /// <param name="dataParameters">Command parameters</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the number of records, affected by command execution.
    /// </returns>
    Task<int> ExecuteNonQueryAsync(string sql, params DataParameter[] dataParameters);
    
    /// <summary>
    /// Executes command and returns results as collection of values of specified type
    /// </summary>
    /// <typeparam name="T">Result record type</typeparam>
    /// <param name="sql">Command text</param>
    /// <param name="parameters">Command parameters</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the returns collection of query result records
    /// </returns>
    Task<IList<T>> QueryAsync<T>(string sql, params DataParameter[] parameters);

    #endregion
}