using CloudinaryDotNet.Actions;

namespace ShopCourse.Interfaces
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsunc(string publicUrl);
    }
}
