using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;

using HomeForHope.Services.StoredFileService.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;
using VolunteeringManagementSystem.Services.Helpers;

namespace HomeForHope.Services.StoredFileService
{
    public class StoredFileAppService : ControllerBase, IStoredFileAppService
    {
        const string BASE_FILE_PATH = "App_Data/Upload";

        private readonly IRepository<StoredFile, Guid> _storedFileRepository;
        private readonly IMapper _mapper;
        public StoredFileAppService(IRepository<StoredFile, Guid> storedFileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _storedFileRepository = storedFileRepository;
        }

        [HttpPost, Route("Upload")]
        [Consumes("multipart/form-data")]
        public async Task<StoredFile> CreateStoredFile([FromForm] StoredFileDto input)
        {

            if (!Utils.IsImage(input.File))
                throw new ArgumentException("The file is not a valid image.");

            var checkAvailability = await _storedFileRepository.FirstOrDefaultAsync(x => x.FileName == input.File.FileName);
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            var storedFile = _mapper.Map<StoredFile>(input);
            storedFile.FileName = checkAvailability != null ? $"{timestamp}_{input.File.FileName}" : input.File.FileName;
            storedFile.FileType = input.File.ContentType;

            var filePath = $"{BASE_FILE_PATH}/{input.File.FileName}"; //png if it's an image

            using (var fileStream = input.File.OpenReadStream())
            {
                await SaveFile(filePath, fileStream);
            }
            return await _storedFileRepository.InsertAsync(storedFile);

        }

        private async Task SaveFile(string filePath, Stream stream)
        {
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await stream.CopyToAsync(fs);
            }
        }

        

        [HttpGet]
        public async Task<IActionResult> GetStoredFile(Guid id)
        {

            var storedFile = await _storedFileRepository.FirstOrDefaultAsync(x => x.Id == id);
            if (storedFile == null)
                //return Content("filename not present");
                throw new UserFriendlyException("File not found");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           BASE_FILE_PATH, storedFile.FileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));

        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

    }
}
