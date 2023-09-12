using zy.webcore.Share.ZyEfcore;

namespace zy.webcore.Share.Repository.EntitiesBase
{
    public interface IEntityInfo
    {
        Operater GetOperater();

        void OnModelCreating(dynamic modelBuilder);
    }
}
