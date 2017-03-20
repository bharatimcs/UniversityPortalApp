using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using UniversityPortalApp.Core;
using UniversityPortalApp.Infrastructure;

namespace UniversityPortalApp.Web.Controllers
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

        [Route("api/Student/GetStudents")]
        [HttpGet]
        public async Task<IHttpActionResult> GetStudents()
        {
            var result = this.StudentRepository.GetAll;
            var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return Ok(jsonResult);
        }

        [Route("api/Student/GetStudent/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetStudentById(int id)
        {
            var result = this.StudentRepository.GetById(id);
            var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return Ok(jsonResult);
        }
        [Route("api/Student/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateStudent(Student student)
        {
            var result = this.StudentRepository.InsertOrEdit(student);
            var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return Ok(jsonResult);
        }

        [Route("api/Student/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateStudent(Student student)
        {
            var result = this.StudentRepository.InsertOrEdit(student);
            var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(result, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return Ok(jsonResult);
        }

        [Route("api/Student/Delete/{id}")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            this.StudentRepository.Delete(id);
            var jsonResult = await Task.Factory.StartNew(() => JsonConvert.SerializeObject("Successfully deleted", new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
            return Ok(jsonResult);
        }
    }
}
