namespace Univan.Infrastructure.Storage
{
    public class BlobSettings
    {
        public const string BlobSectionName = "BlobSettings";
        public string ContainerName { get; set; }
        public string StorageName { get; set; }
        public string ConnectionString { get; set; }
    }
}
