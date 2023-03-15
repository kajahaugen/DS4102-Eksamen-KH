#nullable disable
using Microsoft.AspNetCore.Mvc;

namespace MilitaryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly IWebHostEnvironment _hosting; 

    public ImageController(IWebHostEnvironment hosting)
    {
        _hosting = hosting;
    } 

    //POSTE NYE BILDER AV SOLDAT 
    [HttpPost] 
    [Route("[action]")] //https://localhost:7295/Image/PostSoliderImage
    public IActionResult PostSoliderImage(IFormFile file)
    {
            string webRootPath = _hosting.WebRootPath; 
            string absolutePath = Path.Combine($"{webRootPath}/images/soliders/{file.FileName}"); //steg 2
            
            try
            {
                using(var fileStream = new FileStream(absolutePath, FileMode.Create)) //steg 3
                {
                    file.CopyTo(fileStream);
                }
                
                return StatusCode(201);
                
            }
            catch
            {
                return StatusCode(501);
            }
    }

    [HttpPost] 
    [Route("[action]")] //https://localhost:7295/Image/PostWeaponImage
    public IActionResult PostWeaponImage(IFormFile file)
    {
            string webRootPath = _hosting.WebRootPath; 
            string absolutePath = Path.Combine($"{webRootPath}/images/weapons/{file.FileName}"); //steg 2
            
            try
            {
                using(var fileStream = new FileStream(absolutePath, FileMode.Create)) //steg 3
                {
                    file.CopyTo(fileStream);
                }
                
                return StatusCode(201);
                
            }
            catch
            {
                return StatusCode(501);
            }
    }
    

    /* FØR SIKKERHET MED IF KODEN
    public IActionResult PostImage(IFormFile file)
    {
            string webRootPath = _hosting.WebRootPath; //steg 1
            string absolutePath = Path.Combine($"{webRootPath}/images{file.FileName}"); //steg 2
            //steg 1 og 2 sier noe om hvor den skal lagres
            
            using(var fileStream = new FileStream(absolutePath, FileMode.Create)) //steg 3
            {
                file.CopyTo(fileStream);
            }
            //steg 3 lagrer faktisk

            return Ok();
        }
    }
    */
}
