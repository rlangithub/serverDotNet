using DAL.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private readonly IDALPhoto _storePhtot;
        public PhotoController(IDALPhoto storePhtot)
        {
            _storePhtot = storePhtot;
        }


        //getAll
        [HttpGet]
        public List<Photo> Get()
        {
            return _storePhtot.GetAll().Result;
        }

        //get one with ID
        //[HttpGet("{id}")]
        //public ToDo Get(int id)
        //{
        //    return _storeToDo.;
        //}

        // add line הוספת איבקר בטבלה.....
        [HttpPost]
        public bool Add([FromBody] Photo value)
        {
            return _storePhtot.Add(value).Result;

        }

        //delete
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _storePhtot.Delete(id).Result;
        }
    }
}
