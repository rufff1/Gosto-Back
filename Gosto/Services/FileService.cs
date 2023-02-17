using Gosto.Services;
using Gosto.Interfaces;
using System.IO;

namespace Gosto.Services
{
    public class FileService : IFileService
    {
        public string ReadFile(string path, string template)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                template = reader.ReadToEnd();
            }
            return template;
        }
    }
}
