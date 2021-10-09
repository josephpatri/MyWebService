using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace PeliculasAPI.Utilities
{
    public interface ILocalFileManager
    {
        Task DeleteFIle(string path, string container);
        Task<string> FileEdit(string container, IFormFile file, string path);
        Task<string> FileSave(string container, IFormFile file);
    }
}