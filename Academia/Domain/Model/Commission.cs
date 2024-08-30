﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
    [Table("comisiones")]
    public class Commission
    {
        [Key]
        [Column("id_comision")]
        public int Id { get; set; }

        [Column("desc_comision")]
        public string Description { get; set; }

        [Column("anio_especialidad")]
        public int Year {  get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}