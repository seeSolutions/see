using See.Core;

namespace See.Data;

public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    #region Fields

    private ISeeDataProvider _dataProvider;

    #endregion

    #region Ctor

    public EntityRepository(ISeeDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }

    #endregion

    #region Methods

    public virtual async Task<TEntity> GetByIdAsync(int? id)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IList<TEntity>> GetByIdsAsync(IList<int> ids)
    {
        throw new NotImplementedException();
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        await _dataProvider.InsertEntityAsync(entity);
    }

    #endregion
}