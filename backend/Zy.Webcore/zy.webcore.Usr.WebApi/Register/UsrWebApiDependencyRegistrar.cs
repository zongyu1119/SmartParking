using zy.webcore.Share.WebApi.Register;

namespace zy.webcore.Usr.WebApi.Register
{
    public class UsrWebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
    {
        public UsrWebApiDependencyRegistrar(WebApplication app) : base(app) { }
        public override void UseZyWebCore()
        {
            UseWebApiDefault();
        }
    }
}
