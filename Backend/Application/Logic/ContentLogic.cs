using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DaoInterfaces;
using Application.LogicInterfaces;
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

        public async Task<IEnumerable<ContentDto>> GetAllContentAsync()
        {
            
            var contents = await contentDao.GetAllContentAsync();

            var dtos = contents.Select(c => new ContentDto
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

        public async Task<ContentDto?> GetContentByIdAsync(Guid id)
        {

            if (id == Guid.Empty)
            {
                throw new ValidationException("Content cannot be empty");
            }

            var content = await contentDao.GetContentByIdAsync(id);

            if (content == null) {
                return null;
            }

            var dtos = new ContentDto
            {
                Id = content.ContentId,
                Title = content.Title,
                Description = content.Description,
                ReleaseDate = content.ReleaseDate,
                Type = content.Type,
                ImageURL = content.ImageURL
            };

            return dtos;
        }

        public async Task<ContentDto?> GetContentByRelaseDateAsync(DateTime dateRelased)
        {

            if(dateRelased > DateTime.Now)
            {
                throw new ValidationException("Content cannot be after todays date");
            }

            if (dateRelased < new DateTime(1900, 1,1))
            {
                throw new ValidationException("Content relased date cannot be before 1900");
            }

            var content = await contentDao.GetContentByRelaseDateAsync(dateRelased);

            if (content == null)
            {
                return null;
            }

            var dtos = new ContentDto
            {
                Id = content.ContentId,
                Title = content.Title,
                Description = content.Description,
                ReleaseDate = content.ReleaseDate,
                Type = content.Type,
                ImageURL = content.ImageURL
            };

            return dtos;
        }

        public async Task<ContentDto?> GetContentByTitleAsync(string title)
        {
            if (title.Equals(String.IsNullOrEmpty))
            {
                throw new ValidationException("Title cannot be empty");
            }

            var content = await contentDao.GetContentByTitleAsync(title);

            if (content == null)
            {
                return null;
            }

            var dtos = new ContentDto
            {
                Id = content.ContentId,
                Title = content.Title,
                Description = content.Description,
                ReleaseDate = content.ReleaseDate,
                Type = content.Type,
                ImageURL = content.ImageURL
            };

            return dtos;
        }

        public async Task<ContentDto?> GetContentByTypeAsync(ContentType type)
        {
            if (type != ContentType.Movie && type != ContentType.TVShow)
            {
                throw new ValidationException("Type can be only Movie or TV Show");
            }

            var content = await contentDao.GetContentByTypeAsync(type);

            if (content == null)
            {
                return null;
            }

            var dtos = new ContentDto
            {
                Id = content.ContentId,
                Title = content.Title,
                Description = content.Description,
                ReleaseDate = content.ReleaseDate,
                Type = content.Type,
                ImageURL = content.ImageURL
            };

            return dtos;
        }
    }
}

