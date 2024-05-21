using Microsoft.EntityFrameworkCore;

namespace Zy.Shared.Entitys
{
    public interface IEntityInfo
    {
       // Operater GetOperater();

        void OnModelCreating(ModelBuilder builder);
    }
}
