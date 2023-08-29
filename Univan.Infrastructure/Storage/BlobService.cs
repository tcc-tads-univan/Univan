using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Univan.Application.Abstractions.Storage;

namespace Univan.Infrastructure.Storage
{
    public class BlobService : IBlobService
    {
        private const string containerName = "profilephotos"; //Puxar options dps

        private readonly ILogger<BlobService> _logger;

        public BlobService(ILogger<BlobService> logger)
        {
            _logger = logger;
        }

        public async Task<string> UploadImage(string imageNamePrefix, Stream photoStream)
        {
            BlobServiceClient blobServiceClient = new("connectionString");
            var container = blobServiceClient.GetBlobContainerClient(containerName);

            photoStream.Position = 0;
            string imageName = $"{imageNamePrefix}_{Guid.NewGuid()}"; 
            await container.UploadBlobAsync(imageName, photoStream);
            return ""; //storageName + container + fileName Colocar em options
        }
    }
}
