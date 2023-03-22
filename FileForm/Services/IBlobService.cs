namespace FileForm.Services;

public interface IBlobService
{
    public Task UploadFileBlobAsync(IFormFile file);
}