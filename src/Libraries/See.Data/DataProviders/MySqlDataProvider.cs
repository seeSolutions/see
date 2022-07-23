using System.Data.Common;
using LinqToDB;
using LinqToDB.DataProvider;
using LinqToDB.DataProvider.MySql;
using LinqToDB.Mapping;
using Microsoft.Extensions.Configuration;
using MySqlConnector;

namespace See.Data.DataProviders;

public class MySqlDataProvider : BaseDataProvider, ISeeDataProvider
{
    #region Ctor

    public MySqlDataProvider(IConfiguration configuration, MappingSchema mappingSchema)
    {
        Configuration = configuration;
        MappingSchema = mappingSchema;
    }

    #endregion

    #region Utils
    
    protected override DbConnection GetInternalDbConnection(string connectionString)
    {
        if (connectionString == null)
            throw new ArgumentNullException(nameof(connectionString));

        return new MySqlConnection(connectionString);
    }

    #endregion


    #region Properties

    /// <summary>
    /// MySql data provider
    /// </summary>
    protected override IDataProvider LinqToDbDataProvider => MySqlTools.GetDataProvider(ProviderName.MySqlConnector);

    /// <summary>
    /// Configuration
    /// </summary>
    protected override IConfiguration Configuration { get; }

    /// <summary>
    /// MappingSchema
    /// </summary>
    protected override MappingSchema MappingSchema { get; }

    #endregion
}