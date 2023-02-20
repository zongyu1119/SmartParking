using zy.webcore.Share.ZyEfcore;

namespace zy.webcore.share.Repository.EntitiesBase
{
    public interface IEntityInfo
    {
        Operater GetOperater();

        void OnModelCreating(dynamic modelBuilder);
    }
}
