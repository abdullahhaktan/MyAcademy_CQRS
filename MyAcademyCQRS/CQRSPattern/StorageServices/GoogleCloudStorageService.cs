using Google.Cloud.Storage.V1;

namespace MyAcademyCQRS.CQRSPattern.StorageServices
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string folder = null);
    }
    public class GoogleCloudStorageService : IFileStorageService
    {
        private readonly string _bucketName;
        private readonly StorageClient _storageClient;

        public GoogleCloudStorageService(IConfiguration configuration)
        {
            _bucketName = configuration["GCS:BucketName"];
            _storageClient = StorageClient.Create(
                Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(configuration["GCS:CredentialsJsonPath"])
            );
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder = null)
        {
            var objectName = folder == null
                ? Guid.NewGuid() + Path.GetExtension(file.FileName)
                : $"{folder}/{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            using var stream = file.OpenReadStream();
            await _storageClient.UploadObjectAsync(_bucketName, objectName, file.ContentType, stream);

            return $"https://storage.googleapis.com/{_bucketName}/{objectName}";
        }
    }
}
