using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    [Table("alumnos_inscripciones")]
    public class UserCourse
    {
        [Key]
        [Column("id_inscripcion")]
        public int Id { get; set; }

        [Column("condicion")]
        public string Status { get; set; }

        [Column("nota")]
        [AllowNull]
        public int? Grade { get; set; }

        [Column("id_alumno")]
        public int UserId { get; set; }
        public Student Student { get; set; }


        [Column("id_curso")]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
