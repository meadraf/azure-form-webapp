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
    
    public async Task UploadFileBlobAsync(IFormFile file, string email)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("userdocx");
        var blobName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + " " + file.FileName;
        var blobClient = containerClient.GetBlobClient(blobName);
        
        var metaData = new Dictionary<string, string> {["userEmail"] = email};
        
        await using var data = file.OpenReadStream();
        await blobClient.UploadAsync(data);

        try
        {
            await blobClient.SetMetadataAsync(metaData);
        }
        catch(Exception) 
        {
            Console.WriteLine("Bad email value");
        }
    }
}