using System.ComponentModel;

namespace Zy.Shared.Enums
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageEnum
    {
        /// <summary>
        /// 文字
        /// </summary>
        [Description("文字")]
        Text=0,
        /// <summary>
        /// 图片
        /// </summary>
        [Description("图片")]
        Pic=1,
        /// <summary>
        /// 视频
        /// </summary>
        [Description("视频")]
        Video=2,
        /// <summary>
        /// 语音
        /// </summary>
        [Description("语音")]
        Audio=3,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other=4
    }
}
