
using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Domain;

namespace Products.Application.EventLogs.Queries.GetEventLogList
{
    public class EventLogLookupDto : IMapWith<EventLog>
    {
        public Guid Id { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventLog, EventLogLookupDto>()
                .ForMember(dto => dto.Id, options => options
                    .MapFrom(log => log.Id))
                .ForMember(dto => dto.EventDate, options => options
                    .MapFrom(log => log.EventDate))
                .ForMember(dto => dto.Description, options => options
                    .MapFrom(log => log.Description));
        }
    }
    
}
