namespace Zy.Message.Repository.Entitys
{
    /// <summary>
    /// 消息
    /// </summary>
    [Table("message")]
    public class Message: FullEntity
    {
        /// <summary>
        /// 消息内容
        /// </summary>
        [Column("content")]
        public string Content { get; set; }
        /// <summary>
        /// 消息内容类型
        /// </summary>
        [Column("message_type")]
        public Shared.Enums.MessageEnum MessageType {  get; set; }
        /// <summary>
        /// 发送时间
        /// </summary>
        [Column("send_time")]
        public DateTime SendTime { get; set; }
        /// <summary>
        /// 接收ID
        /// </summary>
        [Column("receive_id")]
        public long RecriveId { get; set; }
        /// <summary>
        /// 发送人ID
        /// </summary>
        [Column ("send_user")]
        public long SendUserId { get; set; }
    }
}
