﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Model
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
		public string? Password { get; set; }


		[Column("nombre")]
		public string Name { get; set; }

		[Column("apellido")]
		public string Lastname { get; set; }

		[Column("email")]
		public string Email { get; set; }


		[Column("telefono")]
		public string PhoneNumber { get; set; }


		[Column("direccion")]
		public string Address { get; set; }


		[Column("fecha_nacimiento")]
		public DateTime BirthDate { get; set; }


	}
}
