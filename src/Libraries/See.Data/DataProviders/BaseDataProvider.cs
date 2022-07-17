using System.Data.Common;
using System.Linq.Expressions;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using Microsoft.Extensions.Configuration;
using See.Core;

namespace See.Data.DataProviders;

public abstract class BaseDataProvider
{
    #region Fields

    #endregion

    #region Utils

    protected abstract DbConnection GetInternalDbConnection(string connectionString);

    protected virtual DataConnection CreateDataConnection()
    {
        return CreateDataConnection(LinqToDbDataProvider);
    }

    protected virtual DataConnection CreateDataConnection(IDataProvider dataProvider)
    {
        if (dataProvider == null)
        {
            throw new ArgumentNullException(nameof(dataProvider));
        }

        var dataConnection = new DataConnection(dataProvider, CreateDbConnection());
        return dataConnection;
    }

    protected virtual DbConnection CreateDbConnection(string? connectionString = null)
    {
        var dbConnection =
            GetInternalDbConnection(!string.IsNullOrEmpty(connectionString) ? connectionString : GetConnectString());
        return dbConnection;
    }

    #endregion

    #region Methods

    public async Task<TEntity> InsertEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        await using var dataContext= CreateDataConnection();
        entity.Id = await dataContext.InsertWithInt32IdentityAsync(entity);
        return entity;
    }
    

    public TEntity InsertEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task UpdateEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task UpdateEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task DeleteEntityAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task BulkDeleteEntitiesAsync<TEntity>(IList<TEntity> entities) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task<int> BulkDeleteEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task BulkInsertEntitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetTable<TEntity>() where TEntity : BaseEntity
    {
        throw new NotImplementedException();
    }

    public Task<int> ExecuteNonQueryAsync(string sql, params DataParameter[] dataParameters)
    {
        throw new NotImplementedException();
    }

    public Task<IList<T>> QueryAsync<T>(string sql, params DataParameter[] parameters)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Properties

    /// <summary>
    /// Linq2Db data provider
    /// </summary>
    protected abstract IDataProvider LinqToDbDataProvider { get; }

    /// <summary>
    /// Configuration
    /// </summary>
    protected abstract IConfiguration Configuration { get; }

    /// <summary>
    /// Get database connect string
    /// </summary>
    /// <returns></returns>
    private string GetConnectString()
    {
        return Configuration.GetConnectionString("ConnectString");
    }

    #endregion
}