using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Univan.Application.Abstractions.Storage;

namespace Univan.Infrastructure.Storage
{
    public class BlobService : IBlobService
    {
        private const string containerName = "profilephotos"; //Puxar options dps

        private readonly BlobSettings _blobSettings;
        private readonly ILogger<BlobService> _logger;

        public BlobService(ILogger<BlobService> logger, IOptions<BlobSettings> blobSettings)
        {
            _logger = logger;
            _blobSettings = blobSettings.Value;
        }

        public async Task<string> UploadImage(string imageNamePrefix, Stream photoStream)
        {
            BlobServiceClient blobServiceClient = new("connectionString");
            var container = blobServiceClient.GetBlobContainerClient(containerName);

            photoStream.Position = 0;
            string imageName = $"{imageNamePrefix}_{Guid.NewGuid()}"; 
            await container.UploadBlobAsync(imageName, photoStream);
            return FormatBlobUrlName(imageName);
        }

        private string FormatBlobUrlName(string imageName)
        {
            return $"https://{_blobSettings.StorageName}.azure/{_blobSettings.ContainerName}/{imageName}";
        }
    }
}
