
using AutoMapper;
using Products.Application.Common.Mappings;
using Products.Application.EventLogs.Queries.GetEventLogList;
using Products.Domain;

namespace Products.Application.EventLogs.Queries.GetEventLogDetails
{
    public class EventLogDetailsVM : IMapWith<EventLog>
    {
        public Guid Id { get; set; }
        public DateTime EventDate { get; set; }
        public string? Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<EventLog, EventLogDetailsVM>()
                .ForMember(vm => vm.Id, options => options
                    .MapFrom(log => log.Id))
                .ForMember(vm => vm.EventDate, options => options
                    .MapFrom(log => log.EventDate))
                .ForMember(vm => vm.Description, options => options
                    .MapFrom(log => log.Description));
        }
    }
}
