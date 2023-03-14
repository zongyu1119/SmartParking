using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zy.webcore.Share.Repository.EntitiesBase
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
