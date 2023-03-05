using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Options
{
    /// <summary>
    /// JWT
    /// </summary>
    public class JwtOption
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public long Expires { get; set; }
        public string Audience { get; set; }
    }
}
