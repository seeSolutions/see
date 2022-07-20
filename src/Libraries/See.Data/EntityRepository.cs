using LinqToDB;
using See.Core;

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

    public virtual async Task<TEntity?> GetByIdAsync(int? id)
    {
        if (id is null or 0)
            return null;

        return await Table.FirstOrDefaultAsync(entity => entity.Id == Convert.ToInt32(id));
    }

    public virtual async Task<IList<TEntity>> GetByIdsAsync(IList<int>? ids)
    {
        if (!ids?.Any() ?? true)
            return new List<TEntity>();

        return await Table.Where(entity => ids.Contains(entity.Id)).ToListAsync();
    }

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