namespace UniversityPO.Domain.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UniversityPO.Domain.Dto;
    public class NewsService : INewsService
    {
        private readonly UniversityContext _context;

        public NewsService(UniversityContext context)
        {
            _context = context;
        }

        public async Task<List<EventDto>> GetAllEventsAsync()
        {
            return await _context.Event
                .Where(c => c.IsHidden != true)
                .Select(c => new EventDto
                {
                    EventId = c.EventId,
                    DatePublic = c.DatePublic,
                    Text = c.Text,
                    IsImportant = c.IsImportant,
                    IsUrgently = c.IsUrgently
                })
                .ToListAsync();
        }
    }
}
