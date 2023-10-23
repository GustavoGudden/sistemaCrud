using sistemaCrud.Enums;

namespace sistemaCrud.Models
{
    public class TaskModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Description { get; set; }
        public EnumsTask Status { get; set; }

    }
}
