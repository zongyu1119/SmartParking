namespace zy.webcore.Share.Application.Utilitys
{
    public class StringUtilly
    {
        /// <summary>
        /// Base64转字符串
        /// </summary>
        /// <param name="Base64Str"></param>
        /// <returns></returns>
        public static string GetStringFromBase64(string Base64Str)
        {
            var res=Encoding.Default.GetString( Convert.FromBase64String(Base64Str));
            return res;
        }
    }
}
