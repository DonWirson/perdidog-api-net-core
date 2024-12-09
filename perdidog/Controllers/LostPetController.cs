using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using perdidog.CustomActionFilters;
using perdidog.Data;
using perdidog.Dtos;
using perdidog.Helpers;
using perdidog.Interfaces;
using perdidog.Mappers;
using perdidog.Models.Domain;

namespace perdidog.Controllers
{
    [Route("api/lost-pet")]
    [ApiController]
    public class LostPetController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        private readonly ILostPetRepository _lostPetRepo;
        private readonly IMapper mapper;

        public LostPetController(ApplicationDBContext context, ILostPetRepository lostPetRepo, IMapper mapper)
        {
            this.context = context;
            _lostPetRepo = lostPetRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Guest,User")]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectLostPet queryObject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lostPets = await _lostPetRepo.GetAllAsync(queryObject);

            var lostPetsDto = mapper.Map<List<LostPetDto>>(lostPets);

            return Ok(lostPetsDto);
        }


        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "Guest,User")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lostPet = await _lostPetRepo.GetOneAsync(id);
            if (lostPet == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LostPetDto>(lostPet));
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] CreateLostPetDto createLostPetDto)
        {

            var lostPetModel = mapper.Map<LostPet>(createLostPetDto);
            await _lostPetRepo.CreateAsync(lostPetModel);

            return CreatedAtAction(nameof(GetById), new { id = lostPetModel.Id }, lostPetModel.ToLostPetDto());
        }


        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var lostPetModel = await _lostPetRepo.DeleteAsync(id);
            if (lostPetModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLostPetDto updateLostPetDto)
        {
            var lostPetModel = await _lostPetRepo.UpdateAsync(id, updateLostPetDto);
            if (lostPetModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LostPetDto>(lostPetModel));
        }
    }
}