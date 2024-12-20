using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using perdidog.Models.Domain;
using perdidog.Models.Dtos;

namespace perdidog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto requestDto)
        {
            ValidateFileUpload(requestDto);

            if (ModelState.IsValid)
            {
                var imageModel = new Image {
                    File = requestDto.File,
                    FileExtension = Path.GetExtension(requestDto.FileName),
                    FileSizeInBytes = requestDto.File.Length,
                    FileName = requestDto.FileName,
                    FileDescription = requestDto.FileDescription
                };
                

            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto requestDto)
        {
            var allowedExtensions = new String[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(requestDto.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if (requestDto.File.Length > 10485760)//10mb
            {
                ModelState.AddModelError("file", "Size cannot be longer than 10 MB");
            }


        }

    }
}
