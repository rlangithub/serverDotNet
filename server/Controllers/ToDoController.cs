using DAL.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;
using System.Collections.Generic;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IDALToDo _storeToDo;
        public ToDoController(IDALToDo storeToDo)
        {
            _storeToDo = storeToDo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDo>>>Get()
        {
            List<ToDo> res = await _storeToDo.GetAll();
            if (res.Count > 0)
                return Ok(res);
            return BadRequest();
            
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ToDo value)
        {
            bool res = await _storeToDo.Add(value);
            if (!res)
                return BadRequest();
            return Ok();
        }




        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool res = await _storeToDo.Delete(id);
            
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{value}")]
        public async Task<ActionResult> Update([FromBody] ToDo value)
        {
            bool res = await _storeToDo.Update(value);
            if (!res)
                return BadRequest();
            return Ok(res);
        }
 
    }
}
