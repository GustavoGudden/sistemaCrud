using System.ComponentModel;

namespace sistemaCrud.Enums
{
    public enum EnumsTask
    {
        [Description("A fazer")]
        inconplete = 1,
        [Description("Em andamento")]
        inProgress = 2,
        [Description("concluido")]
        finish = 3,
    }
}
