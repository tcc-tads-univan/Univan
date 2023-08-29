namespace Univan.Application.Abstractions.Storage
{
    public interface IBlobService
    {
        Task<string> UploadImage(string imageName, Stream photoStream);
    }
}
