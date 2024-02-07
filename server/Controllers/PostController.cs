using DAL.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Model;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IDALPost _storePost;
        public PostController(IDALPost storePost)
        {
            _storePost = storePost;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>>Get()
        {
            List<Post> res = await _storePost.GetAll();
            if (res.Count > 0)
                return Ok(res);
            return BadRequest();
            
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] Post value)
        {
            bool res = await _storePost.Add(value);
            if (!res)
                return BadRequest();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool res = await _storePost.Delete(id);
            if (!res)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{value}")]
        public async Task<ActionResult>Update([FromBody] Post value)
        {
            bool res = await _storePost.Update(value);
            if (!res)
                return BadRequest();
            return Ok();
        }
    }
}
