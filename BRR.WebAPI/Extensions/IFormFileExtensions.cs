using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BRR.WebAPI.Extensions;

public static class IFormFileExtensions
{
    public static ImageUploadParams ToImageUploadParams(this IFormFile file)
    {
        return new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, file.OpenReadStream())
        };
    }

    public static VideoUploadParams ToVideoUploadParams(this IFormFile file)
    {
        return new VideoUploadParams()
        {
            File = new FileDescription(file.FileName, file.OpenReadStream()),
        };
    }
}
