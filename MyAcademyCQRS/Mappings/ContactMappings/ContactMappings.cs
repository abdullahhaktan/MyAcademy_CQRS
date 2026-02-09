using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.CQRSPattern.Results.ContactResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.ContactMappings
{
    public class ContactMappings : Profile
    {
        public ContactMappings()
        {
            CreateMap<Contact, GetContactsQueryResult>();
            CreateMap<CreateContactCommand, Contact>();
            CreateMap<Contact, GetContactByIdQueryResult>();
        }
    }
}
