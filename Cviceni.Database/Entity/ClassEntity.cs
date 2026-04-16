using System.ComponentModel.DataAnnotations.Schema;
using Cviceni.Database.Entity.Base;

namespace Cviceni.Database.Entity;

[Table("Class")]
public class ClassEntity : BaseEntity
{
    public int Year { get; set; }
    public string Code { get; set; }
    public bool RootClassRoom { get; set; }
    public int RootClassRoomCode { get; set; }
}