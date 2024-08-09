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

        [NotMapped]
        public string ToStringProperty {  get => this.ToString(); }
        public override string ToString()
        {
            return $"Cursado {Id} idComision {CalendarYear} ";
        }


        //public virtual ICollection<User> Teachers { get; set; } = new List<User>();

        //public virtual ICollection<User> Students { get; set; } = new List<User>();


        //[Column("id_comision")]
        //public int IdCommition { get; set; }

        //public virtual Commition Comittion { get; set; }
    }
}
