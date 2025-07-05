using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Azure.Storage;
using Azure.Storage.Blobs;
using Domain.DTOs.ContentDtos;
using Domain.Models;
using Microsoft.VisualBasic;

namespace Application.Logic
{
    public class ContentLogic : IContentLogic
    {
        private readonly IContentDao contentDao;

        public ContentLogic(IContentDao dao)
        {
            contentDao = dao;
        }


        public async Task<IEnumerable<ContentDto>> GetContentsByTypePaginatedAsync(ContentType type, int page, int pageSize)
        {
            if (page < 1)
                throw new ValidationException("Page number must be at least 1");

            if (pageSize < 1)
                throw new ValidationException("Page size must be at least 1");

            if (pageSize > 10)
                throw new ValidationException("Page size cannot exceed 10");


            var content = await contentDao.GetContentsByTypePaginatedAsync(type, page, pageSize);

            var dtos = content.Select(c => new ContentDto
            {
                Id = c.ContentId,
                Title = c.Title,
                Description = c.Description,
                ReleaseDate = c.ReleaseDate,
                Type = c.Type,
                ImageURL = c.ImageURL
            });

            return dtos;

        }

        public async Task<IEnumerable<ContentDto>> SearchContentAsync(string? title, DateTime? releasedDate)
        {
            if (string.IsNullOrWhiteSpace(title) && releasedDate == null)
            {
                throw new ValidationException("At least one parameter should be provided");
            }

            var content = await contentDao.SearchContentAsync(title, releasedDate);

            var dtos = content.Select(c => new ContentDto
            {
                Id = c.ContentId,
                Title = c.Title,
                Description = c.Description,
                ReleaseDate = c.ReleaseDate,
                Type = c.Type,
                ImageURL = c.ImageURL
            });

            return dtos;
        }
    }
}

