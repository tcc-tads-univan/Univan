﻿using Azure.Storage.Blobs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Univan.Application.Abstractions.Storage;

namespace Univan.Infrastructure.Storage
{
    public class BlobService : IBlobService
    {
        private readonly BlobSettings _blobSettings;
        private readonly ILogger<BlobService> _logger;

        public BlobService(ILogger<BlobService> logger, IOptions<BlobSettings> blobSettings)
        {
            _logger = logger;
            _blobSettings = blobSettings.Value;
        }

        public Task<string> GetUrlProfilePicture(string imageName, Stream photoStream)
        {
            if(photoStream != Stream.Null)
            {
                return UploadUserImageAsync(imageName, photoStream);
            }

            return Task.FromResult(GetDefaultUrlImage());
        }

        private async Task<string> UploadUserImageAsync(string imageNamePrefix, Stream photoStream)
        {
            BlobServiceClient blobServiceClient = new(_blobSettings.ConnectionString);
            var container = blobServiceClient.GetBlobContainerClient(_blobSettings.ContainerName);

            photoStream.Position = 0;
            string imageName = $"{imageNamePrefix}_{Guid.NewGuid()}"; 
            await container.UploadBlobAsync(imageName, photoStream);
            return FormatUserUrlImage(imageName);
        }
        public string GetDefaultUrlImage()
        {
            return FormatUserUrlImage("dafault");
        }

        private string FormatUserUrlImage(string imageName)
        {
            return $"https://{_blobSettings.StorageName}.azure/{_blobSettings.ContainerName}/{imageName}";
        }
    }
}
