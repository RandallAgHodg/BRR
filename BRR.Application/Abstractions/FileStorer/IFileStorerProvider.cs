using CloudinaryDotNet.Actions;

namespace BRR.Application.Abstractions.FileStorer;

public interface IFileStorerProvider
{
    Task<string> UploadImageAsync(ImageUploadParams imageParams);
    Task<string> UploadVideoAsync(VideoUploadParams videoParams);
}
