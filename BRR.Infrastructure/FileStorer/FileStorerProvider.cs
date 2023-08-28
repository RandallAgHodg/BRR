using BRR.Application.Abstractions.FileStorer;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BRR.Infrastructure.FileStorer;

public sealed class FileStorerProvider : IFileStorerProvider
{
    private readonly Cloudinary _fileStorer;

    public FileStorerProvider(Cloudinary fileStorer) =>
        _fileStorer = fileStorer;
    

    public async Task<string> UploadImageAsync(ImageUploadParams imageParams)
    {
        var result = await _fileStorer.UploadAsync(imageParams); ;

        return result.Url.AbsoluteUri;
    }
}
