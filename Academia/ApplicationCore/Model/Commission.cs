using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Model
{
    [Table("comisiones")]
    public class Commission
    {
        [Key]
        [Column("id_comision")]
        public int Id { get; set; }

        [Column("desc_comision")]
        public string Description { get; set; }

		[Column("nivel")]
		public int Level { get; set; }

		[Column("id_plan")]
        [ForeignKey("Curriculum")]
        public int IdCurriculum { get; set; }

        public virtual Curriculum Curriculum { get; set; }
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
