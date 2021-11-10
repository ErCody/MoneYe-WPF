using System.IO;

namespace MoneYe_WPF.Services
{
    public interface IFileService
    {
        public string FilePath { get; set; }
        public void Write(string data, FileMode writeMode = FileMode.Append);
        public string Read();
    }
}