namespace Zy.Message.Respository.Entitys
{
    /// <summary>
    /// 聊天组用户
    /// </summary>
    [Table("group_user")]
    public class GroupUser: FullEntity
    {
        /// <summary>
        /// 聊天组ID
        /// </summary>
        [Column("group_id")]
        public long GroupId { get; set; }
        /// <summary>
        /// 用户ID 
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }
    }
}
