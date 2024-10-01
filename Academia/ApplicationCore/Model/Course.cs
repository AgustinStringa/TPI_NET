using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    [Table("cursos")]
    public class Course
    {
        [Key]
        [Column("id_curso")]
        public int Id { get; set; }

        [Column("anio_calendario")]
        public string CalendarYear { get; set; }

        [Column("cupo")]
        public int Capacity { get; set; }

        [Column("id_materia")]
        [ForeignKey("Subject")]
        public int IdSubject { get; set; }

        public virtual Subject? Subject { get; set; }

        [NotMapped]
        public string? ToStringProperty {  get => this.ToString(); }
        public override string ToString()
        {
            if (Commission != null) { 
            return $"{Commission.Description} {CalendarYear} ";
            
            }
            return $" {CalendarYear} ";


		}
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

        //public virtual ICollection<User> Students { get; set; } = new List<User>();


        [Column("id_comision")]
        [ForeignKey("Commission")]
        public int IdCommission { get; set; }

        public virtual Commission? Commission { get; set; }
    }
}
