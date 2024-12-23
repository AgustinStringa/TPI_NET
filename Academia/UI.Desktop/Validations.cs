﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UI.Desktop
{
	public class Validations

	{
		public static bool IsValidEmail(string email)
		{

			string pattern = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+\.[a-zA-Z]{2,63}(?:\.[a-zA-Z]{2,63})?$";

			Regex regex = new Regex(pattern);
			return regex.IsMatch(email) && !string.IsNullOrWhiteSpace(email);
		}

		public static bool IsValidUsername(string username)
		{
			string value = username.Trim();
			if (value.Length < 4) return false;

			string pattern = @"^[a-zA-Z]+$";
			Regex regex = new Regex(pattern);

			return regex.IsMatch(value);
		}

		public static bool IsValidCuit(string cuit)
		{
			cuit = cuit.Trim();
			if (cuit.Length <= 0) return false;
			var validLong = (cuit.Length == 11 || cuit.Length == 13);
			if (!validLong) return false;

			if (cuit.Length == 13)
			{
				if (cuit[2] == '-' && cuit[11] == '-')
				{

					cuit = cuit.Replace("-", "");
				}

			}
			if (cuit.Length != 11) return false;
			return true;
		}


		public static bool IsValidName(string name)
		{
			name = name.Trim();
			name = name.Replace(".", "");

			string pattern = @"^[a-zA-ZáéíóúÁÉÍÓÚ]+(?:\s[a-zA-ZáéíóúÁÉÍÓÚ]+)*$";

			Regex regex = new Regex(pattern);

			return regex.IsMatch(name);
		}

		public static bool IsValidLastname(string lastname)
		{
			string value = lastname.Trim();
			if (value.Length <= 1) return false;

			string pattern = @"^[a-zA-ZáéíóúÁÉÍÓÚ]+(?: [a-zA-ZáéíóúÁÉÍÓÚ]+)*$";

			Regex regex = new Regex(pattern);

			return regex.IsMatch(value);
		}

		public static bool IsValidPassword(string password)
		{
			string value = password.Trim();
			string pattern = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚ]+(?: [a-zA-Z0-9áéíóúÁÉÍÓÚ]+)*$";

			Regex regex = new Regex(pattern);

			return regex.IsMatch(value) && !string.IsNullOrWhiteSpace(value);
		}


		public static bool IsValidAddress(string address)
		{
			string value = address.Trim();

			string pattern = @"^[a-zA-Z0-9áéíóúÁÉÍÓÚñÑçÇüÜ,. ]+$";

			Regex regex = new Regex(pattern);

			return regex.IsMatch(value) && !string.IsNullOrWhiteSpace(value);
		}


		public static bool IsValidBirthDate(DateTime birthDate)
		{

			var today = DateTime.Now;
			var age = today.Year - birthDate.Year;

			if (age > 18) return true;
			if (age < 18) return false;

			if (age == 18)
			{
				if ((today.Month <= birthDate.Month &&
					today.Day < birthDate.Day) || today.Month < birthDate.Month)
				{
					age--;
				}
			}

			return age >= 18;
		}

		public static int GetEdad(DateTime birthDate)
		{
			var today = DateTime.Now;
			var age = today.Year - birthDate.Year;

			if (age == 18)
			{
				if ((today.Month <= birthDate.Month &&
					today.Day < birthDate.Day) || today.Month < birthDate.Month)
				{
					age--;
				}
			}

			return age;
		}


		public static bool IsValidPhoneNumber(string phonenumber)
		{
			phonenumber = phonenumber.Trim();
			if (phonenumber.Length <= 0) return false;

			string pattern = @"^\d{1,15}$";
			Regex regex = new Regex(pattern);

			return regex.IsMatch(phonenumber);
		}


		public static bool IsValidStudentId(string studentid)
		{
			studentid = studentid.Trim();
			if (studentid.Length <= 0) return false;

			string pattern = @"^\d{1,15}$";
			Regex regex = new Regex(pattern);

			return regex.IsMatch(studentid);
		}
	}
}
