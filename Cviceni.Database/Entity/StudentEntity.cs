using System.ComponentModel.DataAnnotations.Schema;
using Cviceni.Database.Entity.Base;

namespace Cviceni.Database.Entity;

[Table("Student")]
public class StudentEntity : BaseEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public float AverageScore { get; set; }
    public Guid? ClassEntityId { get; set; }
    public ClassEntity? Class { get; set; }
}