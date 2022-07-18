namespace Services.FileService
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;

    using Microsoft.AspNetCore.Http;

    using Services.FileService.ServiceModels;

    public interface IFileService
    {
        Task<IFileServiceModel> UploadImage(Cloudinary cloudinary, IFormFile image, string folderName);

        Task<string> AddImageToDatabase(IFileServiceModel model);
    }
}
