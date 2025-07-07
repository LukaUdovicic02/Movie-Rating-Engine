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
using Domain.DTOs.CastDtos;
using Domain.DTOs.ContentDtos;
using Domain.Models;
using Microsoft.VisualBasic;

namespace Application.Logic
{
    public class ContentLogic : IContentLogic
    {
        private readonly IContentDao contentDao;
        private readonly IReviewDao reviewDao;

        public ContentLogic(IContentDao dao, IReviewDao reviewDao)
        {
            contentDao = dao;
            this.reviewDao = reviewDao;
        }

        public async Task<ContentDto?> GetContentByIdAsync(Guid id)
        {
            var content = await contentDao.GetContentByIdAsync(id);
            if (content == null)
                return null;

            var dto = (await MapToDtosAsync(new[] { content })).First();
            return dto;
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

            var dtos = await MapToDtosAsync(content);

            return dtos;

        }


        public async Task<IEnumerable<ContentDto>> SearchContentAsync(string? title, DateTime? releasedDate, int? minRating)
        {
            if (string.IsNullOrWhiteSpace(title) && releasedDate == null && minRating == null)
            {
                throw new ValidationException("At least one parameter should be provided");
            }

            var content = await contentDao.SearchContentAsync(title, releasedDate, minRating);

            var dtos = await MapToDtosAsync(content);

            return dtos;
        }

        // Helper method
        private async Task<IEnumerable<ContentDto>> MapToDtosAsync(IEnumerable<Content> contents)
        {
            var list = new List<ContentDto>();
            foreach (var c in contents)
            {
                var casts = await contentDao.GetCastByContentIdAsync(c.ContentId);
                var reviews = await reviewDao.GetByContentIdAsync(c.ContentId);

                list.Add(new ContentDto
                {
                    Id = c.ContentId,
                    Title = c.Title,
                    Description = c.Description,
                    ReleaseDate = c.ReleaseDate,
                    Type = c.Type,
                    ImageURL = c.ImageURL,
                    Casts = casts.Select(x => new CastDto { Id = x.CastId, Name = x.Name }),
                    AverageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0,
                    RatingCount = reviews.Count()
                });
            }
            return list;
        }
    }
}

