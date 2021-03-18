namespace API.Interfaces
{
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public interface IPhotoService
    {
        /// <summary>Adds the photo asynchronous.</summary>
        /// <param name="file">The file.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        /// <summary>Deletes the photo asynchronous.</summary>
        /// <param name="publicId">The public identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}