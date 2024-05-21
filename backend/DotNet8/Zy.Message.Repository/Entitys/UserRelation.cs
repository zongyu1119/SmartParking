namespace Zy.Message.Repository.Entitys
{
    /// <summary>
    /// 用户关系
    /// </summary>
    [Table("user_relation")]
    [Comment("用户关系表")]
    public class UserRelation: FullEntity
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [Column("user_id")]
        public long UserId { get; set; }
        /// <summary>
        /// 好友ID
        /// </summary>
        [Column("friend_user_id")]
        public long FirendUserId { get; set; }
    }
}
