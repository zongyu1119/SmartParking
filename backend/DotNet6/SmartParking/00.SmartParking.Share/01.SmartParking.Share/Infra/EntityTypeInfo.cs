using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Infra
{
    public class EntityTypeInfo
    {
        public Type Type { get; set; }

        public IEnumerable<object>? DataSeeding { get; set; }
    }
}
