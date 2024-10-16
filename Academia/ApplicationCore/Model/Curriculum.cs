﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace ApplicationCore.Model
{
    [Table("planes")]
    public class Curriculum
    {
        [Key]
        [Column("id_plan")]
        public int Id { get; set; }

        [Column("desc_plan")]
        public string Description { get; set; }

        [Column("anio")]
        [AllowNull]
        public int Year { get; set; }

        [Column("resolucion")]
        [AllowNull]
        public string Resolution { get; set; }

        [Column("id_especialidad")]
        public int AreaId { get; set; }

        public Area? Area { get; set; }


        public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

        [NotMapped]
        public int? SubjectsCount { get; set; }
        public virtual ICollection<Commission> Commissions { get; set; } = new List<Commission>();
		[NotMapped]
		public int? CommissionsCount { get; set; }
	}
}
