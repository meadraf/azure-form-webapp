using Microsoft.AspNetCore.Mvc;

namespace FileForm.Controllers;

[ApiController]
[Route("blob")]
public class UploadController : ControllerBase
{
    [HttpGet("/upload")]
    public IActionResult UploadFile(IFormFile file, string email)
    {
        return Ok();
    }
}

