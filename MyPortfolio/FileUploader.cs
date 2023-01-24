using MyFramework.Tools.Conversions;
using MyFramework.Tools.FileUploader;

namespace MyPortfolio
{
    public class FileUploader : IFileUploader
    {
        private readonly IWebHostEnvironment _webHost;

        public FileUploader(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }

        public string Upload(IFormFile file, string Path)
        {
            if (file is null) return "";

            var DirectoryPath = $"{_webHost.WebRootPath}//Photos/{Path}";

            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            var FileName = $"{DateTime.Now.ToFileName()}-{file.FileName}";
            var FilePath = $"{DirectoryPath}//{FileName}";

            using var Output = File.Create(FilePath);

            file.CopyTo(Output);

            return $"{Path}/{FileName}";
        }
    }
}
