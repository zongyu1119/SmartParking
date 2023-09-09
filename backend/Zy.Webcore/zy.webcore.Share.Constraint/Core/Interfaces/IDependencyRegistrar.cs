namespace zy.webcore.Share.Constraint.Core.Interfaces
{
    public interface IDependencyRegistrar
    {
        public string Name { get; }

        public void AddZyWebCore();
    }
}
