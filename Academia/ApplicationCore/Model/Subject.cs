using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    [Table("materias")]
    public class Subject
    {
        [Key]
        [Column("id_materia")]
        public int Id { get; set; }

        [Column("desc_materia")]
        public string Description { get; set; }

        [Column("hs_semanales")]
        public int WeeklyHours { get; set; }

        [Column("hs_totales")]
        public int TotalHours { get; set; }

        [Column("nivel")]
        public int Level { get; set; }

        [Column("id_plan")]
        [ForeignKey("Curriculum")]
        public int IdCurriculum { get; set; }

        public virtual Curriculum? Curriculum { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
        
        [NotMapped]
        public int? CoursesCount {  get; set; }
        
        public ICollection<Correlative> CorrelativesParents { get; set; } = new List<Correlative>();
        public ICollection<Correlative> CorrelativesChildren { get; set; } = new List<Correlative>();

    }
}
