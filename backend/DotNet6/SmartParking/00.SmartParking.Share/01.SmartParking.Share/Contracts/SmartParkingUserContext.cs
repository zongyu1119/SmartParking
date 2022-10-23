using SmartParking.Share.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Share.Contracts
{
    public class SmartParkingUserContext
    {
        public long Id { get; set; }
        public long ExationId { get; set; }
        public string Account { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public long RoleId { get; set; }
        public long? DeptId { get; set; }
        public string Device { get; set; } = string.Empty;
        public string RemoteIpAddress { get; set; } = string.Empty;

        public DataScopeEnum DataScope { get; set; }
        public override string ToString()
        {
            return $"Id={Id},ExationId={ExationId},Account={Account},Name={Name},RoleId={RoleId},DeptId={DeptId},Device={Device},RemoteIpAddress={RemoteIpAddress},DataScope={(int)DataScope}";
        }
    }
}
