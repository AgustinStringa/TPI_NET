using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Model
{
    [Table("correlatividades")]
    [PrimaryKey(nameof(SubjectId), nameof(CorrelativeId))]
    public class Correlative
    {
        [Column("id_materia")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [Column("id_correlativa")]
        public int CorrelativeId { get; set; }
        public virtual Subject CorrelativeSubject { get; set; }

        [Column("para")]
        [AllowNull]
        public string To { get; set; }

        [AllowNull]
        [Column("estado_correlativa")]
        public string Status { get; set; }
    }
}
