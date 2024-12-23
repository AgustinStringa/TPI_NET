﻿using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientService.StudentCourse
{
	public interface IStudentCourseService
	{
		//TODO: definir que implementacion conservar
		public Task<IEnumerable<ApplicationCore.Model.StudentCourse>> GetByUserId(int id, bool actives = false);
		public Task<IEnumerable<ApplicationCore.Model.StudentCourse>> GetByUserId(int id);
		public Task<IEnumerable<AcademicStatusItem>> GetAcademicStatus(int userId);
		public Task<byte[]> GetReport(int id);
		public Task Create(ApplicationCore.Model.StudentCourse studentCourse);
		public Task QualifyCourse(int studentCourseId, CalificationCourse calification);
		public Task Delete(int id);
	}
}