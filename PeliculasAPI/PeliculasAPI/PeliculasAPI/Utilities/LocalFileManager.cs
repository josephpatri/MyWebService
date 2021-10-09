using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace PeliculasAPI.Utilities
{
    public class LocalFileManager : ILocalFileManager
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor accessor;

        public LocalFileManager(IWebHostEnvironment env, IHttpContextAccessor accessor)
        {
            this.env = env;
            this.accessor = accessor;
        }

        public async Task<string> FileEdit(string container, IFormFile file, string path)
        {
            await DeleteFIle(path, container);
            return await FileSave(container, file);
        }
        public Task DeleteFIle(string path, string container)
        {
            if (String.IsNullOrEmpty(path))
            {
                return Task.CompletedTask;
            }

            var fileName = Path.GetFileName(path);
            var fileDirectory = Path.Combine(env.WebRootPath, container, fileName);

            if (File.Exists(fileDirectory))
            {
                File.Delete(fileDirectory);
            }

            return Task.CompletedTask;
        }
        public async Task<string> FileSave(string container, IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var fileName = $"{Guid.NewGuid()}{ext}";
            string folder = Path.Combine(env.WebRootPath, container);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string route = Path.Combine(folder, fileName);

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                var content = memoryStream.ToArray();
                await File.WriteAllBytesAsync(route, content);
            }

            var actualURL =
                $"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}";
            var dbRoute = Path.Combine(actualURL, container, fileName).Replace("\\", "/");
            return dbRoute;
        }
    }
}
