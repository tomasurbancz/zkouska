using System.ComponentModel.DataAnnotations.Schema;
using Cviceni.Database.Entity.Base;

namespace Cviceni.Database.Entity;

[Table("Teacher")]
public class TeacherEntity : BaseEntity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Hours { get; set; }
    public ICollection<SubjectEntity> Subjects { get; set; } = new List<SubjectEntity>();
}