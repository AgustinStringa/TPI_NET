using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
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
        public int IdSubject { get; set; }

        public virtual Subject Subject { get; set; }

        //[Column("id_comision")]
        //public int IdCommition { get; set; }

        //public virtual Commition Comittion { get; set; }
    }
}
