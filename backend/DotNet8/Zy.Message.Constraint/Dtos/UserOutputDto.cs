namespace Zy.Message.Constraint.Dtos
{
    public class UserOutputDto:OutputDto
    {
        public string Name { get; set; }
        public string Account { get; set; }
        public bool IsOnline { get; set; }
    }
}
