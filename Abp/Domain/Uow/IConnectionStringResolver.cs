namespace Abp.Domain.Uow
{
    /// <summary>
    /// 用于在需要数据库连接时获取连接字符串
    /// </summary>
    public interface IConnectionStringResolver
    {
        /// <summary>
        /// Gets a connection string name (in config file) or a valid connection string.
        /// </summary>
        /// <param name="args">Arguments that can be used while resolving connection string.</param>
        string GetNameOrConnectionString(ConnectionStringResolveArgs args);
    }
}