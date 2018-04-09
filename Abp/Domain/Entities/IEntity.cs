namespace Abp.Domain.Entities
{
    /// <summary>
    /// 所有实体必须继承这儿接口
    /// </summary>
    /// <typeparam name="TPrimaryKey">实体的主键类型</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        TPrimaryKey Id { get; set; }

        /// <summary>
        /// 实体是不是临时的 (没有保存到数据库并且没有Id).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        bool IsTransient();
    }
}