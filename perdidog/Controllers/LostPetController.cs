using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using perdidog.Data;
using perdidog.Dtos;
using perdidog.Interfaces;
using perdidog.Mappers;

namespace perdidog.Controllers
{
    [Route("api/lost-pet")]
    [ApiController]
    public class LostPetController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ILostPetInterface _lostPetRepo;

        public LostPetController(ApplicationDBContext context, ILostPetInterface lostPetRepo)
        {
            _context = context;
            _lostPetRepo = lostPetRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lostPets = await _lostPetRepo.GetAll();

            var lostPetsDto = lostPets.Select(x => x.ToLostPetDto());

            return Ok(lostPetsDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var lostPet = await _lostPetRepo.GetOne(id);
            if (lostPet == null)
            {
                return NotFound();
            }

            return Ok(lostPet.ToLostPetDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateLostPetDto createLostPetDto)
        {
            var lostPetModel = createLostPetDto.ToModel();
            await _lostPetRepo.Create(createLostPetDto);

            return CreatedAtAction(nameof(GetById), new { id = lostPetModel.Id }, lostPetModel.ToLostPetDto());
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var lostPetModel = await _lostPetRepo.Delete(id);
            if (lostPetModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLostPetDto updateLostPetDto)
        {
            var lostPetModel = await _lostPetRepo.Update(id, updateLostPetDto);
            if (lostPetModel == null)
            {
                return NotFound();
            }

            return Ok(lostPetModel.ToLostPetDto());
        }
    }
}