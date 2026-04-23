using System.ComponentModel.DataAnnotations.Schema;
using Cviceni.Database.Entity.Base;

namespace Cviceni.Database.Entity;

[Table("Subject")]
public class SubjectEntity : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public int Year { get; set; }
    public int Hours { get; set; }
    public ICollection<TeacherEntity> Teachers { get; set; } = new List<TeacherEntity>();
}