﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    [Table("usuarios")]
    public class User
    {
        [Key]
        [Column("id_usuario")]
        public int Id { get; set; }

        [Column("nombre_usuario")]
        public string Username { get; set; }

        [Column("clave")]
        public string Password { get; set; }

        [Column("habilitado")]
        [AllowNull]
        public bool Authorized { get; set; }

        [Column("nombre")]
        public string Name { get; set; }

        [Column("apellido")]
        public string Lastname { get; set; }

        [Column("email")]
        public string Email { get; set; }


        [Column("telefono")]
        public string PhoneNumber { get; set; }

        [Column("legajo")]
        [AllowNull]
        public string StudentId { get; set; }


        [Column("direccion")]
        public string Address { get; set; }


        [Column("fecha_nacimiento")]
        [AllowNull]
        public DateTime BirthDate { get; set; }


        [Column("cuit")]
        [AllowNull]
        public string Cuit { get; set; }

        [Column("tipo_usuario")]
        public int UserType { get; set; }

        #region navigation properties

        [Column("id_plan")]
        [AllowNull]
        public int? CurriculumId { get; set; }
        public virtual Curriculum Curriculum{ get; set; }

        public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
        #endregion
    }
}
