using ApplicationCore.Model;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iText.Html2pdf;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace API.Controllers
{
    [Route("api/student-courses")]
    [ApiController]
    public class StudentCourseController : Controller
    {
        private readonly StudentCourseService studentCourseService;

        public StudentCourseController(StudentCourseService studentCourseService)
        {
            this.studentCourseService = studentCourseService;
        }

        [HttpGet("academic-status/{id}")]
        public async Task<ActionResult> GetEstadoAcademico(int id)
        {
            try
            {
                var studentCourses = await studentCourseService.GetAcademicStatus(id);
                return Ok(studentCourses);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

        [HttpGet("report/{id}")]
        public async Task<ActionResult<object>> GenerateReport(int id)
        {
            try
            {
                var studentCourses = await studentCourseService.GetAcademicStatus(id);

                if (studentCourses == null)
                {
                    return NotFound();
                }

                byte[] pdfReport = await studentCourseService.GetAcademicStatusReport(id);
                return File(pdfReport, "application/pdf", $"reporte_estudiante_{id}.pdf");
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpGet("${id}")]
        public async Task<ActionResult<StudentCourse>> GetById(int id)
        {
            try
            {
                var studentCourse = await studentCourseService.GetById(id);
                if(studentCourse == null)
                {
                    return NotFound();
                }
                return Ok(studentCourse);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }

        [HttpPost]
        public async Task<ActionResult<StudentCourse>> Create(StudentCourse newStudentCourse)
        {
            try
            {
                await studentCourseService.Create(newStudentCourse);
                return CreatedAtAction(nameof(GetById), new { id = newStudentCourse.Id }, newStudentCourse);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
                throw e;
            }
        }


        //delete -> para permitir a usuario desinscribirse
        //validar que el usuario sea el propietario del cursado a eliminar
        //recibir en el cuerpo del delete o de algun modo
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletedStudentCourse = await studentCourseService.GetById(id);
                if (deletedStudentCourse == null)
                {
                    return NotFound();
                }
                await studentCourseService.Delete(deletedStudentCourse.Id);
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }


        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StudentCourse>>> GetActivesByUserId([FromQuery] int? userId = null)
        {
            try
            {
                if (userId != null)
                {
                    var studentCourses = await studentCourseService.GetByUserId((int)userId);

                    if (studentCourses == null)
                    {
                        return NotFound(new { message = "there is no inscriptions for this student" });
                    }
                    return Ok(studentCourses);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

        [HttpPatch("{studentCourseId}")]
        public async Task<ActionResult<StudentCourse>> QualifyCourse(int studentCourseId, CalificationCourse calification)
        {
            try
            {
                var studentCourse = await studentCourseService.GetById(studentCourseId);

                if (studentCourse == null)
                {
                    return NotFound(new { message = "inscription not found" });
                }
                var updatedStudentCourse = await studentCourseService.QualifyCourse(studentCourseId, calification);

                return Ok(updatedStudentCourse);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }

    }

}
