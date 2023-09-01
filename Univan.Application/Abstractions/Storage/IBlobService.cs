namespace Univan.Application.Abstractions.Storage
{
    public interface IBlobService
    {
        Task<string> GetUrlProfilePicture(string imageName, Stream photoStream);
    }
}
