namespace Zy.Message.Constraint.Dtos
{
    public class GroupOutputDto:OutputDto
    {
        public string? Name { get; set; }
        public bool IsGroup { get; set; }
        public List<UserOutputDto> Users{ get; set; }
    }
}
