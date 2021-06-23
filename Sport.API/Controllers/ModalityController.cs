using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sport.API.Contexts;
using Sport.API.Models;
using Sport.API.Repositories;

namespace Sport.API.Controllers
{
    [Route("sport/v1/[controller]")]
    [ApiController]
    public class ModalityController : ControllerBase
    {
        private readonly DatabaseContext _database;

        public ModalityController(DatabaseContext database)
        {
            _database = database;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Modality>>> FindAll()
        {
            var repository = new ModalityRepository(_database);
            var modalities = await repository.FindAll();

            return Ok(modalities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Modality>> FindById(int id)
        {
            var repository = new ModalityRepository(_database);
            var modality = await repository.FindById(id);

            if (modality == null)
            {
                return NotFound();
            }

            return Ok(modality);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Modality modality)
        {
            var repository = new ModalityRepository(_database);

            return Ok(await repository.Add(modality));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Modality modality)
        {
            if (id != modality.Id)
            {
                return BadRequest();
            }

            var repository = new ModalityRepository(_database);

            return Ok(await repository.Update(modality));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id, Modality modality)
        {
            if (id != modality.Id)
            {
                return BadRequest();
            }

            var repository = new ModalityRepository(_database);

            return Ok(await repository.Remove(modality));
        }
    }
}
