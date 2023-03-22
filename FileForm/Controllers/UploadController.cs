using FileForm.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileForm.Controllers;

[ApiController]
[Route("blob/")]
public class UploadController : ControllerBase
{
    private readonly IBlobService _blobService;

    public UploadController(IBlobService blobService)
    {
        _blobService = blobService;
    }
    
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file, string email)
    {
        if (!file.FileName.EndsWith(".docx"))
             return BadRequest("File is not .docx");

        await _blobService.UploadFileBlobAsync(file, email);
        return Ok();
    }
}

