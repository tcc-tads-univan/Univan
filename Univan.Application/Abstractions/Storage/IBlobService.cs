namespace Univan.Application.Abstractions.Storage
{
    public interface IBlobService
    {
        Task UploadImage(Stream photoStream);

        Task GetImage(string imageId);
    }
}
