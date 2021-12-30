using Crud_API_Net5.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_API_Net5.Controllers
{
    [EnableCors("AnotherPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly Models.Crud crud;

        public ClienteController()
        {
            crud = new Models.Crud();
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return crud.GetAll();
        }
        [HttpGet("{id}")]
        public Cliente Get(int id)
        {
            return crud.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Cliente Crud)
        {
            if (ModelState.IsValid)
            {
                crud.Add(Crud);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cliente Crud)
        {
            Crud.id = id;
            if (ModelState.IsValid)
            {
                crud.Update(Crud);
            }
        }
        [HttpDelete("{Id}")]
        public void Delete(int Id)
        {
            crud.Delete(Id);
            
        }
    }
}
