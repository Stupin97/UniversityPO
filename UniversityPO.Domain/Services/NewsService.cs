namespace UniversityPO.Domain.Services
{
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UniversityPO.Domain.Dto;
    public class NewsService : INewsService
    {
        private readonly UniversityContext _context;

        public NewsService() { }

        public NewsService(UniversityContext context)
        {
            _context = context;
        }

        public List<EventDto> GetAllEvents()
        {
            return _context.Event
                .Where(c => c.IsHidden != true)
                .Select(c => new EventDto
                {
                    EventId = c.EventId,
                    DatePublic = c.DatePublic,
                    Text = c.Text,
                    IsImportant = c.IsImportant,
                    IsUrgently = c.IsUrgently
                })
                .ToList();
        }

        public List<EventDto> GetSortEvents(List<EventDto> events)
        {
            return events
                .Where(c => c.Text != "")
                .OrderBy(c => c.DatePublic)
                .ToList();
        }

        public bool isFirstThreeIsImportantEvents(List<EventDto> events)
        {
            int countEvents = events.Count;

            return countEvents > 3
                ? events.Take(3).All(c => c.IsImportant == false)
                : false;
        }
    }
}
