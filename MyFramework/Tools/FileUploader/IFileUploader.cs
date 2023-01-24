using Microsoft.AspNetCore.Http;

namespace MyFramework.Tools.FileUploader
{
    public interface IFileUploader
    {
        public string Upload(IFormFile File, string Path);
    }
}
