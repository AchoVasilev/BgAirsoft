namespace Services.FileService
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;

    using Data;

    using Microsoft.AspNetCore.Http;

    using Models;

    using Services.FileService.ServiceModels;

    public class FileService : IFileService
    {
        private readonly ApplicationDbContext data;

        public FileService(ApplicationDbContext data)
        {
            this.data = data;
        }

        public async Task<IFileServiceModel> UploadImage(Cloudinary cloudinary, IFormFile image, string folderName)
        {
            if (image == null)
            {
                return null;
            }

            var AllowedExtensions = new[] { "jpg", "png", "gif", "jpeg" };

            var extension = Path.GetExtension(image.FileName).TrimStart('.');

            if (!AllowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            string imageName = image.FileName;

            byte[] destinationImage;
            using (var memoryStream = new MemoryStream())
            {
                await image.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            var imageModel = new ImageServiceModel();
            using (var ms = new MemoryStream(destinationImage))
            {
                // Cloudinary doesn't work with [?, &, #, \, %, <, >]
                imageName = imageName.Replace("&", "And");
                imageName = imageName.Replace("#", "sharp");
                imageName = imageName.Replace("?", "questionMark");
                imageName = imageName.Replace("\\", "right");
                imageName = imageName.Replace("%", "percent");
                imageName = imageName.Replace(">", "greater");
                imageName = imageName.Replace("<", "lower");

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imageName, ms),
                    PublicId = $"{folderName}/{imageName}",
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                imageModel.Extension = extension;
                imageModel.Uri = uploadResult.SecureUrl.AbsoluteUri;
                imageModel.Name = imageName;
            }

            return imageModel;
        }

        public async Task<string> AddImageToDatabase(IFileServiceModel model)
        {
            var image = new Image
            {
                Extension = model.Extension,
                Url = model.Uri,
                Name = model.Name
            };

            await data.Images.AddAsync(image);
            await data.SaveChangesAsync();

            return image.Id;
        }
    }
}
