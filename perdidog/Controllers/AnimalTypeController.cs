using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using perdidog.Data;
using perdidog.Mappers;
using perdidog.Models.Dtos;

namespace perdidog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalTypeController : ControllerBase
    {

        private readonly ApplicationDBContext context;
        public AnimalTypeController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var animalTypes = this.context.AnimalTypes.ToList();
            return Ok(animalTypes);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var animalType = this.context.AnimalTypes.FirstOrDefault(x => x.Id == id);
            if (animalType == null)
            {
                return NotFound();
            }
            var animalTypeDto = animalType.ToAnimalTypeDto();

            return Ok(animalTypeDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimalTypeDto createAnimalTypeDto)
        {
            var animalTypeModel = createAnimalTypeDto.ToModel();

            context.AnimalTypes.Add(animalTypeModel);
            context.SaveChanges();

            var animalTypeDto = animalTypeModel.ToAnimalTypeDto();

            return CreatedAtAction(nameof(GetById), new { id = animalTypeDto.Id }, animalTypeDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateAnimalTypeDto updateAnimalTypeDto)
        {
            var animalTypeModel = context.AnimalTypes.FirstOrDefault(x => x.Id == id);
            if (animalTypeModel == null)
            {
                return NotFound();
            }
            animalTypeModel.AnimalName = updateAnimalTypeDto.AnimalName;
            context.SaveChanges();

            var animalTypeDto = animalTypeModel.ToAnimalTypeDto();

            return Ok(animalTypeDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var animalTypeModel = context.AnimalTypes.FirstOrDefault(x => x.Id == id);
            if (animalTypeModel == null)
            {
                return NotFound();
            }
            context.AnimalTypes.Remove(animalTypeModel);
            context.SaveChanges();

            return Ok(true);
        }

    };


}
