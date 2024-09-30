using ApplicationCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ApplicationCore.Services
{
	public class UserService
	{

		public async Task Create(User user)
		{
			try
			{
				var context = new AcademiaContext();
				await context.Users.AddAsync(user);
				context.SaveChanges();
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async void Delete(User user)
		{
			try
			{
				var context = new AcademiaContext();
				context.Users.Remove(user);
				await context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<IEnumerable<ApplicationCore.Model.User>> GetAll()
		{
			var context = new AcademiaContext();
			return await context.Users.ToListAsync();
		}

		public async Task<ApplicationCore.Model.User> GetById(int id)
		{
			try
			{
				var context = new AcademiaContext();
				var user = await context.Users.FindAsync(id);
				context.Attach(user);
				return user;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<ApplicationCore.Model.User> GetByUsername(string username)
		{
			try
			{
				var context = new AcademiaContext();
				var user = await context.Users.FirstAsync(u => u.Username == username);
				context.Attach(user);
				return user;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async void Update(User User)
		{
			var context = new AcademiaContext();
			try
			{
				context.Users.Update(User);
				context.SaveChanges();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public async Task<User> ValidateCredentials(string username, string password)
		{
			try
			{
				var context = new AcademiaContext();
				ApplicationCore.Model.User user = await context.Users.FirstOrDefaultAsync(u => u.Username == username);
				if (user != null)
				{
					byte[] sentHashValue = Convert.FromHexString(user.Password);
					byte[] messageBytes1 = Encoding.UTF8.GetBytes(password);
					byte[] compareHashValue = SHA256.HashData(messageBytes1);
					if (sentHashValue.SequenceEqual(compareHashValue))
					{
						//await context.Entry(user).Reference(c => c.Curriculum).LoadAsync();
						//await context.Entry(user).Collection(c => c.UserCourses).LoadAsync();
						//foreach (var uc in user.UserCourses)
						//{
						//	await context.Entry(uc).Reference(c => c.Course).LoadAsync();
						//	await context.Entry(uc.Course).Reference(c => c.Subject).LoadAsync();
						//}
						return user;
					}
					else
					{
						return null;
					}

				}
				else
				{
					return null;
				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}



		}

	}
}
