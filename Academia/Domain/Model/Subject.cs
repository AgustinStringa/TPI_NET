using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
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
        public int IdCurriculum { get; set; }

        public virtual Curriculum Curriculum { get; set; }


        public virtual ICollection<Subject> Correlatives { get; set; } = new List<Subject>();


    }
}
