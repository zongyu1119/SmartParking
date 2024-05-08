using Zy.Shared.Enums;

namespace Zy.Message.Constraint.Dtos.ChatDtos
{
    /// <summary>
    /// 服务器接收消息
    /// </summary>
    public class SendMessageInputDto
    {
        public string Message { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageEnum MessageType { get; set; }
        /// <summary>
        /// 接收者ID（群组ID）
        /// </summary>
        public long ReceiveId { get; set; }
    }
    /// <summary>
    /// 服务器下发消息
    /// </summary>
    public class SendMessageOutputDto
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public long Id { get; set; }
        public long SendUserId { get; set; }
        public long ReceiveId { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageEnum MessageType { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
    }
}