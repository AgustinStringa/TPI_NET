using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
{
    [Table("especialidades")]
    public class Area
    {
        [Key]
        [Column("id_especialidad")]
        public int Id { get; set; }

        [Column("desc_especialidad")]
        public string Description { get; set; }

        public ICollection<Curriculum> Curriculums { get; set; } = new List<Curriculum>();
    }
}
