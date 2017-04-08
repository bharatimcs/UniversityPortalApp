using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using UniversityPortalApp.Core;
using UniversityPortalApp.Infrastructure;

namespace UniversityPortalApp.Web.Areas.Api.Controllers
{
    [EnableCors("*", "*", "*")]
    [CustomActionFilter]
    [HandleExceptions]
    public class StudentApiController : BaseApiController
    {
        private IRepository<Student> StudentRepository;
        public StudentApiController(IRepository<Student> studentRepository)
        {
            this.StudentRepository = studentRepository;
        }

        [Route("Students/api/List")]
        [HttpGet]
        public async Task<IHttpActionResult> GetStudents()
        {
            try
            {
                var result = this.StudentRepository.GetAll;
                var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                return Ok(jsonResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }

        }

        [Route("Students/api/GetStudent/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetStudentById(int id)
        {
            try
            {
                var result = this.StudentRepository.GetById(id);
                var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                return Ok(jsonResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("Students/api/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateStudent(Student student)
        {
            try
            {
                var result = this.StudentRepository.InsertOrEdit(student);
                var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                return Ok(jsonResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("Students/api/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudent(Student student)
        {
            try
            {
                var result = this.StudentRepository.InsertOrEdit(student);
                var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                return Ok(jsonResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [Route("Students/api/Delete/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            try
            {
                this.StudentRepository.Delete(id);
                var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject("Successfully deleted", new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                return Ok(jsonResult);
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
