using Univan.Application.Abstractions.Storage;

namespace Univan.Infrastructure.Storage
{
    public class BlobService : IBlobService
    {
        public Task GetImage(string imageId)
        {
            throw new NotImplementedException();
        }

        public Task UploadImage(Stream photoStream)
        {
            throw new NotImplementedException();
        }
    }
}
