﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using perdidog.CustomActionFilters;
using perdidog.Data;
using perdidog.Helpers;
using perdidog.Interfaces;
using perdidog.Mappers;
using perdidog.Models.Domain;
using perdidog.Models.Dtos;

namespace perdidog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {

        private readonly ApplicationDBContext context;
        private readonly IAnimalTypeRepository animalTypeRepository;
        private readonly IMapper mapper;

        public AnimalTypeController(ApplicationDBContext context, IAnimalTypeRepository animalTypeRepository, IMapper mapper)
        {
            this.context = context;
            this.animalTypeRepository = animalTypeRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObjectAnimalType queryObject)
        {
            var animalTypesModel = await animalTypeRepository.GetAllAsync(queryObject);
            var animalTypesDto = mapper.Map<List<AnimalTypesDto>>(animalTypesModel);

            return Ok(animalTypesDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var animalTypeModel = await animalTypeRepository.GetOneAsync(id);
            if (animalTypeModel == null)
            {
                return NotFound();
            }

            var animalTypeDto = mapper.Map<AnimalTypesDto>(animalTypeModel);

            return Ok(animalTypeDto);
        }

        [HttpPost]
        [ValidateModel]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] CreateAnimalTypeDto createAnimalTypeDto)
        {
            var animalTypeModel = mapper.Map<AnimalType>(createAnimalTypeDto);

            await animalTypeRepository.CreateAsync(animalTypeModel);

            var animalTypeDto = mapper.Map<AnimalTypesDto>(animalTypeModel);

            return CreatedAtAction(nameof(GetById), new { id = animalTypeDto.Id }, animalTypeDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        [ValidateModel]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAnimalTypeDto updateAnimalTypeDto)
        {
            var animalTypeModel = await animalTypeRepository.UpdateAsync(id, updateAnimalTypeDto);
            if (animalTypeModel == null)
            {
                return NotFound();
            }
            var animalTypeDto = mapper.Map<AnimalTypesDto>(animalTypeModel);

            return Ok(animalTypeDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var animalTypeModel = await animalTypeRepository.DeleteAsync(id);
            if (animalTypeModel == null)
            {
                return NotFound();
            }
            return Ok(true);
        }

    };


}
