namespace Zy.Message.Repository.Entitys
{
    /// <summary>
    /// 聊天组
    /// </summary>
    [Table("chat_group")]
    public class ChatGroup: FullEntity
    {
        /// <summary>
        /// 聊天组名称
        /// </summary>
        [Column("name")]
        [Comment("聊天组名称")]
        public string? GroupName { get; set; }
        /// <summary>
        /// 是否群聊，否则是单聊
        /// </summary>
        [Column("is_group")]
        [Comment("是否群聊(多人聊天)，否则是单聊")]
        public bool IsGroup { get;set; }
    }
}
