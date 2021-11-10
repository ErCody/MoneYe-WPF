using System.IO;
using MoneYe_WPF.Model;

namespace MoneYe_WPF.Services
{
    class FileService : IFileService
    {
        public string FilePath { get; set; }

        public void Write(string data, FileMode writeMode = FileMode.Append)
        {
            using var stream = new FileStream(FilePath, writeMode);
            using var writer = new StreamWriter(stream);
            writer.Write(data);
        }

        public string Read()
        {
            using var reader = new StreamReader(FilePath);
            var result = reader.ReadToEnd();
            return result;
        }

        public bool IsExistsOrNotNull()
        {
            if (File.Exists(FilePath))
            {
                var data = File.ReadAllText(FilePath);
                return !string.IsNullOrEmpty(data);
            }

            return false;
        }
    }
}