using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace FileForm.Services;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
    
    public async Task UploadFileBlobAsync(IFormFile file)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("userdocx");
        var blobClient = containerClient.GetBlobClient(file.FileName);
        await using var data = file.OpenReadStream();
        await blobClient.UploadAsync(data);
    }
}