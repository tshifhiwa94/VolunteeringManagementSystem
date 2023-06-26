using Abp.Application.Services.Dto;
using Abp.AutoMapper;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolunteeringManagementSystem.Domain;

namespace HomeForHope.Services.StoredFileService.Dto
{
    [AutoMap(typeof(StoredFile))]
    public class StoredFileDto : EntityDto<Guid?>
    {
        [NotMapped]
        public  IFormFile File { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string FileType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string OwnerId { get; set; }
    }
}
