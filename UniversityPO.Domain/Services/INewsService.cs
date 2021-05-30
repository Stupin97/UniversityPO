namespace UniversityPO.Domain.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniversityPO.Domain.Dto;

    public interface INewsService
    {
        Task<List<EventDto>> GetAllEventsAsync();
    }
}
