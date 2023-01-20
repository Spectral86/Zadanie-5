using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Zadanie_5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Student> _studenci = new List<Student>();//tu można wpisać bazę pobieraną z SQL Server

        [HttpGet("getStudents")]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return _studenci.ToList();
        }

        [HttpPost("createStudent")]
        public void Post([FromBody] Student student)
        {
            _studenci.Add(student);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            Student s = _studenci.FirstOrDefault(x => x.IdStudent == id);
            s.Imie = student.Imie;
            s.Nazwisko=student.Nazwisko;
            s.Adres=student.Adres;
            s.NumerIndeksu=student.NumerIndeksu;
            s.Email=student.Email;
        }

        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
            Student s = _studenci.FirstOrDefault(x => x.IdStudent == id);
            _studenci.Remove(s);
        }
    }
}
