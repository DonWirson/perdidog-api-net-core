using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        private readonly ILogger<LostPetController> logger;

        public LostPetController(ApplicationDBContext context,
            ILostPetRepository lostPetRepo,
            IMapper mapper,
            ILogger<LostPetController> logger)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
            _lostPetRepo = lostPetRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectLostPet queryObject)
        {
            logger.LogInformation("GetAll Action Method was invoked");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lostPets = await _lostPetRepo.GetAllAsync(queryObject);

            logger.LogInformation($"Finished GetAllLostPets request with data: {JsonSerializer.Serialize(lostPets)}");

            return Ok(mapper.Map<List<LostPetDto>>(lostPets));
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            logger.LogInformation("GetByIdLostPet Action Method was invoked");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lostPet = await _lostPetRepo.GetOneAsync(id);
            if (lostPet == null)
            {
                return NotFound();
            }
            logger.LogInformation($"Finished GetByIdLostPets request with data: {JsonSerializer.Serialize(lostPet)}");

            return Ok(mapper.Map<LostPetDto>(lostPet));
        }

        
        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] CreateLostPetDto createLostPetDto)
        {
            logger.LogInformation("GetById Action Method was invoked");


            var lostPetModel = mapper.Map<LostPet>(createLostPetDto);
            await _lostPetRepo.CreateAsync(lostPetModel);

            logger.LogInformation("Finished CreateLostPets request");

            return CreatedAtAction(nameof(GetById), new { id = lostPetModel.Id }, lostPetModel.ToLostPetDto());
        }


        [HttpDelete("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            logger.LogInformation("DeleteLostPet Action Method was invoked");

            var lostPetModel = await _lostPetRepo.DeleteAsync(id);
            if (lostPetModel == null)
            {
                return NotFound();
            }

            logger.LogInformation("Finished DeleteLostPet request");

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ValidateModel]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateLostPetDto updateLostPetDto)
        {
            logger.LogInformation("UpdateLostPet Action Method was invoked");

            var lostPetModel = await _lostPetRepo.UpdateAsync(id, updateLostPetDto);
            if (lostPetModel == null)
            {
                return NotFound();
            }

            logger.LogInformation($"Finished UpdateLostPet lostPetModel with data {lostPetModel}");

            return Ok(mapper.Map<LostPetDto>(lostPetModel));
        }
    }
}